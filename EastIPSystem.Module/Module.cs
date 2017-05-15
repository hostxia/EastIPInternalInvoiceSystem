using System;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Notifications;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using EastIPSystem.Module.BusinessObjects;
using Updater = EastIPSystem.Module.DatabaseUpdate.Updater;

namespace EastIPSystem.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class EastIPSystemModule : ModuleBase
    {
        public EastIPSystemModule()
        {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new Updater(objectSpace, versionFromDB);
            return new[] { updater };
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
            application.LoggedOn += Application_LoggedOn;
        }

        private void Application_LoggedOn(object sender, LogonEventArgs e)
        {
            Application.Modules.FindModule<NotificationsModule>().DefaultNotificationsProvider.CustomizeNotificationCollectionCriteria += DefaultNotificationsProvider_CustomizeNotificationCollectionCriteria;
        }

        private void DefaultNotificationsProvider_CustomizeNotificationCollectionCriteria(object sender, DevExpress.Persistent.Base.General.CustomizeCollectionCriteriaEventArgs e)
        {
            if (e.Type == typeof(CaseExtension))
            {
                if (((SysUser)SecuritySystem.CurrentUser).IsUserInRole("延期请求人"))
                {
                    e.Criteria = CriteriaOperator.Or(e.Criteria, CriteriaOperator.Parse("(Owner.Oid = CurrentUserId() Or Creator.Oid = CurrentUserId()) And (n_State = ? Or n_State = ?)", EnumsAll.CaseExtensionState.修改延期未通过, EnumsAll.CaseExtensionState.部门审核未通过));
                }
                if (((SysUser)SecuritySystem.CurrentUser).IsUserInRole("延期批准人"))
                {
                    e.Criteria = CriteriaOperator.Or(e.Criteria, CriteriaOperator.Parse("n_State = ?", EnumsAll.CaseExtensionState.部门审核));
                }
                if (((SysUser)SecuritySystem.CurrentUser).IsUserInRole("延期审核人"))
                {
                    e.Criteria = CriteriaOperator.Or(e.Criteria, CriteriaOperator.Parse("n_State = ?", EnumsAll.CaseExtensionState.修改延期));
                }
                if (!((SysUser)SecuritySystem.CurrentUser).IsUserInRole("延期审核人") &&
                    !((SysUser)SecuritySystem.CurrentUser).IsUserInRole("延期批准人") &&
                    !((SysUser)SecuritySystem.CurrentUser).IsUserInRole("延期请求人"))
                {
                    e.Criteria = CriteriaOperator.Parse("1=0");
                }
            }
        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }
    }
}