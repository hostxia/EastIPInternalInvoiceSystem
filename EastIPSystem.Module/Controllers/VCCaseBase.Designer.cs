using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    partial class VCCaseBase
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
            this.saGetCaseInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saGetCaseInfo
            // 
            this.saGetCaseInfo.Caption = "获取案件信息";
            this.saGetCaseInfo.Category = "RecordEdit";
            this.saGetCaseInfo.ConfirmationMessage = null;
            this.saGetCaseInfo.Id = "36dcd05d-efbe-46ad-a2f9-05c0928d51bc";
            this.saGetCaseInfo.ImageName = "ActionGroup_EasyTestRecorder";
            this.saGetCaseInfo.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.saGetCaseInfo.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.saGetCaseInfo.ToolTip = null;
            this.saGetCaseInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saGetCaseInfo_Execute);
            // 
            // VCCaseBase
            // 
            this.Actions.Add(this.saGetCaseInfo);
            this.TargetObjectType = typeof(CaseBase);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saGetCaseInfo;
    }
}
