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
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace EastIPInternalInvoiceSystem.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VCListInternalInvoice : ViewController<ListView>
    {
        public VCListInternalInvoice()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void scaFilter_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            string sCondtion = null;
            if (e.SelectedChoiceActionItem.Data != null)
            {
                switch (e.SelectedChoiceActionItem.Data.ToString())
                {
                    case "1":
                        sCondtion = $"IsNullOrEmpty(InvoiceNo)";
                        break;
                    case "2":
                        sCondtion = $"IsNullOrEmpty(InternalNo)";
                        break;
                }
            }
            View.CollectionSource.SetCriteria("1", sCondtion);
        }
    }
}
