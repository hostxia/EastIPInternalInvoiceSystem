using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using EastIPSystem.Module.BusinessObjects;
using ListView = DevExpress.ExpressApp.ListView;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class VCCaseBaseList : ViewController
    {
        public VCCaseBaseList()
        {
            InitializeComponent();
        }

        private void saCaseBaseImport_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            new XFrmImport(ObjectSpace, XFrmImport.FormType.Case).Show();
        }


        private void saCaseBaseReport_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel文件|*.xlsx",
                FileName = "Result.xlsx"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            GenerateCaseBaseExcelReport(saveFileDialog.FileName);
        }

        private void GenerateCaseBaseExcelReport(string sExportFile)
        {
            var listCase = ((ListView)View).SelectedObjects.Cast<CaseBase>().ToList();

            var listReceiveCase = listCase.Where(c => c.dt_TransferDate == DateTime.MinValue).ToList();
            var listTransferCase = listCase.Where(c => c.dt_TransferDate != DateTime.MinValue).ToList();

            var dtMinTransfer = listTransferCase.Count == 0 ? DateTime.Today : listTransferCase.Min(c => c.dt_TransferDate);
            var dtMinReceive = listReceiveCase.Count == 0 ? DateTime.Today : listReceiveCase.Min(c => c.dt_ReceiveDate);

            var dtMin = dtMinTransfer > dtMinReceive ? dtMinReceive : dtMinTransfer;
            if (dtMinTransfer == DateTime.MinValue)
                dtMin = dtMinReceive;
            if (dtMinReceive == DateTime.MinValue)
                dtMin = dtMinTransfer;

            var dtMaxTransfer = listTransferCase.Max(c => c.dt_TransferDate);
            var dtMaxReceive = listTransferCase.Max(c => c.dt_ReceiveDate);
            var dtMax = dtMaxTransfer > dtMaxReceive ? dtMaxTransfer : dtMaxReceive;

            if (dtMaxTransfer == DateTime.MinValue)
                dtMax = dtMaxReceive;
            if (dtMaxReceive == DateTime.MinValue)
                dtMax = dtMaxTransfer;



            var dtMonthBegin = new DateTime(dtMin.Year, dtMin.Month, 1);

            var listCorporationName = listReceiveCase.Select(c => new { c.Client?.Code, c.Client?.Name, c.Client?.Country?.s_Name }).ToList();
            listCorporationName.AddRange(listTransferCase.Select(c => new { c.Agency?.Code, c.Agency?.Name, c.Agency?.Country?.s_Name }).ToList());
            listCorporationName = listCorporationName.Where(c => !string.IsNullOrWhiteSpace(c.Name)).Distinct().OrderBy(c => c.Name).ToList();

            var sscReport = new SpreadsheetControl();
            File.Copy(System.Windows.Forms.Application.StartupPath + "\\Template\\外代交换案件.xlsx", sExportFile, true);
            sscReport.LoadDocument(sExportFile);
            var baseCell = sscReport.Document.Worksheets["全部"].Cells["G5"];


            for (int row = 0; row < listCorporationName.Count; row++)
            {
                int nReceived = 0;
                int nTransfer = 0;
                for (int col = 0; dtMonthBegin.AddMonths(col) < dtMax; col++)
                {
                    baseCell[-2, col * 2].Value = $"{dtMonthBegin.AddMonths(col).Year}年{dtMonthBegin.AddMonths(col).Month}月";
                    baseCell[-1, col * 2].Value = $"发出案件";
                    baseCell[-1, col * 2 + 1].Value = $"返回案件";
                    baseCell[row, -4].Value = listCorporationName[row].Name;
                    baseCell[row, -3].Value = listCorporationName[row].s_Name;

                    var listReceived = listReceiveCase.Where(c => c.dt_ReceiveDate >= dtMonthBegin.AddMonths(col) && c.dt_ReceiveDate < dtMonthBegin.AddMonths(col + 1) && c.Client?.Name == listCorporationName[row].Name);
                    var listTransfer = listTransferCase.Where(c => c.dt_TransferDate >= dtMonthBegin.AddMonths(col) && c.dt_TransferDate < dtMonthBegin.AddMonths(col + 1) && c.Agency?.Name == listCorporationName[row].Name);


                    if (listTransfer.Any())
                    {
                        baseCell[row, col * 2].Value = listTransfer.Count();
                        nTransfer += listTransfer.Count();
                        AddComments(sscReport.Document.Worksheets["全部"], baseCell[row, col * 2], "System", string.Join("\r\n", listTransfer.Select(t => t.s_OurNo)));
                    }
                    if (listReceived.Any())
                    {
                        baseCell[row, col * 2 + 1].Value = listReceived.Count();
                        nReceived += listReceived.Count();
                        AddComments(sscReport.Document.Worksheets["全部"], baseCell[row, col * 2 + 1], "System", string.Join("\r\n", listReceived.Select(t => t.s_OurNo)));
                    }

                }
                if (nTransfer > 0)
                    baseCell[row, -2].Value = nTransfer;
                if (nReceived > 0)
                    baseCell[row, -1].Value = nReceived;
            }
            GenerateSubCaseReport(listCase.Where(c => c.b_IsAppDemand).ToList(), sscReport.Document.Worksheets["申请人指定"], true);
            GenerateSubCaseReport(listCase.Where(c => c.b_IsApplication).ToList(), sscReport.Document.Worksheets["新申请"], false);
            GenerateSubCaseReport(listCase.Where(c => c.b_IsSepcial).ToList(), sscReport.Document.Worksheets["特殊案"], false);
            GenerateSubCaseReport(listCase.Where(c => c.b_IsMiddle).ToList(), sscReport.Document.Worksheets["转入案"], false);
            GenerateSubCaseReport(listCase.Where(c => c.b_IsDivCase).ToList(), sscReport.Document.Worksheets["分案"], false);
            sscReport.SaveDocument();
        }

        private void GenerateSubCaseReport(List<CaseBase> listCases, Worksheet worksheet, bool bIsTransfer)
        {
            if (listCases.Count == 0) return;
            var dtMin = bIsTransfer ? listCases.Where(c => c.dt_TransferDate != DateTime.MinValue).Min(c => c.dt_TransferDate) : listCases.Where(c => c.dt_ReceiveDate != DateTime.MinValue).Min(c => c.dt_ReceiveDate);
            var dtMax = bIsTransfer ? listCases.Max(c => c.dt_TransferDate) : listCases.Max(c => c.dt_ReceiveDate);

            if (dtMin == DateTime.MinValue)
                dtMin = dtMax;
            if (dtMax == DateTime.MinValue)
                dtMax = dtMin;

            var dtMonthBegin = new DateTime(dtMin.Year, dtMin.Month, 1);

            var listCorporationName = bIsTransfer ? listCases.Select(c => new { c.Agency?.Code, c.Agency?.Name, c.Agency?.Country?.s_Name }).ToList() : listCases.Select(c => new { c.Client?.Code, c.Client?.Name, c.Client?.Country?.s_Name }).ToList();
            listCorporationName = listCorporationName.Where(c => !string.IsNullOrWhiteSpace(c.Name)).Distinct().OrderBy(c => c.Name).ToList();

            var baseCell = worksheet.Cells["F5"];

            for (int row = 0; row < listCorporationName.Count; row++)
            {
                int nCount = 0;
                for (int col = 0; dtMonthBegin.AddMonths(col) < dtMax; col++)
                {
                    baseCell[-2, col].Value = $"{dtMonthBegin.AddMonths(col).Year}年{dtMonthBegin.AddMonths(col).Month}月";
                    baseCell[-1, col].Value = bIsTransfer ? $"发出案件" : $"返回案件";
                    baseCell[row, -3].Value = listCorporationName[row].Name;
                    baseCell[row, -2].Value = listCorporationName[row].s_Name;

                    var listCase = bIsTransfer
                        ? listCases.Where(
                            c =>
                                c.dt_TransferDate >= dtMonthBegin.AddMonths(col) &&
                                c.dt_TransferDate < dtMonthBegin.AddMonths(col + 1) &&
                                c.Agency?.Name == listCorporationName[row].Name).ToList()
                        : listCases.Where(
                            c =>
                                c.dt_ReceiveDate >= dtMonthBegin.AddMonths(col) &&
                                c.dt_ReceiveDate < dtMonthBegin.AddMonths(col + 1) &&
                                c.Client?.Name == listCorporationName[row].Name).ToList();


                    if (listCase.Any())
                    {
                        baseCell[row, col].Value = listCase.Count();
                        nCount += listCase.Count();
                        AddComments(worksheet, baseCell[row, col], "System", string.Join("\r\n", listCase.Select(t => t.s_OurNo)));
                    }
                }
                if (nCount > 0)
                    baseCell[row, -1].Value = nCount;
            }

        }

        private void AddComments(Worksheet worksheet, Range range, string author, string text)
        {
            var comments = worksheet.Comments.GetComments(range);
            if (comments.Count > 0)
                comments[0].Text += text;
            else
                worksheet.Comments.Add(range, author, text);
        }
    }
}