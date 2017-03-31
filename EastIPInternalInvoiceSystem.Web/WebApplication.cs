using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Objects;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Validation;
using DevExpress.ExpressApp.Validation.Web;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using EastIPInternalInvoiceSystem.Module;
using EastIPInternalInvoiceSystem.Module.Web;

namespace EastIPInternalInvoiceSystem.Web
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    public class EastIPInternalInvoiceSystemAspNetApplication : WebApplication
    {
        private AuthenticationStandard authenticationStandard1;
        private SystemModule module1;
        private SystemAspNetModule module2;
        private EastIPInternalInvoiceSystemModule module3;
        private EastIPInternalInvoiceSystemAspNetModule module4;
        private BusinessClassLibraryCustomizationModule objectsModule;
        private SecurityModule securityModule1;
        private SecurityStrategyComplex securityStrategyComplex1;
        private ValidationAspNetModule validationAspNetModule;
        private ValidationModule validationModule;

        public EastIPInternalInvoiceSystemAspNetApplication()
        {
            InitializeComponent();
            LinkNewObjectToParentImmediately = false;
            ASPxGridListEditor.AllowFilterControlHierarchy = true;
            ASPxGridListEditor.MaxFilterControlHierarchyDepth = 3;
            ASPxCriteriaPropertyEditor.AllowFilterControlHierarchyDefault = true;
            ASPxCriteriaPropertyEditor.MaxHierarchyDepthDefault = 3;
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProvider = new SecuredObjectSpaceProvider((SecurityStrategyComplex) Security,
                GetDataStoreProvider(args.ConnectionString, args.Connection), true);
            args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
        }

        private IXpoDataStoreProvider GetDataStoreProvider(string connectionString, IDbConnection connection)
        {
            var application = HttpContext.Current != null ? HttpContext.Current.Application : null;
            IXpoDataStoreProvider dataStoreProvider = null;
            if (application != null && application["DataStoreProvider"] != null)
            {
                dataStoreProvider = application["DataStoreProvider"] as IXpoDataStoreProvider;
            }
            else
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    connectionString = XpoDefault.GetConnectionPoolString(connectionString);
                    dataStoreProvider = new ConnectionStringDataStoreProvider(connectionString, true);
                }
                else if (connection != null)
                {
                    dataStoreProvider = new ConnectionDataStoreProvider(connection);
                }
                if (application != null) application["DataStoreProvider"] = dataStoreProvider;
            }
            return dataStoreProvider;
        }

        private void EastIPInternalInvoiceSystemAspNetApplication_DatabaseVersionMismatch(object sender,
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
            module2 = new SystemAspNetModule();
            module3 = new EastIPInternalInvoiceSystemModule();
            module4 = new EastIPInternalInvoiceSystemAspNetModule();
            securityModule1 = new SecurityModule();
            securityStrategyComplex1 = new SecurityStrategyComplex();
            securityStrategyComplex1.SupportNavigationPermissionsForTypes = false;
            authenticationStandard1 = new AuthenticationStandard();
            objectsModule = new BusinessClassLibraryCustomizationModule();
            validationModule = new ValidationModule();
            validationAspNetModule = new ValidationAspNetModule();
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
            // EastIPInternalInvoiceSystemAspNetApplication
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
            Modules.Add(validationAspNetModule);
            DatabaseVersionMismatch += EastIPInternalInvoiceSystemAspNetApplication_DatabaseVersionMismatch;
            ((ISupportInitialize) this).EndInit();
        }
    }
}