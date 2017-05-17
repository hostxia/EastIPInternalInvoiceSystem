using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    public partial class VCPatentPaymentList : ViewController
    {
        public VCPatentPaymentList()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var sysUser = (SysUser)SecuritySystem.CurrentUser;
            Frame.GetController<ObjectMethodActionsViewController>().Actions["PatentPayment.SetPaid"].Active["Securty"] = sysUser.IsUserInRole("缴费提交人");
            scaPaymentFilter.SelectedIndex = 1;
            Frame.GetController<FilterController>().FullTextFilterAction.Execute += FullTextFilterAction_Execute; ;
        }

        private void FullTextFilterAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            if (scaPaymentFilter.SelectedItem != null)
            {
                switch (scaPaymentFilter.SelectedItem.Data.ToString())
                {
                    case "1":
                        ((ListView)View).CollectionSource.SetCriteria("Custom", $"dt_PaidDate Is Null");
                        break;
                    default:
                        ((ListView)View).CollectionSource.SetCriteria("Custom", null);
                        break;
                }
            }
            else
            {
                ((ListView)View).CollectionSource.SetCriteria("Custom", null);
            }
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
