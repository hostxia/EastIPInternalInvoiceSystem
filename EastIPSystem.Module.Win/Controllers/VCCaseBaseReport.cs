using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.XtraEditors;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Win.Controllers
{
    public class VCCaseBaseReport : ObjectViewController<DetailView, CaseBase>
    {
        public VCCaseBaseReport()
        {
            TargetViewId = "CaseBaseReportView";
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var beExportFile = View.FindItem("CaseBase.ExportFile").Control as ButtonEdit;
            if (beExportFile != null)
            {
                beExportFile.ReadOnly = true;
                beExportFile.ButtonClick += BeExportFile_ButtonClick;
            }
            var deReceiveDateBegin = View.FindItem("CaseBase.ReceiveDateBegin").Control as DateEdit;
            var deReceiveDateEnd = View.FindItem("CaseBase.ReceiveDateEnd").Control as DateEdit;
            var deTransferDateBegin = View.FindItem("CaseBase.TransferDateBegin").Control as DateEdit;
            var deTransferDateEnd = View.FindItem("CaseBase.TransferDateEnd").Control as DateEdit;
            //var lueReportType = View.FindItem("CaseBase.ReportType").Control as LookUpEdit;
            //lueReportType.Properties.DataSource = new Hashtable { { "1", "国外" }, { "2", "港澳台" } };
            //lueReportType.Properties.DisplayMember = "Value";
            //lueReportType.Properties.ValueMember = "Key";
            if (deReceiveDateBegin != null && deTransferDateBegin != null)
                deReceiveDateBegin.DateTime = deTransferDateBegin.DateTime = new DateTime(DateTime.Now.Year, 1, 1);
            if (deReceiveDateEnd != null && deTransferDateEnd != null)
                deReceiveDateEnd.DateTime = deTransferDateEnd.DateTime = DateTime.Today;
        }

        private void BeExportFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件|*.xlsx";
            saveFileDialog.FileName = "Result.xlsx";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            ((ButtonEdit)sender).Text = saveFileDialog.FileName;
        }
    }
}
