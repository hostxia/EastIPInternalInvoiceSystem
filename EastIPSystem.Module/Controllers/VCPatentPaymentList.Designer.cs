namespace EastIPSystem.Module.Controllers
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.scaPaymentFilter = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // scaPaymentFilter
            // 
            this.scaPaymentFilter.Caption = "筛选";
            this.scaPaymentFilter.Category = "FullTextSearch";
            this.scaPaymentFilter.ConfirmationMessage = null;
            this.scaPaymentFilter.Id = "4251bd4e-f93c-4304-a9b0-caf1c2fab897";
            choiceActionItem1.Caption = "仅查询未缴数据";
            choiceActionItem1.Data = "1";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "所有数据";
            choiceActionItem2.Data = "2";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            this.scaPaymentFilter.Items.Add(choiceActionItem1);
            this.scaPaymentFilter.Items.Add(choiceActionItem2);
            this.scaPaymentFilter.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentPayment);
            this.scaPaymentFilter.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.scaPaymentFilter.ToolTip = null;
            this.scaPaymentFilter.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            // 
            // VCPatentPaymentList
            // 
            this.Actions.Add(this.scaPaymentFilter);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentPayment);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction scaPaymentFilter;
    }
}
