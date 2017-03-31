using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using EastIPInternalInvoiceSystem.Module.BusinessObjects;

namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
{
    public class FormatterHelper
    {
        public static List<KeyValuePair<string, string>> FormatterType => new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("A", "1. 导入草单（不含第三方账单）"),
            new KeyValuePair<string, string>("B", "2. 导入草单（包含第三方账单）")
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


        /// <summary>
        ///     导入方法
        /// </summary>
        /// <param name="dtExcelData"></param>
        /// <param name="objectSpace"></param>
        /// <returns></returns>
        public static DataTable ImportData(DataTable dtExcelData, IObjectSpace objectSpace)
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
                    if (string.IsNullOrWhiteSpace(drData["开草单日期"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "开草单日期为空";
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(drData["草单编号"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "草单编号为空";
                        continue;
                    }
                    var sInterNo = drData["开草单日期"].ToString() + drData["草单编号"];
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
                            sCondition += $" And InternalType = '{(int) EnumsAll.InternalType.中间}'";
                            break;
                        case "2":
                            sCondition += $" And InternalType = '{(int) EnumsAll.InternalType.OA}'";
                            break;
                        case "3":
                            sCondition += $" And InternalType = '{(int) EnumsAll.InternalType.年费}'";
                            break;
                        case "4":
                            sCondition += $" And InternalType = '{(int) EnumsAll.InternalType.新申请}'";
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
                        objectSpace.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
                    switch (sInterNo[6].ToString())
                    {
                        case "1":
                            internalInvoice.InternalType = EnumsAll.InternalType.中间;
                            break;
                        case "2":
                            internalInvoice.InternalType = EnumsAll.InternalType.OA;
                            break;
                        case "3":
                            internalInvoice.InternalType = EnumsAll.InternalType.年费;
                            break;
                        case "4":
                            internalInvoice.InternalType = EnumsAll.InternalType.新申请;
                            break;
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
            return dtFormatData;
        }


        /// <summary>
        ///     导入方法
        /// </summary>
        /// <param name="dtExcelData"></param>
        /// <param name="objectSpace"></param>
        /// <returns></returns>
        public static DataTable ImportFData(DataTable dtExcelData, IObjectSpace objectSpace)
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
                    if (string.IsNullOrWhiteSpace(drData["项目"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "项目为空";
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(drData["草单编号"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "草单编号为空";
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(drData["分类"]?.ToString()))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "分类为空";
                        continue;
                    }
                    EnumsAll.InternalType internalType;
                    if (!Enum.TryParse(drData["分类"].ToString(), out internalType))
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "分类不正确";
                        continue;
                    }
                    var oldInterNo =
                        objectSpace.FindObject<InternalInvoice>(new BinaryOperator("InternalNo",
                            drData["草单编号"].ToString()));
                    if (oldInterNo != null)
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "存在相同编号的草单";
                        continue;
                    }
                    var sCondition =
                        $"OurNo = '{drData["卷号"]}' And Content = '{drData["项目"]}' And InternalType = '{(int) internalType}'";
                    oldInterNo = objectSpace.FindObject<InternalInvoice>(CriteriaOperator.Parse(sCondition));
                    if (oldInterNo != null)
                    {
                        drData["导入结果"] = "失败";
                        drData["相关信息"] = "存在相同案卷&内容&类型的草单";
                        continue;
                    }
                    var internalInvoice = objectSpace.CreateObject<InternalInvoice>();
                    internalInvoice.InternalNo = drData["草单编号"].ToString();
                    internalInvoice.OurNo = drData["卷号"].ToString();
                    internalInvoice.SetCaseInfo(drData["卷号"].ToString());
                    internalInvoice.CreateDate = DateTime.Now;
                    internalInvoice.SendDate = internalInvoice.CreateDate.AddDays(3);
                    internalInvoice.Deadline = internalInvoice.CreateDate.AddDays(7);
                    internalInvoice.Type = drData["账单归属"]?.ToString();
                    internalInvoice.Content = drData["项目"].ToString();
                    internalInvoice.PermissionPolicyUser =
                        objectSpace.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
                    internalInvoice.InternalType = internalType;
                    if (!string.IsNullOrWhiteSpace(drData["第三方账单号"]?.ToString()))
                    {
                        internalInvoice.IsFAgencyInvoice = true;
                        internalInvoice.FirmNo = drData["第三方账单号"].ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(drData["账单号"]?.ToString()))
                    {
                        internalInvoice.InvoiceNo = drData["账单号"].ToString();
                        internalInvoice.InvoiceLogDate = DateTime.Now;
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
            return dtFormatData;
        }
    }
}