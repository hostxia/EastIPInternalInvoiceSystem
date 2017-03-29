namespace EastIPInternalInvoiceSystem.Module.Controllers
{
    partial class VCDetailInternalInvoice
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
            this.saGetCaseInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saGetCaseInfo
            // 
            this.saGetCaseInfo.Caption = "填充案件&相关信息";
            this.saGetCaseInfo.Category = "OpenObject";
            this.saGetCaseInfo.ConfirmationMessage = null;
            this.saGetCaseInfo.Id = "saGetCaseInfo";
            this.saGetCaseInfo.ImageName = "ActionGroup_EasyTestRecorder";
            this.saGetCaseInfo.Shortcut = "CtrlQ";
            this.saGetCaseInfo.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.saGetCaseInfo.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.saGetCaseInfo.ToolTip = null;
            this.saGetCaseInfo.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.saGetCaseInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saGetCaseInfo_Execute);
            // 
            // VCDetailInternalInvoice
            // 
            this.Actions.Add(this.saGetCaseInfo);
            this.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saGetCaseInfo;
    }
}
