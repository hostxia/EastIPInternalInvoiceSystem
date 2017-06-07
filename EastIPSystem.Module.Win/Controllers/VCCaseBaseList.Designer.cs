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
            this.pwsaCaseBaseReport = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // pwsaCaseBaseReport
            // 
            this.pwsaCaseBaseReport.AcceptButtonCaption = "导出";
            this.pwsaCaseBaseReport.ActionMeaning = DevExpress.ExpressApp.Actions.ActionMeaning.Accept;
            this.pwsaCaseBaseReport.CancelButtonCaption = "取消";
            this.pwsaCaseBaseReport.Caption = "导出报表";
            this.pwsaCaseBaseReport.Category = "RecordEdit";
            this.pwsaCaseBaseReport.ConfirmationMessage = null;
            this.pwsaCaseBaseReport.Id = "5a422c78-806c-4134-bfe2-b1a67f207b98";
            this.pwsaCaseBaseReport.ImageName = "Action_Chart_Printing_Preview";
            this.pwsaCaseBaseReport.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.CaseBase);
            this.pwsaCaseBaseReport.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.pwsaCaseBaseReport.ToolTip = null;
            this.pwsaCaseBaseReport.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.pwsaCaseBaseReport.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.pwsaCaseBaseReport_CustomizePopupWindowParams);
            this.pwsaCaseBaseReport.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.pwsaCaseBaseReport_Execute);
            // 
            // VCCaseBaseList
            // 
            this.Actions.Add(this.pwsaCaseBaseReport);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.CaseBase);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction pwsaCaseBaseReport;
    }
}
