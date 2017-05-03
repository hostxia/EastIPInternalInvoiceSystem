namespace EastIPInternalInvoiceSystem.Module.Controllers
{
    partial class VCCaseExtension
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
            this.saGetExtensionCaseInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saGetExtensionCaseInfo
            // 
            this.saGetExtensionCaseInfo.Caption = "填充案件相关信息";
            this.saGetExtensionCaseInfo.Category = "OpenObject";
            this.saGetExtensionCaseInfo.ConfirmationMessage = null;
            this.saGetExtensionCaseInfo.Id = "0221c717-f63b-40de-86a6-24c70f2f3019";
            this.saGetExtensionCaseInfo.ImageName = "ActionGroup_EasyTestRecorder";
            this.saGetExtensionCaseInfo.Shortcut = "CtrlQ";
            this.saGetExtensionCaseInfo.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.CaseExtension);
            this.saGetExtensionCaseInfo.ToolTip = null;
            this.saGetExtensionCaseInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saGetExtensionCaseInfo_Execute);
            // 
            // VCCaseExtension
            // 
            this.Actions.Add(this.saGetExtensionCaseInfo);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saGetExtensionCaseInfo;
    }
}
