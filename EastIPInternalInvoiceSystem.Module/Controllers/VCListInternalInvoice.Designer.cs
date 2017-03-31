namespace EastIPInternalInvoiceSystem.Module.Controllers
{
    partial class VCListInternalInvoice
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem3 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.scaFilter = new DevExpress.ExpressApp.Actions.SingleChoiceAction();
            // 
            // scaFilter
            // 
            this.scaFilter.Caption = "筛选";
            this.scaFilter.Category = "Filters";
            this.scaFilter.ConfirmationMessage = null;
            this.scaFilter.Id = "scaFilter";
            choiceActionItem1.Caption = "未开账单";
            choiceActionItem1.Data = "1";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "未生成草单";
            choiceActionItem2.Data = "2";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            choiceActionItem3.Caption = "所有";
            choiceActionItem3.Data = "0";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            this.scaFilter.Items.Add(choiceActionItem1);
            this.scaFilter.Items.Add(choiceActionItem2);
            this.scaFilter.Items.Add(choiceActionItem3);
            this.scaFilter.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsMode;
            this.scaFilter.ToolTip = null;
            this.scaFilter.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.scaFilter_Execute);
            // 
            // VCListInternalInvoice
            // 
            this.Actions.Add(this.scaFilter);
            this.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction scaFilter;
    }
}
