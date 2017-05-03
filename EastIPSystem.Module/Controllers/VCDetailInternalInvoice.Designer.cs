using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
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
            this.saGetCaseInfo = new DevExpress.ExpressApp.Actions.SimpleAction();
            this.saGenerateInternalNo = new DevExpress.ExpressApp.Actions.SimpleAction();
            // 
            // saGetCaseInfo
            // 
            this.saGetCaseInfo.Caption = "填充案件相关信息";
            this.saGetCaseInfo.Category = "OpenObject";
            this.saGetCaseInfo.ConfirmationMessage = null;
            this.saGetCaseInfo.Id = "saGetCaseInfo";
            this.saGetCaseInfo.ImageName = "ActionGroup_EasyTestRecorder";
            this.saGetCaseInfo.Shortcut = "CtrlQ";
            this.saGetCaseInfo.TargetObjectType = typeof(InternalInvoice);
            this.saGetCaseInfo.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.saGetCaseInfo.ToolTip = null;
            this.saGetCaseInfo.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.saGetCaseInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saGetCaseInfo_Execute);
            // 
            // saGenerateInternalNo
            // 
            this.saGenerateInternalNo.Caption = "生成草单编号";
            this.saGenerateInternalNo.Category = "OpenObject";
            this.saGenerateInternalNo.ConfirmationMessage = null;
            this.saGenerateInternalNo.Id = "saGenerateInternalNo";
            this.saGenerateInternalNo.ImageName = "BO_Task";
            this.saGenerateInternalNo.Shortcut = "CtrlW";
            this.saGenerateInternalNo.TargetObjectType = typeof(InternalInvoice);
            this.saGenerateInternalNo.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.saGenerateInternalNo.ToolTip = null;
            this.saGenerateInternalNo.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.saGenerateInternalNo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saGenerateInternalNo_Execute);
            // 
            // VCDetailInternalInvoice
            // 
            this.Actions.Add(this.saGetCaseInfo);
            this.Actions.Add(this.saGenerateInternalNo);
            this.TargetObjectType = typeof(InternalInvoice);
            this.TargetViewId = "InternalInvoice_DetailView";
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saGetCaseInfo;
        private DevExpress.ExpressApp.Actions.SimpleAction saGenerateInternalNo;
    }
}
