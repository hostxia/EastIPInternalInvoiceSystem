using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Mobile;
using DevExpress.ExpressApp.Mobile.SystemModule;
using DevExpress.ExpressApp.Objects;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Validation;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using EastIPSystem.Module;
using EastIPSystem.Module.Mobile;

namespace EastIPSystem.Mobile
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    public class EastIPInternalInvoiceSystemMobileApplication : MobileApplication
    {
        private AuthenticationStandard authenticationStandard1;
        private SystemModule module1;
        private SystemMobileModule module2;
        private EastIPInternalInvoiceSystemModule module3;
        private EastIPInternalInvoiceSystemMobileModule module4;
        private BusinessClassLibraryCustomizationModule objectsModule;
        private SecurityModule securityModule1;
        private SecurityStrategyComplex securityStrategyComplex1;
        private DevExpress.ExpressApp.AuditTrail.AuditTrailModule auditTrailModule1;
        private DevExpress.ExpressApp.Dashboards.DashboardsModule dashboardsModule1;
        private ValidationModule validationModule;

        public EastIPInternalInvoiceSystemMobileApplication()
        {
            SecurityAdapterHelper.Enable();
            Tracing.Initialize();
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
                ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
#if EASYTEST
            if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
                ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
            }
#endif
            if (Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
                DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            InitializeComponent();
        }

        protected override void SetLogonParametersForUIBuilder(object logonParameters)
        {
            base.SetLogonParametersForUIBuilder(logonParameters);
            ((AuthenticationStandardLogonParameters) logonParameters).UserName = "Admin";
            ((AuthenticationStandardLogonParameters) logonParameters).Password = "";
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProvider = new SecuredObjectSpaceProvider((SecurityStrategyComplex) Security,
                GetDataStoreProvider(args.ConnectionString, args.Connection), true);
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }

        private IXpoDataStoreProvider GetDataStoreProvider(string connectionString, IDbConnection connection)
        {
            IXpoDataStoreProvider dataStoreProvider = null;
            if (!string.IsNullOrEmpty(connectionString))
                dataStoreProvider = new ConnectionStringDataStoreProvider(connectionString);
            else if (connection != null) dataStoreProvider = new ConnectionDataStoreProvider(connection);
            return dataStoreProvider;
        }

        private void EastIPInternalInvoiceSystemMobileApplication_DatabaseVersionMismatch(object sender,
            DatabaseVersionMismatchEventArgs e)
        {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if (Debugger.IsAttached)
            {
                e.Updater.Update();
                e.Handled = true;
            }
            else
            {
                var message = "The application cannot connect to the specified database, " +
                              "because the database doesn't exist, its version is older " +
                              "than that of the application or its schema does not match " +
                              "the ORM data model structure. To avoid this error, use one " +
                              "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

                if (e.CompatibilityError != null && e.CompatibilityError.Exception != null)
                    message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
                throw new InvalidOperationException(message);
            }
#endif
        }

        private void InitializeComponent()
        {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Mobile.SystemModule.SystemMobileModule();
            this.module3 = new EastIPSystemModule();
            this.module4 = new EastIPSystemMobileModule();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
            this.objectsModule = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.validationModule = new DevExpress.ExpressApp.Validation.ValidationModule();
            this.auditTrailModule1 = new DevExpress.ExpressApp.AuditTrail.AuditTrailModule();
            this.dashboardsModule1 = new DevExpress.ExpressApp.Dashboards.DashboardsModule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // securityStrategyComplex1
            // 
            this.securityStrategyComplex1.Authentication = this.authenticationStandard1;
            this.securityStrategyComplex1.RoleType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole);
            this.securityStrategyComplex1.UserType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser);
            // 
            // authenticationStandard1
            // 
            this.authenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
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
            // EastIPInternalInvoiceSystemMobileApplication
            // 
            this.ApplicationName = "EastIPInternalInvoiceSystem";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.securityModule1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.objectsModule);
            this.Modules.Add(this.validationModule);
            this.Modules.Add(this.auditTrailModule1);
            this.Modules.Add(this.dashboardsModule1);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.module4);
            this.Security = this.securityStrategyComplex1;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}