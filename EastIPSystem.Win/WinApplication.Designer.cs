using EastIPSystem.Module;
using EastIPSystem.Module.BusinessObjects;
using EastIPSystem.Module.Win;

namespace EastIPSystem.Win {
    partial class EastIPSystemWindowsFormsApplication {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
            this.objectsModule = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.validationModule = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.validationWindowsFormsModule = new DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule();
            this.fileAttachmentsWindowsFormsModule1 = new DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule();
            this.auditTrailModule1 = new DevExpress.ExpressApp.AuditTrail.AuditTrailModule();
            this.dashboardsWindowsFormsModule1 = new DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule();
            this.dashboardsModule1 = new DevExpress.ExpressApp.Dashboards.DashboardsModule();
            this.conditionalAppearanceModule1 = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
            this.stateMachineModule1 = new DevExpress.ExpressApp.StateMachine.StateMachineModule();
            this.notificationsWindowsFormsModule1 = new DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule();
            this.notificationsModule1 = new DevExpress.ExpressApp.Notifications.NotificationsModule();
            this.module3 = new EastIPSystem.Module.EastIPSystemModule();
            this.module4 = new EastIPSystem.Module.Win.EastIPSystemWindowsFormsModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // validationModule
            // 
            this.validationModule.AllowValidationDetailsAccess = true;
            this.validationModule.IgnoreWarningAndInformationRules = false;
            // 
            // auditTrailModule1
            // 
            this.auditTrailModule1.AuditDataItemPersistentType = typeof(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent);
            // 
            // dashboardsModule1
            // 
            this.dashboardsModule1.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.DashboardData);
            // 
            // stateMachineModule1
            // 
            this.stateMachineModule1.StateMachineStorageType = typeof(DevExpress.ExpressApp.StateMachine.Xpo.XpoStateMachine);
            // 
            // notificationsModule1
            // 
            this.notificationsModule1.CanAccessPostponedItems = true;
            this.notificationsModule1.NotificationsRefreshInterval = System.TimeSpan.Parse("00:05:00");
            this.notificationsModule1.NotificationsStartDelay = System.TimeSpan.Parse("00:00:05");
            this.notificationsModule1.ShowDismissAllAction = true;
            this.notificationsModule1.ShowNotificationsWindow = true;
            this.notificationsModule1.ShowRefreshAction = false;
            // 
            // securityStrategyComplex1
            // 
            this.securityStrategyComplex1.Authentication = this.authenticationStandard1;
            this.securityStrategyComplex1.RoleType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole);
            this.securityStrategyComplex1.SupportNavigationPermissionsForTypes = false;
            this.securityStrategyComplex1.UserType = typeof(EastIPSystem.Module.BusinessObjects.SysUser);
            // 
            // authenticationStandard1
            // 
            this.authenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
            // 
            // EastIPSystemWindowsFormsApplication
            // 
            this.ApplicationName = "EastIPInternalInvoiceSystem";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.objectsModule);
            this.Modules.Add(this.validationModule);
            this.Modules.Add(this.auditTrailModule1);
            this.Modules.Add(this.dashboardsModule1);
            this.Modules.Add(this.conditionalAppearanceModule1);
            this.Modules.Add(this.stateMachineModule1);
            this.Modules.Add(this.notificationsModule1);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.validationWindowsFormsModule);
            this.Modules.Add(this.fileAttachmentsWindowsFormsModule1);
            this.Modules.Add(this.module4);
            this.Modules.Add(this.securityModule1);
            this.Modules.Add(this.dashboardsWindowsFormsModule1);
            this.Modules.Add(this.notificationsWindowsFormsModule1);
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Localization.PreviewControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.GridControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.LayoutControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.NavBarControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.BarControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.DocumentManagerControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.DockManagerLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.RichEditControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.TreeListControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.VerticalGridControlLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.XtraEditorsLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Localization.LargeStringEditFindFormLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailViewFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainRibbonFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.OutlookStyleMainRibbonFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailRibbonFormV2TemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.NestedFrameTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.NestedFrameTemplateV2Localizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.LookupControlTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.PopupFormTemplateLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Security.ServerDataLogLocalizer));
            this.ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Dashboards.Win.DashboardControlLocalizer));
            this.Security = this.securityStrategyComplex1;
            this.UseOldTemplates = false;
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.EastIPSystemWindowsFormsApplication_DatabaseVersionMismatch);
            this.CustomizeLanguagesList += new System.EventHandler<DevExpress.ExpressApp.CustomizeLanguagesListEventArgs>(this.EastIPSystemWindowsFormsApplication_CustomizeLanguagesList);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
        private EastIPSystemModule module3;
        private EastIPSystemWindowsFormsModule module4;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
        private DevExpress.ExpressApp.Security.SecurityStrategyComplex securityStrategyComplex1;
        private DevExpress.ExpressApp.Security.AuthenticationStandard authenticationStandard1;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule objectsModule;
        private DevExpress.ExpressApp.Validation.ValidationModule validationModule;
        private DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule validationWindowsFormsModule;
        private DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule fileAttachmentsWindowsFormsModule1;
        private DevExpress.ExpressApp.AuditTrail.AuditTrailModule auditTrailModule1;
        private DevExpress.ExpressApp.Dashboards.Win.DashboardsWindowsFormsModule dashboardsWindowsFormsModule1;
        private DevExpress.ExpressApp.Dashboards.DashboardsModule dashboardsModule1;
        private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule1;
        private DevExpress.ExpressApp.StateMachine.StateMachineModule stateMachineModule1;
        private DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule notificationsWindowsFormsModule1;
        private DevExpress.ExpressApp.Notifications.NotificationsModule notificationsModule1;
    }
}
