namespace EastIPSystem.Module.Win.Controllers
{
    partial class VCFileOfficialList
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
            this.saOfficialFileImport = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.saGenerateOutFile = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saOfficialFileImport
            // 
            this.saOfficialFileImport.Caption = "导入官文";
            this.saOfficialFileImport.Category = "RecordEdit";
            this.saOfficialFileImport.ConfirmationMessage = null;
            this.saOfficialFileImport.Id = "505d6d44-296a-4afc-92e8-4d46659f29c4";
            this.saOfficialFileImport.ImageName = "Action_ModelDifferences_Create";
            this.saOfficialFileImport.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.FileInOfficial);
            this.saOfficialFileImport.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.saOfficialFileImport.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.saOfficialFileImport.ToolTip = null;
            this.saOfficialFileImport.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.saOfficialFileImport.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saOfficialFileImport_Execute);
            // 
            // saGenerateOutFile
            // 
            this.saGenerateOutFile.Caption = "生成转文信";
            this.saGenerateOutFile.Category = "RecordEdit";
            this.saGenerateOutFile.ConfirmationMessage = null;
            this.saGenerateOutFile.Id = "eaf9dbd0-8084-491c-875b-d670453c2c75";
            this.saGenerateOutFile.ImageName = "Action_Edit";
            this.saGenerateOutFile.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.FileInOfficial);
            this.saGenerateOutFile.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.saGenerateOutFile.ToolTip = null;
            this.saGenerateOutFile.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saGenerateOutFile_Execute);
            // 
            // VCFileOfficialList
            // 
            this.Actions.Add(this.saOfficialFileImport);
            this.Actions.Add(this.saGenerateOutFile);
            this.TargetObjectType = typeof(EastIPSystem.Module.BusinessObjects.FileInOfficial);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saOfficialFileImport;
        private DevExpress.ExpressApp.Actions.SimpleAction saGenerateOutFile;
    }
}
