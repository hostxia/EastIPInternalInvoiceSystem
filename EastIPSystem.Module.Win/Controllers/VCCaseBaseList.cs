using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Spreadsheet;
using DevExpress.SpreadsheetSource.Implementation;
using DevExpress.XtraEditors;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class VCCaseBaseList : ViewController
    {
        public VCCaseBaseList()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void pwsaCaseBaseReport_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var view = Application.CreateDetailView(Application.CreateObjectSpace(), "CaseBaseReportView", false);
            //((PropertyEditor)view.FindItem("CaseBase.ExportFile"))
            e.View = view;
        }

        private void pwsaCaseBaseReport_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var view = e.PopupWindowView as DetailView;
            if (view == null) return;
            var dtReceiveDateBegin = ((DateEdit)view.FindItem("CaseBase.ReceiveDateBegin").Control).DateTime;
            var dtReceiveDateEnd = ((DateEdit)view.FindItem("CaseBase.ReceiveDateEnd").Control).DateTime;
            var dtTransferDateBegin = ((DateEdit)view.FindItem("CaseBase.TransferDateBegin").Control).DateTime;
            var dtTransferDateEnd = ((DateEdit)view.FindItem("CaseBase.TransferDateEnd").Control).DateTime;
            var sExportFile = ((ButtonEdit)view.FindItem("CaseBase.ExportFile").Control).Text;
            var sType = ((LookUpEdit)view.FindItem("CaseBase.ReportType").Control).EditValue?.ToString();
            GenerateCaseBaseExcelReport(dtReceiveDateBegin, dtReceiveDateEnd, dtTransferDateBegin, dtTransferDateEnd, sExportFile, sType);
        }

        private void GenerateCaseBaseExcelReport(DateTime dtReceiveDateBegin, DateTime dtReceiveDateEnd, DateTime dtTransferDateBegin, DateTime dtTransferDateEnd, string sExportFile, string sType)
        {
            var listReceiveCase = ObjectSpace.CreateCollection(typeof(CaseBase), CriteriaOperator.Parse("TransferDate Is Null And ReceiveDate >= ? And ReceiveDate < ?", dtReceiveDateBegin.Date, dtReceiveDateEnd.Date.AddDays(1)));
            var listTransferCase = ObjectSpace.CreateCollection(typeof(CaseBase), CriteriaOperator.Parse("TransferDate >= ? And TransferDate < ?", dtTransferDateBegin.Date, dtTransferDateEnd.Date.AddDays(1)));
            var listTMH = new[] { "TW", "MO", "HK" };
            if (sType != "1")
            {
                listReceiveCase =
                    listReceiveCase.Cast<CaseBase>()
                        .Where(c => listTMH.Contains(c.Client?.Country?.s_Code))
                        .ToList();
                listTransferCase =
                    listTransferCase.Cast<CaseBase>()
                        .Where(c => listTMH.Contains(c.Agency?.Country?.s_Code))
                        .ToList();
            }
            else
            {
                listReceiveCase =
                    listReceiveCase.Cast<CaseBase>()
                        .Where(c => !listTMH.Contains(c.Client?.Country?.s_Code))
                        .ToList();
                listTransferCase =
                    listTransferCase.Cast<CaseBase>()
                        .Where(c => !listTMH.Contains(c.Agency?.Country?.s_Code))
                        .ToList();
            }


            var dtMinTransfer = listTransferCase.Cast<CaseBase>().Min(c => c.dt_TransferDate);
            var dtMinReceive = listTransferCase.Cast<CaseBase>().Min(c => c.dt_ReceiveDate);

            var dtMin = dtMinTransfer > dtMinReceive ? dtMinReceive : dtMinTransfer;
            if (dtMinTransfer == DateTime.MinValue)
                dtMin = dtMinReceive;
            if (dtMinReceive == DateTime.MinValue)
                dtMin = dtMinTransfer;

            var dtMaxTransfer = listTransferCase.Cast<CaseBase>().Max(c => c.dt_TransferDate);
            var dtMaxReceive = listTransferCase.Cast<CaseBase>().Max(c => c.dt_ReceiveDate);
            var dtMax = dtMaxTransfer > dtMaxReceive ? dtMaxTransfer : dtMaxReceive;

            if (dtMaxTransfer == DateTime.MinValue)
                dtMax = dtMaxReceive;
            if (dtMaxReceive == DateTime.MinValue)
                dtMax = dtMaxTransfer;

            var dtMonthBegin = new DateTime(dtMin.Year, dtMin.Month, 1);

            var listCorporationName = listReceiveCase.Cast<CaseBase>().Select(c => new { c.Client?.Code, c.Client?.Name, c.Client?.Country?.s_Name }).ToList();
            listCorporationName.AddRange(listTransferCase.Cast<CaseBase>().Select(c => new { c.Agency?.Code, c.Agency?.Name, c.Agency?.Country?.s_Name }).ToList());
            listCorporationName = listCorporationName.Where(c => !string.IsNullOrWhiteSpace(c.Name)).Distinct().OrderBy(c => c.Name).ToList();

            var sscReport = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            File.Copy(System.Windows.Forms.Application.StartupPath + "\\Template\\外代交换案件.xlsx", sExportFile, true);
            sscReport.LoadDocument(sExportFile);
            var baseCell = sscReport.ActiveWorksheet.Cells["G5"];


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

                    var listReceived = listReceiveCase.Cast<CaseBase>().Where(c => c.dt_ReceiveDate >= dtMonthBegin.AddMonths(col) && c.dt_ReceiveDate < dtMonthBegin.AddMonths(col + 1) && c.Client?.Name == listCorporationName[row].Name);
                    var listTransfer = listTransferCase.Cast<CaseBase>().Where(c => c.dt_TransferDate >= dtMonthBegin.AddMonths(col) && c.dt_TransferDate < dtMonthBegin.AddMonths(col + 1) && c.Agency?.Name == listCorporationName[row].Name);


                    if (listTransfer.Any())
                    {
                        baseCell[row, col * 2].Value = listTransfer.Count();
                        nTransfer += listTransfer.Count();
                        AddComments(sscReport, baseCell[row, col * 2], "System", string.Join("\r\n", listTransfer.Select(t => t.s_OurNo)));
                    }
                    if (listReceived.Any())
                    {
                        baseCell[row, col * 2 + 1].Value = listReceived.Count();
                        nReceived += listReceived.Count();
                        AddComments(sscReport, baseCell[row, col * 2 + 1], "System", string.Join("\r\n", listReceived.Select(t => t.s_OurNo)));
                    }

                }
                if (nTransfer > 0)
                    baseCell[row, -2].Value = nTransfer;
                if (nReceived > 0)
                    baseCell[row, -1].Value = nReceived;
            }

            sscReport.SaveDocument();
        }

        private void AddComments(DevExpress.XtraSpreadsheet.SpreadsheetControl xsscReport, Range range, string author, string text)
        {
            var comments = xsscReport.ActiveWorksheet.Comments.GetComments(range);
            if (comments.Count > 0)
                comments[0].Text += text;
            else
                xsscReport.ActiveWorksheet.Comments.Add(range, author, text);
        }

    }
}
