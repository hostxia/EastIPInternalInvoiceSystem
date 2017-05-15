namespace EastIPSystem.Module.Controllers
{
    partial class VCPatentPaymentDetail
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
            this.saGetInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.saClone = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saGetInfo
            // 
            this.saGetInfo.Caption = "获取相关信息";
            this.saGetInfo.Category = "OpenObject";
            this.saGetInfo.ConfirmationMessage = null;
            this.saGetInfo.Id = "296d6fc4-900d-47e4-bcbe-b4dc856b1de9";
            this.saGetInfo.ImageName = "ActionGroup_EasyTestRecorder";
            this.saGetInfo.Shortcut = "CtrlB";
            this.saGetInfo.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentPayment);
            this.saGetInfo.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.saGetInfo.ToolTip = null;
            this.saGetInfo.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            // 
            // saClone
            // 
            this.saClone.Caption = "保存并克隆";
            this.saClone.Category = "Save";
            this.saClone.ConfirmationMessage = null;
            this.saClone.Id = "55023886-a30e-4326-8b76-92dbfd9e9a74";
            this.saClone.ImageName = "Action_ModelDifferences_Export";
            this.saClone.Shortcut = "CtrlW";
            this.saClone.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentPayment);
            this.saClone.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.saClone.ToolTip = null;
            this.saClone.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.saClone.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saClone_Execute);
            // 
            // VCPatentPaymentDetail
            // 
            this.Actions.Add(this.saGetInfo);
            this.Actions.Add(this.saClone);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.PatentPayment);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saGetInfo;
        private DevExpress.ExpressApp.Actions.SimpleAction saClone;
    }
}
