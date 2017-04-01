namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
{
    partial class VCImportFile
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
            this.saImportFile = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saImportFile
            // 
            this.saImportFile.Caption = "导入电子件";
            this.saImportFile.Category = "Edit";
            this.saImportFile.ConfirmationMessage = null;
            this.saImportFile.Id = "saImportFile";
            this.saImportFile.ImageName = "BO_FileAttachment";
            this.saImportFile.Shortcut = "CtrlW";
            this.saImportFile.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.saImportFile.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.saImportFile.ToolTip = null;
            this.saImportFile.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.saImportFile.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saImportFile_Execute);
            // 
            // VCImportFile
            // 
            this.Actions.Add(this.saImportFile);
            this.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saImportFile;
    }
}
