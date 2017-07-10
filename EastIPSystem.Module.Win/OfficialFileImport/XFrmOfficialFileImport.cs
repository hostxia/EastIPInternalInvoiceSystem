using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSplashScreen;
using EastIPSystem.Module.BusinessObjects;
using EastIPSystem.Module.DBUtility;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EastIPSystem.Module.Win.OfficialFileImport
{
    public partial class XFrmOfficialFileImport : DevExpress.XtraEditors.XtraForm
    {

        private IObjectSpace _objectSpace;
        public XFrmOfficialFileImport(IObjectSpace objectSpace)
        {
            _objectSpace = objectSpace;
            InitializeComponent();
            LoadCPCFiles();
            xgvOfficialFile.BestFitColumns(true);
        }

        public DataTable GetFiles()
        {
            var dtNow = DateTime.Now;
            if (DateTime.Now < new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0))
                return DbHelperMySQL.Query($"SELECT * FROM dzsq_med_tzs where XIAZAIRQ >= '{DateTime.Now.Date}' and XIAZAIRQ < '{new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0)}'").Tables[0];
            return DbHelperMySQL.Query($"SELECT * FROM dzsq_med_tzs where XIAZAIRQ >= '{new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 12, 0, 0)}' and XIAZAIRQ < '{dtNow.Date.AddDays(1).AddSeconds(-1)}'").Tables[0];
        }

        public DataTable ExistCase(string sAppNo, string sOurNo)
        {
            var dt = new DataTable();
            if (!string.IsNullOrWhiteSpace(sAppNo))
            {
                dt = DbHelperOra.Query($"select OURNO,APPLICATION_NO,CLIENT_NUMBER,DOCSTATE,CLIENT,CLIENT_NAME,APPL_CODE1,APPLICANT1,APPLICANT_CH1,APPL_CODE2,APPLICANT2,APPLICANT_CH2,APPL_CODE3,APPLICANT3,APPLICANT_CH3,APPL_CODE4,APPLICANT4,APPLICANT_CH4,APPL_CODE5,APPLICANT5,APPLICANT_CH5,WITHDREW,DIV_FILINGDATE from PATENTCASE where APPLICATION_NO = '{sAppNo}'").Tables[0];
            }
            if (!string.IsNullOrWhiteSpace(sOurNo) && dt.Rows.Count == 0)
            {
                return DbHelperOra.Query($"select OURNO,APPLICATION_NO,CLIENT_NUMBER,DOCSTATE,CLIENT,CLIENT_NAME,APPL_CODE1,APPLICANT1,APPLICANT_CH1,APPL_CODE2,APPLICANT2,APPLICANT_CH2,APPL_CODE3,APPLICANT3,APPLICANT_CH3,APPL_CODE4,APPLICANT4,APPLICANT_CH4,APPL_CODE5,APPLICANT5,APPLICANT_CH5,WITHDREW,DIV_FILINGDATE from PATENTCASE where OURNO like '{sOurNo}%'").Tables[0];
            }
            return dt;
        }

        public bool ExistFile(string sOurNo, string sAppNo, string sFileName, DateTime dtSendDate, string sFileCode = "")
        {
            return DbHelperOra.Exists($"select 1 from RECEIVINGLOG where (OURNO = '{sOurNo}' or APPNO = '{sAppNo}') and COMMENTS = '{sFileName}' and ISSUEDATE = to_date('{dtSendDate:yyyy/MM/dd}','yyyy/MM/dd')");
        }

        public void LoadCPCFiles()
        {
            SplashScreenManager.ShowDefaultWaitForm();
            var listFiles = GetFiles().Rows.Cast<DataRow>().Select(r => new CPCOfficialFile(r)).ToList();
            listFiles.ForEach(f =>
            {
                try
                {
                    if (f.SendDate == DateTime.MinValue)
                    {
                        f.Note += "官方发文日为空，该官文无法导入";
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(f.AppNo) && !f.AppNo.Contains('.'))
                        f.AppNo = f.AppNo.Insert(f.AppNo.Length - 1, ".");
                    var dtCase = ExistCase(f.AppNo, f.CPCSerial);
                    if (dtCase.Rows.Count < 1)
                    {
                        f.Note += "未找到案件";
                        return;
                    }
                    if (dtCase.Rows.Count > 1)
                    {
                        f.Note += "找到多个案件";
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(f.AppNo))
                        f.AppNo = dtCase.Rows[0][1].ToString();

                    if (dtCase.Rows[0][3]?.ToString().Trim().ToUpper() == "T")
                    {
                        f.CPCOfficialFileConfig.Dealer = "GS";
                    }
                    f.CaseSerial = dtCase.Rows[0]["OURNO"].ToString();
                    f.ClientNo = dtCase.Rows[0]["CLIENT"].ToString();
                    f.ClientName = dtCase.Rows[0]["CLIENT_NAME"].ToString();
                    f.WithDrew = dtCase.Rows[0]["WITHDREW"].ToString();
                    if (!string.IsNullOrWhiteSpace(dtCase.Rows[0]["DIV_FILINGDATE"].ToString()))
                        f.DivFilingDate = Convert.ToDateTime(dtCase.Rows[0]["DIV_FILINGDATE"]);
                    if (f.FileCode == "210304" || f.FileCode == "250304")
                    {
                        var listCode = new List<string> { "3667", "3443" };
                        if (listCode.Contains(dtCase.Rows[0]["APPL_CODE1"].ToString()) ||
                            listCode.Contains(dtCase.Rows[0]["APPL_CODE2"].ToString()) ||
                            listCode.Contains(dtCase.Rows[0]["APPL_CODE3"].ToString()) ||
                            listCode.Contains(dtCase.Rows[0]["APPL_CODE4"].ToString()) ||
                            listCode.Contains(dtCase.Rows[0]["APPL_CODE5"].ToString()) ||
                            listCode.Contains(dtCase.Rows[0]["CLIENT"].ToString()))
                        {
                            f.CPCOfficialFileConfig.Dealer = "GK";
                        }
                    }
                    f.CPCOfficialFileConfig.Dealer = HandlerRedistribution(f.CaseSerial, f.CPCOfficialFileConfig.Dealer, f.CPCOfficialFileConfig?.DeadlineFiledType != null);
                    GeneratePDFFile(f);
                }
                catch (Exception exception)
                {
                    f.Note += exception.ToString();
                }
            });
            xgcOfficialFile.DataSource = listFiles;
            xgcOfficialFile.Refresh();
            SplashScreenManager.CloseDefaultWaitForm();
        }

        public void GeneratePDFFile(CPCOfficialFile cpcOfficialFile)
        {
            if (!Directory.Exists(cpcOfficialFile.FilePath)) return;
            var sCPCFilePath = $@"{cpcOfficialFile.FilePath}\{cpcOfficialFile.FileSerial}\{cpcOfficialFile.FileSerial}";
            if (!Directory.Exists(sCPCFilePath)) return;
            var files = Directory.GetFiles(sCPCFilePath, "*.tif").ToList();
            Directory.GetFiles(cpcOfficialFile.FilePath, "*.tif", SearchOption.AllDirectories).ToList().ForEach(s =>
            {
                if (files.Contains(s)) return;
                files.Add(s);
            });
            if (files.Count == 0) return;
            var sGenerateFile = $@"D:\GenerateFolder\{DateTime.Now:yyyyMMddtt}\{cpcOfficialFile.CaseSerial.Substring(0, cpcOfficialFile.CaseSerial.IndexOf("-", StringComparison.Ordinal))}-{DateTime.Now:yyyyMMdd}-{(cpcOfficialFile.CPCOfficialFileConfig == null ? cpcOfficialFile.FileName : cpcOfficialFile.CPCOfficialFileConfig.Rename)}.pdf";
            int i = 1;
            while (File.Exists(sGenerateFile))
            {
                sGenerateFile = $@"D:\GenerateFolder\{DateTime.Now:yyyyMMddtt}\{cpcOfficialFile.CaseSerial.Substring(0, cpcOfficialFile.CaseSerial.IndexOf("-", StringComparison.Ordinal))}-{DateTime.Now:yyyyMMdd}-{(cpcOfficialFile.CPCOfficialFileConfig == null ? cpcOfficialFile.FileName : cpcOfficialFile.CPCOfficialFileConfig.Rename)}{i}.pdf";
                i++;
            }
            try
            {
                var document = new Document(PageSize.A4, 25, 25, 25, 25);
                if (!Directory.Exists(Path.GetDirectoryName(sGenerateFile)))
                    Directory.CreateDirectory(Path.GetDirectoryName(sGenerateFile));
                PdfWriter.GetInstance(document, new FileStream(sGenerateFile, FileMode.Create));
                document.Open();
                foreach (var p in files)
                {
                    var image = iTextSharp.text.Image.GetInstance(p);
                    if (image.Height > PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    else if (image.Width > PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(PageSize.A4.Width - 25, PageSize.A4.Height - 25);
                    }
                    image.Alignment = Element.ALIGN_MIDDLE;
                    document.NewPage();
                    document.Add(image);
                }
                document.Close();
            }
            catch (Exception e)
            {
                cpcOfficialFile.Note = e.ToString();
            }
            cpcOfficialFile.BizFilePath = sGenerateFile;
        }

        private void xbbiImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm();

            var listCPCOfficialFile =
                xgvOfficialFile.GetSelectedRows()
                    .Select(h => xgvOfficialFile.GetRow(h) as CPCOfficialFile)
                    .Where(f => f != null)
                    .ToList();

            listCPCOfficialFile.ForEach(f =>
            {
                var dtNow = DateTime.Now;
                f.Note = string.Empty;
                Application.DoEvents();
                try
                {
                    if (f.SendDate == DateTime.MinValue)
                    {
                        f.Note += "官方发文日为空，该官文无法导入";
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(f.CPCOfficialFileConfig.Dealer))
                    {
                        f.Note += "请填写处理人";
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(f.AppNo) && !f.AppNo.Contains('.'))
                        f.AppNo = f.AppNo.Insert(f.AppNo.Length - 1, ".");
                    var dtCase = ExistCase(f.AppNo, f.CPCSerial);
                    if (dtCase.Rows.Count < 1)
                    {
                        f.Note += "未找到案件";
                        return;
                    }
                    if (dtCase.Rows.Count > 1)
                    {
                        f.Note += "找到多个案件";
                        return;
                    }
                    f.CaseSerial = dtCase.Rows[0]["OURNO"].ToString();
                    f.ClientNo = dtCase.Rows[0]["CLIENT"].ToString();
                    f.ClientName = dtCase.Rows[0]["CLIENT_NAME"].ToString();
                    f.WithDrew = dtCase.Rows[0]["WITHDREW"].ToString();
                    if (!string.IsNullOrWhiteSpace(dtCase.Rows[0]["DIV_FILINGDATE"].ToString()))
                        f.DivFilingDate = Convert.ToDateTime(dtCase.Rows[0]["DIV_FILINGDATE"]);
                    f.Applicants = new Hashtable();
                    for (int i = 1; i <= 5; i++)
                    {
                        if (string.IsNullOrWhiteSpace(dtCase.Rows[0][$"APPL_CODE{i}"].ToString())) continue;
                        f.Applicants.Add(dtCase.Rows[0][$"APPL_CODE{i}"].ToString(), !string.IsNullOrWhiteSpace(dtCase.Rows[0][$"APPLICANT{i}"].ToString()) ? dtCase.Rows[0][$"APPLICANT{i}"].ToString() : dtCase.Rows[0][$"APPLICANT_CH{i}"].ToString());
                    }
                    if (ExistFile(f.CaseSerial, f.AppNo, f.FileName, f.SendDate))
                    {
                        f.Note += "通知书已在系统中存在";
                        return;
                    }

                    var filePatent = _objectSpace.FindObject<FilePatent>(CriteriaOperator.Parse("s_OurNo = ?", f.CaseSerial)) ?? _objectSpace.CreateObject<FilePatent>();
                    filePatent.s_OurNo = f.CaseSerial;
                    var fileInOfficial = _objectSpace.FindObject<FileInOfficial>(CriteriaOperator.Parse("s_OfficialNo = ?", f.SendSerial)) ?? _objectSpace.CreateObject<FileInOfficial>();
                    fileInOfficial.s_OfficialNo = f.SendSerial;
                    if (fileInOfficial.FilePatent == null)
                        fileInOfficial.FilePatent = filePatent;

                    var strSql = new List<string>();
                    if (!string.IsNullOrWhiteSpace(f.AppNo))
                    {
                        if (!string.IsNullOrWhiteSpace(dtCase.Rows[0]["APPLICATION_NO"].ToString()) &&
                            dtCase.Rows[0]["APPLICATION_NO"].ToString() != f.AppNo)
                        {
                            var dialogResult = XtraMessageBox.Show(
                                   $"通知书申请号与PatentCase系统中的申请号不一致，请确认是否进行更新，\r\n系统内申请号：{dtCase.Rows[0]["APPLICATION_NO"].ToString()}\r\n通知书申请号：{f.AppNo}", "冲突提醒", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Cancel)
                            {
                                f.Note += "存在冲突，已跳过";
                                return;
                            }
                            if (dialogResult == DialogResult.Yes)
                            {
                                strSql.Add($"update PATENTCASE set APPLICATION_NO = '{f.AppNo}' where OURNO = '{f.CaseSerial}'");
                            }
                        }
                        else
                        {
                            strSql.Add($"update PATENTCASE set APPLICATION_NO = '{f.AppNo}' where OURNO = '{f.CaseSerial}'");
                        }
                    }
                    if (f.FileCode == "210307" || f.FileCode == "210308")
                    {
                        strSql.Add($"update PATENTCASE set SE_INITIATED = 'Y', SE_DATE = to_date('{f.SendDate:yyyy/MM/dd HH:mm:ss}','yyyy/MM/dd hh24:mi:ss') where OURNO = '{f.CaseSerial}'");
                    }
                    strSql.Add($"insert into RECEIVINGLOG (PID,ISSUEDATE,RECEIVED,SENDERID,SENDER,OURNO,APPNO,CLIENTNO,CONTENT,COPIES,COMMENTS,STATUS,HANDLER) values ('{DateTime.Now:yyyyMMdd_HHmmss_ffffff_0}',to_date('{f.SendDate.Date:yyyy/MM/dd}','yyyy/MM/dd'),to_date('{DateTime.Now.Date:yyyy/MM/dd}','yyyy/MM/dd'),'SIPO','SIPO','{dtCase.Rows[0][0]}','{dtCase.Rows[0][1]}','{dtCase.Rows[0][2]}','other','1','{f.FileName}','P','{f.CPCOfficialFileConfig?.Dealer}')");

                    fileInOfficial.dt_OfficialSendDate = f.SendDate;
                    fileInOfficial.dt_ReceiveDate = DateTime.Now;
                    fileInOfficial.s_FileCode = f.FileCode;
                    fileInOfficial.s_FileName = f.FileName;
                    fileInOfficial.Handler = _objectSpace.FindObject<SysUser>(CriteriaOperator.Parse("Code = ?", f.CPCOfficialFileConfig?.Dealer));

                    if (f.CPCOfficialFileConfig?.DeadlineFiledType != null)
                    {
                        switch (f.CPCOfficialFileConfig.DeadlineFiledType.Value)
                        {
                            case DeadlineFiledType.Case:
                                if (f.CPCOfficialFileConfig.DeadlineFiled == "GRANTNOTIC_DATE")
                                    strSql.Add($"update PATENTCASE set GRANTNOTIC_DATE=to_date('{f.SendDate.Date:yyyy/MM/dd}','yyyy/MM/dd'),REGFEE_DL=to_date('{f.SendDate.Date.AddDays(15).AddMonths(2):yyyy/MM/dd}','yyyy/MM/dd') where OURNO = '{f.CaseSerial}'");//更新办登信息
                                else if (f.CPCOfficialFileConfig.DeadlineFiled == "PRE_EXAM_PASSED")
                                    strSql.Add($"update PATENTCASE set PRE_EXAM_PASSED=to_date('{f.SendDate.Date:yyyy/MM/dd}','yyyy/MM/dd') where OURNO = '{f.CaseSerial}'");//更新初审合格日
                                break;
                            case DeadlineFiledType.OA:
                                strSql.Add(
                                    $"insert into GENERALALERT (CREATED,TYPEID,OURNO,TRIGERDATE1,DUEDATE,OATYPE,COMMENTS) values (to_date('{DateTime.Now:yyyy/MM/dd HH:mm:ss}','yyyy/MM/dd hh24:mi:ss'),'invoa','{f.CaseSerial}',to_date('{f.SendDate.Date:yyyy/MM/dd}','yyyy/MM/dd'),to_date('{f.SendDate.Date.AddDays(f.CPCOfficialFileConfig.AddDays).AddMonths(f.CPCOfficialFileConfig.AddMonths):yyyy/MM/dd}','yyyy/MM/dd'),'{f.CPCOfficialFileConfig.DeadlineFiled}','{f.CPCOfficialFileConfig.DeadlineFiledNote}')");
                                break;
                            case DeadlineFiledType.Deadline:
                                if (f.FileCode == "200702" && !IsValidCase(f.AppNo))//如果是专利权终止通知书且案件已届满
                                    break;
                                strSql.Add(
                                    $"insert into GENERALALERT (CREATED,TYPEID,OURNO,DUEDATE,COMMENTS) values (to_date('{DateTime.Now:yyyy/MM/dd HH:mm:ss}','yyyy/MM/dd hh24:mi:ss'),'{f.CPCOfficialFileConfig.DeadlineFiled}','{f.CaseSerial}',to_date('{f.SendDate.Date.AddDays(f.CPCOfficialFileConfig.AddDays).AddMonths(f.CPCOfficialFileConfig.AddMonths):yyyy/MM/dd}','yyyy/MM/dd'),'{f.CPCOfficialFileConfig.DeadlineFiledNote}')");
                                break;
                            case DeadlineFiledType.FCaseDeadline:
                                break;
                        }
                    }

                    SendEmail(f);
                    var array = new ArrayList();
                    array.AddRange(strSql);
                    DbHelperOra.ExecuteSqlTran(array);
                    if (File.Exists(f.BizFilePath))
                    {
                        fileInOfficial.InFileData = _objectSpace.CreateObject<FileData>();
                        fileInOfficial.InFileData.LoadFromStream(Path.GetFileName(f.BizFilePath), File.OpenRead(f.BizFilePath));
                    }
                    fileInOfficial.Save();
                    filePatent.GetCaseInfo();
                    filePatent.Save();
                    _objectSpace.CommitChanges();
                    f.Note = "已导入";
                }
                catch (Exception exception)
                {
                    f.Note += exception.ToString();
                    _objectSpace.Rollback();
                }
                while (dtNow.AddSeconds(1) > DateTime.Now)
                {

                }

            });
            xgvOfficialFile.RefreshData();
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private bool IsValidCase(string sAppNo)
        {
            var objDate = DbHelperOra.GetSingle($"select FILING_DATE from PATENTCASE where APPLICATION_NO = '{sAppNo}'");
            var objPCTDate = DbHelperOra.GetSingle($"select PCT_APPN_DATE from PATENTCASE where APPLICATION_NO = '{sAppNo}'");
            DateTime dt;
            DateTime.TryParse(objDate?.ToString(), out dt);
            DateTime dtPCT;
            DateTime.TryParse(objPCTDate?.ToString(), out dtPCT);
            var dtResult = dtPCT;
            if (dtResult == DateTime.MinValue)
                dtResult = dt;
            if (dtResult == DateTime.MinValue)
                return true;
            var cType = sAppNo.Length > 10 ? sAppNo[4] : sAppNo[2];
            if (cType == '1' || cType == '8')
                return dtResult.AddYears(20) >= DateTime.Now;
            return dtResult.AddYears(10) >= DateTime.Now;
        }

        private string HandlerRedistribution(string sOurNo, string sDefaultHandler, bool bHasDeadline)
        {
            if (sDefaultHandler == "ON") return "ON";
            if (sDefaultHandler == "GK") return "GK";
            var sOurNoShort = sOurNo.Substring(0, sOurNo.IndexOf("-", StringComparison.Ordinal));
            var sOurFlow = Regex.Match(sOurNoShort, @"\d{4}").Value;
            var listOurNum = sOurFlow.Reverse().ToList();
            if (sDefaultHandler == "DXD")
            {
                if (!bHasDeadline)
                    return "GK";
                foreach (var sNum in listOurNum)
                {
                    if ("2457".Contains(sNum))
                        return "QSY";
                    if ("1390".Contains(sNum))
                        return "DXD";
                }
            }
            else if (sDefaultHandler == "XN")
            {
                foreach (var sNum in listOurNum)
                {
                    if ("134".Contains(sNum))
                        return "XN";
                    if ("267".Contains(sNum))
                        return "SJY";
                    if ("059".Contains(sNum))
                        return "ZX";
                }
            }
            else if (sDefaultHandler == "GS")
            {
                if ("13579".Contains(listOurNum[0]))
                    return "LJJ";
                if ("24680".Contains(listOurNum[0]))
                    return "WRX";
            }
            else if (sDefaultHandler == "SP")
            {
                if ("13579".Contains(listOurNum[0]))
                    return "ZM";
                if ("24680".Contains(listOurNum[0]))
                    return "TSN";
            }
            return string.Empty;
        }

        private void SendEmail(CPCOfficialFile cpcOfficialFile)
        {
            var message = new MailMessage();
            var fromAddr = new MailAddress("official_notice@beijingeastip.com");
            message.From = fromAddr;
            message.To.Add(HtEmails[cpcOfficialFile.CPCOfficialFileConfig.Dealer].ToString());
            if (cpcOfficialFile.FileCode == "210305" || cpcOfficialFile.FileCode == "210308")
            {
                var objDate = DbHelperOra.GetSingle($"select FIRST_HK_CANCELLED from PATENTCASE where OURNO = '{cpcOfficialFile.CaseSerial}'");
                if (objDate?.ToString().ToUpper() != "Y")
                    message.To.Add("docketing@beijingeastip.com");
            }
            var objClient = DbHelperOra.GetSingle($"select CLIENT from PATENTCASE where OURNO = '{cpcOfficialFile.CaseSerial}'");
            if (objClient?.ToString() == "3443")
            {
                message.To.Add("huawei.list@beijingeastip.com");
            }
            message.CC.Add("official_notice@beijingeastip.com");
            message.Headers.Add("Disposition-Notification-To", "official_notice@beijingeastip.com");

            var listSubject = new List<string>();
            listSubject.Add(cpcOfficialFile.CaseSerial);
            if (cpcOfficialFile.Applicants.Count > 0)
                listSubject.Add(cpcOfficialFile.Applicants.Cast<DictionaryEntry>().ToList()[0].Key.ToString());
            listSubject.Add(cpcOfficialFile.FileName);
            if (cpcOfficialFile.CPCOfficialFileConfig.CreateDeadline &&
                cpcOfficialFile.CPCOfficialFileConfig.DeadlineFiled != "PRE_EXAM_PASSED" &&
                !(cpcOfficialFile.FileCode == "200702" && !IsValidCase(cpcOfficialFile.AppNo)))
                listSubject.Add(
                    cpcOfficialFile.SendDate.AddDays(cpcOfficialFile.CPCOfficialFileConfig.AddDays)
                        .AddMonths(cpcOfficialFile.CPCOfficialFileConfig.AddMonths)
                        .ToString("yyyy/MM/dd"));
            else if (cpcOfficialFile.FileCode == "200103")//缴纳申请费通知书
                listSubject.Add((cpcOfficialFile.DivFilingDate ?? cpcOfficialFile.AppDate).AddMonths(2).ToString("yyyy/MM/dd"));
            else if (cpcOfficialFile.FileCode == "200021")//费用减缓通知书
                listSubject.Add((cpcOfficialFile.DivFilingDate ?? cpcOfficialFile.AppDate).AddMonths(2).ToString("yyyy/MM/dd"));
            if (!string.IsNullOrWhiteSpace(cpcOfficialFile.WithDrew))
                listSubject.Add(cpcOfficialFile.WithDrew);
            message.Subject = string.Join("；", listSubject);

            var listBody = new List<string>();
            listBody.Add(
                $"申请人：{string.Join("； ", cpcOfficialFile.Applicants.Cast<DictionaryEntry>().Select(a => a.Key + "，" + a.Value).ToList())}");
            listBody.Add($"委托人：{cpcOfficialFile.ClientNo}，{cpcOfficialFile.ClientName}");
            listBody.Add($@"文件地址：\\PTFILE\PATENT\Cases-CN\{cpcOfficialFile.CaseSerial.Substring(0, cpcOfficialFile.CaseSerial.IndexOf("-", StringComparison.Ordinal))}\From_Office");
            message.Body = string.Join("\r\n", listBody);

            var client = new SmtpClient("smtp.beijingeastip.com", 25);
            client.Credentials = new NetworkCredential("official_notice@beijingeastip.com", "O@notice");
            //client.EnableSsl = true;
            client.Send(message);
        }

        private void xgvOfficialFile_DoubleClick(object sender, EventArgs e)
        {
            var cpcFile = xgvOfficialFile.GetFocusedRow() as CPCOfficialFile;
            if (string.IsNullOrWhiteSpace(cpcFile?.BizFilePath)) return;
            Process.Start(cpcFile.BizFilePath);
        }

        private void xbbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadCPCFiles();
            xgvOfficialFile.RefreshData();
        }

        private void xbbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var listCPCOfficialFile =
                xgvOfficialFile.GetSelectedRows()
                    .Select(h => xgvOfficialFile.GetRow(h) as CPCOfficialFile)
                    .Where(f => f != null)
                    .ToList();

            var listCPCOfficialFiles = xgcOfficialFile.DataSource as List<CPCOfficialFile>;
            listCPCOfficialFile.ForEach(c => listCPCOfficialFiles.Remove(c));
            xgcOfficialFile.RefreshDataSource();
        }

        private void xbbiMessage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xgvOfficialFile.GetSelectedRows().Select(xgvOfficialFile.GetRow).Cast<CPCOfficialFile>().ToList().ForEach(SendEmail);
        }

        private Hashtable HtEmails => new Hashtable()
        {
            {"DXD", "xiaoduo.ding@beijingeastip.com"},
            {"ZD", "di.zhang@beijingeastip.com"},
            {"QSY", "siyang.qin@beijingeastip.com"},
            {"GS", "shuang.guo@beijingeastip.com"},
            {"LJJ", "jianjiao.lu@beijingeastip.com"},
            {"WRX", "runxiu.wu@beijingeastip.com"},
            {"ZM", "meng.zhang@beijingeastip.com"},
            {"TSN", "shengnan.tian@beijingeastip.com"},
            {"XN", "na.xin@beijingeastip.com"},
            {"SJY", "jingyu.shen@beijingeastip.com"},
            {"ZX", "xiao.zhang@beijingeastip.com"},
            {"ZNQ", "naiqi.zhang@beijingeastip.com"},
            {"ON", "official_notice@beijingeastip.com"},
            {"SWJ", "wenjing.su@beijingeastip.com"},
            {"GG", "ge.gao@beijingeastip.com"},
            {"WR", "rui.wang@beijingeastip.com"},
            {"GK", "kai.guo@beijingeastip.com"}
        };
    }
}
