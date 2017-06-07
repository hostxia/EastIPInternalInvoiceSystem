namespace EastIPSystem.Module.Controllers
{
    partial class VCPatentSubmitDetail
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
            this.saSubmitListGetCaseInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.pwsaOpenInternalInvoice = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // saSubmitListGetCaseInfo
            // 
            this.saSubmitListGetCaseInfo.Caption = "获取信息";
            this.saSubmitListGetCaseInfo.Category = "RecordEdit";
            this.saSubmitListGetCaseInfo.ConfirmationMessage = null;
            this.saSubmitListGetCaseInfo.Id = "0a653a06-3204-4330-a176-2d8ead20b4bc";
            this.saSubmitListGetCaseInfo.ImageName = "ActionGroup_EasyTestRecorder";
            this.saSubmitListGetCaseInfo.Shortcut = "CtrlB";
            this.saSubmitListGetCaseInfo.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentSubmitList);
            this.saSubmitListGetCaseInfo.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.saSubmitListGetCaseInfo.ToolTip = null;
            this.saSubmitListGetCaseInfo.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.saSubmitListGetCaseInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saSubmitListGetCaseInfo_Execute);
            // 
            // pwsaOpenInternalInvoice
            // 
            this.pwsaOpenInternalInvoice.AcceptButtonCaption = null;
            this.pwsaOpenInternalInvoice.CancelButtonCaption = null;
            this.pwsaOpenInternalInvoice.Caption = "打开草单";
            this.pwsaOpenInternalInvoice.Category = "RecordEdit";
            this.pwsaOpenInternalInvoice.ConfirmationMessage = null;
            this.pwsaOpenInternalInvoice.Id = "c2f69bdd-1658-47c7-9619-4ec77bca74ff";
            this.pwsaOpenInternalInvoice.ImageName = "BO_Invoice";
            this.pwsaOpenInternalInvoice.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentSubmitList);
            this.pwsaOpenInternalInvoice.ToolTip = null;
            this.pwsaOpenInternalInvoice.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.pwsaOpenInternalInvoice_CustomizePopupWindowParams);
            // 
            // VCPatentSubmitDetail
            // 
            this.Actions.Add(this.saSubmitListGetCaseInfo);
            this.Actions.Add(this.pwsaOpenInternalInvoice);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentSubmitList);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saSubmitListGetCaseInfo;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction pwsaOpenInternalInvoice;
    }
}
