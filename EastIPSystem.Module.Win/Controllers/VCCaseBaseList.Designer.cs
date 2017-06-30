namespace EastIPSystem.Module.Win.Controllers
{
    partial class VCCaseBaseList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saCaseBaseReport = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.saCaseBaseImport = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saCaseBaseReport
            // 
            this.saCaseBaseReport.Caption = "导出报表";
            this.saCaseBaseReport.Category = "RecordEdit";
            this.saCaseBaseReport.ConfirmationMessage = null;
            this.saCaseBaseReport.Id = "CaseBase.ExportReport";
            this.saCaseBaseReport.ImageName = "Action_Export_ToExcel";
            this.saCaseBaseReport.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.saCaseBaseReport.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.CaseBase);
            this.saCaseBaseReport.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.saCaseBaseReport.ToolTip = null;
            this.saCaseBaseReport.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.saCaseBaseReport.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saCaseBaseReport_Execute);
            // 
            // saCaseBaseImport
            // 
            this.saCaseBaseImport.Caption = "导入案件";
            this.saCaseBaseImport.Category = "RecordEdit";
            this.saCaseBaseImport.ConfirmationMessage = null;
            this.saCaseBaseImport.Id = "CaseBase.Import";
            this.saCaseBaseImport.ImageName = "Action_Edit";
            this.saCaseBaseImport.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.CaseBase);
            this.saCaseBaseImport.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.saCaseBaseImport.ToolTip = null;
            this.saCaseBaseImport.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.saCaseBaseImport.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saCaseBaseImport_Execute);
            // 
            // VCCaseBaseList
            // 
            this.Actions.Add(this.saCaseBaseReport);
            this.Actions.Add(this.saCaseBaseImport);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.CaseBase);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion
        private DevExpress.ExpressApp.Actions.SimpleAction saCaseBaseReport;
        private DevExpress.ExpressApp.Actions.SimpleAction saCaseBaseImport;
    }
}
