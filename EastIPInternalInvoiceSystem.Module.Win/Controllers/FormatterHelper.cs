using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.XtraEditors;
using EastIPInternalInvoiceSystem.Module.BusinessObjects;

namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
{
    public class FormatterHelper
    {
        public static List<KeyValuePair<string, string>> FormatterType => new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("A", "1. 导入草单"),
            new KeyValuePair<string, string>("B", "2. 导入草单(旧)"),
            new KeyValuePair<string, string>("C", "3. 导入账单号"),
        };

        public static void LoadExcel(string sFilePath, int nIndex, ref List<string> listSheetsName,
            ref DataTable dtExcelData)
        {
            var sConnectionString =
                $"Provider=Microsoft.Ace.OleDb.12.0;data source={sFilePath};Extended Properties='Excel 12.0;'";
            using (var conn = new OleDbConnection(sConnectionString))
            {
                conn.Open();
                listSheetsName.Clear();
                var dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dtSheetName == null) return;
                listSheetsName.AddRange(dtSheetName.Rows.Cast<DataRow>().Select(r => r[2].ToString())); //获取Excel的表名
                if (listSheetsName.Count <= 0) return;
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from [" + listSheetsName[nIndex] + "]";
                    var ds = new DataSet();
                    using (var da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(ds, listSheetsName[nIndex]);
                        dtExcelData = ds.Tables[0];
                    }
                }
            }
        }

        public static DataTable ImportData(DataTable dtExcelData, IObjectSpace objectSpace)
        {
            var dtFormatData = dtExcelData.Copy();

            dtFormatData.Columns.Add("导入结果");
            dtFormatData.Columns.Add("相关信息");

            DataColumn dcInternalType = null;
            if (dtFormatData.Columns.Contains("草单类型"))
                dcInternalType = dtFormatData.Columns["草单类型"];
            DataColumn dcType = null;
            if (dtFormatData.Columns.Contains("类别"))
                dcType = dtFormatData.Columns["类别"];
            DataColumn dcFInvoiceNo = null;
            if (dtFormatData.Columns.Contains("外所账单编号"))
                dcFInvoiceNo = dtFormatData.Columns["外所账单编号"];

            if (!dtFormatData.Columns.Contains("我方卷号"))
            {
                var drData = dtFormatData.NewRow();
                drData["导入结果"] = "失败";
                drData["相关信息"] = "导入表中不存在我方卷号列";
                dtFormatData.Rows.InsertAt(drData, 0);
                return dtFormatData;
            }
            if (!dtFormatData.Columns.Contains("记录日"))
            {
                var drData = dtFormatData.NewRow();
                drData["导入结果"] = "失败";
                drData["相关信息"] = "导入表中不存在记录日列";
                dtFormatData.Rows.InsertAt(drData, 0);
                return dtFormatData;
            }

            foreach (DataRow drData in dtFormatData.Rows)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(drData["我方卷号"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "我方卷号为空";
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(drData["记录日"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "记录日为空";
                        continue;
                    }
                    EnumsAll.InternalType sInternalType;
                    if (dcInternalType != null && !string.IsNullOrWhiteSpace(drData["草单类型"]?.ToString()))
                    {
                        if (!Enum.TryParse(drData["草单类型"]?.ToString(), out sInternalType))
                        {
                            drData["导入结果"] = "失败";
                            drData["相关信息"] = "草单类型解析错误";
                            continue;
                        }
                    }
                    else if (dcType != null && !string.IsNullOrWhiteSpace(drData["类别"]?.ToString()))
                    {
                        switch (drData["类别"]?.ToString())
                        {
                            case "E-A":
                            case "E-B":
                            case "E-U":
                            case "SE":
                            case "U":
                            case "A":
                            case "B":
                                sInternalType = EnumsAll.InternalType.新申请;
                                break;
                            case "E-D":
                            case "D":
                                sInternalType = EnumsAll.InternalType.中间;
                                break;
                            case "E-E":
                            case "E":
                            case "E-F":
                            case "F":
                            case "E-X":
                            case "X":
                            case "E-W":
                            case "W":
                                sInternalType = EnumsAll.InternalType.OA;
                                break;
                            case "C":
                            case "E-S":
                            case "S":
                                sInternalType = EnumsAll.InternalType.年费;
                                break;
                            case "DJ":
                                sInternalType = EnumsAll.InternalType.特殊案件;
                                break;
                            case "P":
                                sInternalType = EnumsAll.InternalType.国外申请;
                                break;
                            case "E-G":
                            case "G":
                                sInternalType = EnumsAll.InternalType.其他;
                                break;
                            default:
                                drData["导入结果"] = "失败";
                                drData["相关信息"] = "类别解析错误";
                                continue;
                        }
                    }
                    else
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "缺少类别或草单类型";
                        continue;
                    }
                    if (dcFInvoiceNo != null && !string.IsNullOrWhiteSpace(drData["外所账单编号"]?.ToString()))
                    {
                        var internalNo = objectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse($"FirmNo = '{drData["外所账单编号"]}' And OurNo = '{drData["我方卷号"]}'"));
                        if (internalNo != null)
                        {
                            drData["导入结果"] = "失败";
                            drData["相关信息"] = "存在相同案卷&外所账单编号的草单";
                            continue;
                        }
                    }
                    var internalNo1 = objectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse($"InternalType = '{sInternalType}' And OurNo = '{drData["我方卷号"]}' And Content = ' '"));
                    if (internalNo1 != null)
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "存在相同案卷&草单类型&内容的草单";
                        continue;
                    }

                    var internalInvoice = objectSpace.CreateObject<InternalInvoice>();
                    internalInvoice.OurNo = drData["我方卷号"].ToString();
                    internalInvoice.SetCaseInfo(drData["我方卷号"].ToString());
                    internalInvoice.CreateDate = Convert.ToDateTime(drData["记录日"].ToString());
                    internalInvoice.SendDate = internalInvoice.CreateDate.AddDays(3);
                    internalInvoice.Deadline = internalInvoice.CreateDate.AddDays(7);
                    internalInvoice.Content = " ";
                    internalInvoice.PermissionPolicyUser =
                        objectSpace.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    internalInvoice.InternalType = sInternalType;
                    if (dcFInvoiceNo != null && !string.IsNullOrWhiteSpace(drData["外所账单编号"]?.ToString()))
                    {
                        internalInvoice.FirmNo = drData["外所账单编号"].ToString();
                        //internalInvoice.IsFAgencyInvoice = true;
                    }
                    internalInvoice.Save();
                    objectSpace.CommitChanges();
                    drData["导入结果"] = "成功";
                }
                catch (Exception e)
                {
                    drData["导入结果"] = "失败";
                    drData["相关信息"] = e.ToString();
                    objectSpace.Rollback();
                }
            }
            return dtFormatData;
        }

        //#region 旧数据导入

        /// <summary>
        ///     导入方法
        /// </summary>
        /// <param name="dtExcelData"></param>
        /// <param name="objectSpace"></param>
        /// <returns></returns>
        public static DataTable ImportDataOld(DataTable dtExcelData, IObjectSpace objectSpace)
        {
            var dtFormatData = dtExcelData.Copy();
            dtFormatData.Columns.Add("导入结果");
            dtFormatData.Columns.Add("相关信息");
            //dtFormatData.Columns["导入结果"].SetOrdinal(0);
            //dtFormatData.Columns.Add("相关信息").SetOrdinal(0);
            foreach (DataRow drData in dtFormatData.Rows)
                try
                {
                    if (string.IsNullOrWhiteSpace(drData["卷号"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "卷号为空";
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(drData["内容"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "内容为空";
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(drData["日期"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "日期为空";
                        continue;
                    }
                    string sInterNo = null;
                    var internalType = EnumsAll.InternalType.其他;
                    if (!string.IsNullOrWhiteSpace(drData["开草单日期"]?.ToString()) && !string.IsNullOrWhiteSpace(drData["草单编号"]?.ToString()))
                    {
                        sInterNo = drData["开草单日期"].ToString() + drData["草单编号"];
                        if (sInterNo.Length < 8)
                        {
                            drData["导入结果"] = "失败";
                            drData["相关信息"] = "草单编号不合法";
                            continue;
                        }
                        var oldInterNo = objectSpace.FindObject<InternalInvoice>(new BinaryOperator("InternalNo", sInterNo));
                        if (oldInterNo != null)
                        {
                            drData["导入结果"] = "失败";
                            drData["相关信息"] = "存在相同编号的草单";
                            continue;
                        }
                        var sCondition = $"OurNo = '{drData["卷号"]}' And Content = '{drData["内容"]}' ";
                        switch (sInterNo[6].ToString())
                        {
                            case "1":
                                sCondition += $" And InternalType = '{(int)EnumsAll.InternalType.中间}'";
                                break;
                            case "2":
                                sCondition += $" And InternalType = '{(int)EnumsAll.InternalType.OA}'";
                                break;
                            case "3":
                                sCondition += $" And InternalType = '{(int)EnumsAll.InternalType.年费}'";
                                break;
                            case "4":
                                sCondition += $" And InternalType = '{(int)EnumsAll.InternalType.新申请}'";
                                break;
                            case "7":
                                sCondition += $" And InternalType = '{(int)EnumsAll.InternalType.其他}'";
                                break;
                            default:
                                drData["导入结果"] = "失败";
                                drData["相关信息"] = "草单类型解析错误";
                                continue;
                        }
                        oldInterNo = objectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse(sCondition));
                        if (oldInterNo != null)
                        {
                            drData["导入结果"] = "失败";
                            drData["相关信息"] = "存在相同案卷&内容&类型的草单";
                            continue;
                        }
                        switch (sInterNo[6].ToString())
                        {
                            case "1":
                                internalType = EnumsAll.InternalType.中间;
                                break;
                            case "2":
                                internalType = EnumsAll.InternalType.OA;
                                break;
                            case "3":
                                internalType = EnumsAll.InternalType.年费;
                                break;
                            case "4":
                                internalType = EnumsAll.InternalType.新申请;
                                break;
                        }
                    }
                    var internalInvoice = objectSpace.CreateObject<InternalInvoice>();
                    internalInvoice.InternalNo = sInterNo;
                    internalInvoice.OurNo = drData["卷号"].ToString();
                    internalInvoice.SetCaseInfo(drData["卷号"].ToString());
                    internalInvoice.CreateDate = Convert.ToDateTime(drData["日期"].ToString());
                    internalInvoice.SendDate = internalInvoice.CreateDate.AddDays(3);
                    internalInvoice.Deadline = internalInvoice.CreateDate.AddDays(7);
                    internalInvoice.Type = drData["类别"].ToString();
                    internalInvoice.Content = drData["内容"].ToString();
                    internalInvoice.PermissionPolicyUser =
                        objectSpace.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    internalInvoice.InternalType = internalType;
                    internalInvoice.Save();
                    objectSpace.CommitChanges();
                    drData["导入结果"] = "成功";
                }
                catch (Exception e)
                {
                    drData["导入结果"] = "失败";
                    drData["相关信息"] = e.ToString();
                    objectSpace.Rollback();
                }
            return dtFormatData;
        }

        public static DataTable ImportInvoiceNo(DataTable dtExcelData, IObjectSpace objectSpace)
        {
            var dtFormatData = dtExcelData.Copy();

            dtFormatData.Columns.Add("导入结果");
            dtFormatData.Columns.Add("相关信息");

            if (!dtFormatData.Columns.Contains("草单编号"))
            {
                var drData = dtFormatData.NewRow();
                drData["导入结果"] = "失败";
                drData["相关信息"] = "导入表中不存在草单编号列";
                dtFormatData.Rows.InsertAt(drData, 0);
                return dtFormatData;
            }
            if (!dtFormatData.Columns.Contains("账单编号"))
            {
                var drData = dtFormatData.NewRow();
                drData["导入结果"] = "失败";
                drData["相关信息"] = "导入表中不存在账单编号列";
                dtFormatData.Rows.InsertAt(drData, 0);
                return dtFormatData;
            }
            if (!dtFormatData.Columns.Contains("账单记录日"))
            {
                var drData = dtFormatData.NewRow();
                drData["导入结果"] = "失败";
                drData["相关信息"] = "导入表中不存在账单记录日列";
                dtFormatData.Rows.InsertAt(drData, 0);
                return dtFormatData;
            }
            foreach (DataRow drData in dtFormatData.Rows)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(drData["草单编号"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "草单编号为空";
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(drData["账单编号"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "账单编号为空";
                        continue;
                    }

                    var internalNo = objectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse($"InternalNo = '{drData["草单编号"]}'"));
                    if (internalNo == null)
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "系统中不存在该草单。";
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(internalNo.InvoiceNo) &&
                        internalNo.InvoiceNo != drData["账单编号"].ToString())
                    {
                        var messageResult = XtraMessageBox.Show($"{drData["草单编号"]}该草单下已存在账单编号,原账单编号：{internalNo.InvoiceNo}；新账单编号：{drData["账单编号"]}，是否执行覆盖？", "提示", MessageBoxButtons.OKCancel);
                        if (messageResult != DialogResult.OK)
                        {
                            drData["导入结果"] = "失败";
                            drData["相关信息"] = $"{drData["草单编号"]}该草单下已存在账单编号,原账单编号：{internalNo.InvoiceNo}；新账单编号：{drData["账单编号"]}，已执行跳过";
                            continue;
                        }
                    }

                    internalNo.InvoiceNo = drData["账单编号"].ToString();
                    internalNo.InvoiceLogDate = string.IsNullOrWhiteSpace(drData["账单记录日"]?.ToString()) ? DateTime.Now : Convert.ToDateTime(drData["账单记录日"]);
                    internalNo.NoNeedInvoice = false;
                    internalNo.Save();
                    objectSpace.CommitChanges();
                    drData["导入结果"] = "成功";
                }
                catch (Exception e)
                {
                    drData["导入结果"] = "失败";
                    drData["相关信息"] = e.ToString();
                    objectSpace.Rollback();
                }
            }
            return dtFormatData;
        }


        ///// <summary>
        /////     导入方法
        ///// </summary>
        ///// <param name="dtExcelData"></param>
        ///// <param name="objectSpace"></param>
        ///// <returns></returns>
        //public static DataTable ImportFData(DataTable dtExcelData, IObjectSpace objectSpace)
        //{
        //    var dtFormatData = dtExcelData.Copy();
        //    dtFormatData.Columns.Add("导入结果");
        //    dtFormatData.Columns.Add("相关信息");
        //    //dtFormatData.Columns["导入结果"].SetOrdinal(0);
        //    //dtFormatData.Columns.Add("相关信息").SetOrdinal(0);
        //    foreach (DataRow drData in dtFormatData.Rows)
        //        try
        //        {
        //            if (string.IsNullOrWhiteSpace(drData["卷号"]?.ToString()))
        //            {
        //                drData["导入结果"] = "失败";
        //                drData["相关信息"] = "卷号为空";
        //                continue;
        //            }
        //            if (string.IsNullOrWhiteSpace(drData["项目"]?.ToString()))
        //            {
        //                drData["导入结果"] = "失败";
        //                drData["相关信息"] = "项目为空";
        //                continue;
        //            }
        //            if (string.IsNullOrWhiteSpace(drData["草单编号"]?.ToString()))
        //            {
        //                drData["导入结果"] = "失败";
        //                drData["相关信息"] = "草单编号为空";
        //                continue;
        //            }
        //            if (string.IsNullOrWhiteSpace(drData["分类"]?.ToString()))
        //            {
        //                drData["导入结果"] = "失败";
        //                drData["相关信息"] = "分类为空";
        //                continue;
        //            }
        //            EnumsAll.InternalType internalType;
        //            if (!Enum.TryParse(drData["分类"].ToString(), out internalType))
        //            {
        //                drData["导入结果"] = "失败";
        //                drData["相关信息"] = "分类不正确";
        //                continue;
        //            }
        //            var oldInterNo =
        //                objectSpace.FindObject<InternalInvoice>(new BinaryOperator("InternalNo",
        //                    drData["草单编号"].ToString()));
        //            if (oldInterNo != null)
        //            {
        //                drData["导入结果"] = "失败";
        //                drData["相关信息"] = "存在相同编号的草单";
        //                continue;
        //            }
        //            var sCondition =
        //                $"OurNo = '{drData["卷号"]}' And Content = '{drData["项目"]}' And InternalType = '{(int)internalType}'";
        //            oldInterNo = objectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse(sCondition));
        //            if (oldInterNo != null)
        //            {
        //                drData["导入结果"] = "失败";
        //                drData["相关信息"] = "存在相同案卷&内容&类型的草单";
        //                continue;
        //            }
        //            var internalInvoice = objectSpace.CreateObject<InternalInvoice>();
        //            internalInvoice.InternalNo = drData["草单编号"].ToString();
        //            internalInvoice.OurNo = drData["卷号"].ToString();
        //            internalInvoice.SetCaseInfo(drData["卷号"].ToString());
        //            internalInvoice.CreateDate = DateTime.Now;
        //            internalInvoice.SendDate = internalInvoice.CreateDate.AddDays(3);
        //            internalInvoice.Deadline = internalInvoice.CreateDate.AddDays(7);
        //            internalInvoice.Type = drData["账单归属"]?.ToString();
        //            internalInvoice.Content = drData["项目"].ToString();
        //            internalInvoice.PermissionPolicyUser =
        //                objectSpace.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
        //            internalInvoice.InternalType = internalType;
        //            if (!string.IsNullOrWhiteSpace(drData["第三方账单号"]?.ToString()))
        //            {
        //                internalInvoice.IsFAgencyInvoice = true;
        //                internalInvoice.FirmNo = drData["第三方账单号"].ToString();
        //            }
        //            if (!string.IsNullOrWhiteSpace(drData["账单号"]?.ToString()))
        //            {
        //                internalInvoice.InvoiceNo = drData["账单号"].ToString();
        //                internalInvoice.InvoiceLogDate = DateTime.Now;
        //            }
        //            internalInvoice.Save();
        //            objectSpace.CommitChanges();
        //            drData["导入结果"] = "成功";
        //        }
        //        catch (Exception e)
        //        {
        //            drData["导入结果"] = "失败";
        //            drData["相关信息"] = e.ToString();
        //            objectSpace.Rollback();
        //        }
        //    return dtFormatData;
        //} 
        //#endregion
    }
}