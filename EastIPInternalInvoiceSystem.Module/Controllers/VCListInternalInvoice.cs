using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Filtering;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
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
            scaFilter.SelectedIndex = 2;
            Frame.GetController<FilterController>().FullTextSearchTargetPropertiesMode = FullTextSearchTargetPropertiesMode.VisibleColumns;
            Frame.GetController<FilterController>().FullTextFilterAction.Execute += FullTextFilterAction_Execute;
            // Access and customize the target View control.
        }

        private void FullTextFilterAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            if (scaFilter.SelectedItem != null)
            {
                switch (scaFilter.SelectedItem.Data.ToString())
                {
                    case "1":
                        View.CollectionSource.SetCriteria("Custom", $"IsNullOrEmpty(InvoiceNo) And NoNeedInvoice = False");
                        break;
                    case "2":
                        View.CollectionSource.SetCriteria("Custom", $"IsNullOrEmpty(InternalNo)");
                        break;
                    default:
                        View.CollectionSource.SetCriteria("Custom", null);
                        break;
                }
            }
            else
            {
                View.CollectionSource.SetCriteria("Custom", null);
            }

        }
    }
}
