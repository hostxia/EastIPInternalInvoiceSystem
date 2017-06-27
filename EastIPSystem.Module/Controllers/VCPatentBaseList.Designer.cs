namespace EastIPSystem.Module.Controllers
{
    partial class VCPatentBaseList
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
            this.scaFilter = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // scaFilter
            // 
            this.scaFilter.Caption = "筛选";
            this.scaFilter.Category = "FullTextSearch";
            this.scaFilter.ConfirmationMessage = null;
            this.scaFilter.Id = "baa8a9d8-1ce7-44e0-bfea-d918cd46e55d";
            choiceActionItem1.Caption = "仅查询未完成的案件";
            choiceActionItem1.Data = "1";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "所有数据";
            choiceActionItem2.Data = "2";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            this.scaFilter.Items.Add(choiceActionItem1);
            this.scaFilter.Items.Add(choiceActionItem2);
            this.scaFilter.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentBase);
            this.scaFilter.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.scaFilter.ToolTip = null;
            this.scaFilter.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            // 
            // VCPatentBaseList
            // 
            this.Actions.Add(this.scaFilter);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentBase);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction scaFilter;
    }
}
