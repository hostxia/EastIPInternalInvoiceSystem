using System;
using System.ComponentModel;
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
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using EastIPInternalInvoiceSystem.Module;
using EastIPInternalInvoiceSystem.Module.Mobile;

namespace EastIPInternalInvoiceSystem.Mobile
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
            module1 = new SystemModule();
            module2 = new SystemMobileModule();
            module3 = new EastIPInternalInvoiceSystemModule();
            module4 = new EastIPInternalInvoiceSystemMobileModule();
            securityModule1 = new SecurityModule();
            securityStrategyComplex1 = new SecurityStrategyComplex();
            authenticationStandard1 = new AuthenticationStandard();
            objectsModule = new BusinessClassLibraryCustomizationModule();
            validationModule = new ValidationModule();
            ((ISupportInitialize) this).BeginInit();
            // 
            // securityStrategyComplex1
            // 
            securityStrategyComplex1.Authentication = authenticationStandard1;
            securityStrategyComplex1.RoleType = typeof(PermissionPolicyRole);
            securityStrategyComplex1.UserType = typeof(PermissionPolicyUser);
            // 
            // securityModule1
            // 
            securityModule1.UserType = typeof(PermissionPolicyUser);
            // 
            // authenticationStandard1
            // 
            authenticationStandard1.LogonParametersType = typeof(AuthenticationStandardLogonParameters);
            //
            // validationModule
            //
            validationModule.AllowValidationDetailsAccess = true;
            // 
            // EastIPInternalInvoiceSystemMobileApplication
            // 
            ApplicationName = "EastIPInternalInvoiceSystem";
            CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema;
            Modules.Add(module1);
            Modules.Add(module2);
            Modules.Add(module3);
            Modules.Add(module4);
            Modules.Add(securityModule1);
            Security = securityStrategyComplex1;
            Modules.Add(objectsModule);
            Modules.Add(validationModule);
            DatabaseVersionMismatch += EastIPInternalInvoiceSystemMobileApplication_DatabaseVersionMismatch;
            ((ISupportInitialize) this).EndInit();
        }
    }
}