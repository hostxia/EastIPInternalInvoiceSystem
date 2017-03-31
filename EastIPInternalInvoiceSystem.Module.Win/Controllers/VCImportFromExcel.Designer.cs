namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
{
    partial class VCImportFromExcel
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
            this.saImportData = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saImportData
            // 
            this.saImportData.Caption = "导入草单";
            this.saImportData.Category = "ObjectsCreation";
            this.saImportData.ConfirmationMessage = null;
            this.saImportData.Id = "saImportData";
            this.saImportData.ImageName = "Action_Copy";
            this.saImportData.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.saImportData.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.saImportData.ToolTip = null;
            this.saImportData.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.saImportData.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saImportData_Execute);
            // 
            // VCImportFromExcel
            // 
            this.Actions.Add(this.saImportData);
            this.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saImportData;
    }
}
