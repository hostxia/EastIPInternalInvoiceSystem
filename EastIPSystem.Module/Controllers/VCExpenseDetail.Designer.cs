namespace EastIPSystem.Module.Controllers
{
    partial class VCExpenseDetail
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
            this.saExpenseClone = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saExpenseClone
            // 
            this.saExpenseClone.Caption = "保存并克隆";
            this.saExpenseClone.Category = "Save";
            this.saExpenseClone.ConfirmationMessage = null;
            this.saExpenseClone.Id = "e4a098bb-c4e9-48cd-b39f-39b8d72a076e";
            this.saExpenseClone.ImageName = "Action_ModelDifferences_Export";
            this.saExpenseClone.Shortcut = "CtrlW";
            this.saExpenseClone.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.Expense);
            this.saExpenseClone.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.saExpenseClone.ToolTip = null;
            this.saExpenseClone.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.saExpenseClone.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saExpenseClone_Execute);
            // 
            // VCExpenseDetail
            // 
            this.Actions.Add(this.saExpenseClone);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.Expense);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saExpenseClone;
    }
}
