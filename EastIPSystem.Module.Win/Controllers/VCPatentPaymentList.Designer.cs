namespace EastIPSystem.Module.Win.Controllers
{
    partial class VCPatentPaymentList
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
            this.saExportPaymentList = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saExportPaymentList
            // 
            this.saExportPaymentList.Caption = "生成缴费清单";
            this.saExportPaymentList.Category = "OpenObject";
            this.saExportPaymentList.ConfirmationMessage = null;
            this.saExportPaymentList.Id = "b11f4f9e-aa9c-4dfa-bbef-d5a066b2a25a";
            this.saExportPaymentList.ImageName = "Action_Export_ToExcel";
            this.saExportPaymentList.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.saExportPaymentList.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentPayment);
            this.saExportPaymentList.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.saExportPaymentList.ToolTip = null;
            this.saExportPaymentList.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            // 
            // VCPatentPaymentList
            // 
            this.Actions.Add(this.saExportPaymentList);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentPayment);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saExportPaymentList;
    }
}
