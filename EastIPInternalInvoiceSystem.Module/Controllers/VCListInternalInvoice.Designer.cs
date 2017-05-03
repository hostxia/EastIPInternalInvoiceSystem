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
            this.components = new System.ComponentModel.Container();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem10 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem11 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem12 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.scaFilter = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            this.saListGetCaseInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // scaFilter
            // 
            this.scaFilter.Caption = "筛选";
            this.scaFilter.Category = "FullTextSearch";
            this.scaFilter.ConfirmationMessage = null;
            this.scaFilter.Id = "scaFilter";
            choiceActionItem10.Caption = "仅查询未开账单的数据";
            choiceActionItem10.Data = "1";
            choiceActionItem10.ImageName = null;
            choiceActionItem10.Shortcut = null;
            choiceActionItem10.ToolTip = null;
            choiceActionItem11.Caption = "仅查询未生成草单的数据";
            choiceActionItem11.Data = "2";
            choiceActionItem11.ImageName = null;
            choiceActionItem11.Shortcut = null;
            choiceActionItem11.ToolTip = null;
            choiceActionItem12.Caption = "所有数据";
            choiceActionItem12.Data = "0";
            choiceActionItem12.ImageName = null;
            choiceActionItem12.Shortcut = null;
            choiceActionItem12.ToolTip = null;
            this.scaFilter.Items.Add(choiceActionItem10);
            this.scaFilter.Items.Add(choiceActionItem11);
            this.scaFilter.Items.Add(choiceActionItem12);
            this.scaFilter.ToolTip = null;
            // 
            // saGetCaseInfo
            // 
            this.saListGetCaseInfo.Caption = "填充案件相关信息";
            this.saListGetCaseInfo.Category = "OpenObject";
            this.saListGetCaseInfo.ConfirmationMessage = null;
            this.saListGetCaseInfo.Id = "saListGetCaseInfo";
            this.saListGetCaseInfo.ImageName = "ActionGroup_EasyTestRecorder";
            this.saListGetCaseInfo.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.saListGetCaseInfo.Shortcut = "CtrlQ";
            this.saListGetCaseInfo.TargetObjectsCriteria = "";
            this.saListGetCaseInfo.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.saListGetCaseInfo.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.saListGetCaseInfo.ToolTip = null;
            this.saListGetCaseInfo.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.saListGetCaseInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saGetCaseInfo_Execute);
            // 
            // VCListInternalInvoice
            // 
            this.Actions.Add(this.scaFilter);
            this.Actions.Add(this.saListGetCaseInfo);
            this.TargetObjectType = typeof(EastIPInternalInvoiceSystem.Module.BusinessObjects.InternalInvoice);
            this.TargetViewId = "InternalInvoice_ListView";
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction scaFilter;
        private DevExpress.ExpressApp.Actions.SimpleAction saListGetCaseInfo;
    }
}
