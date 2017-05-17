using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    public partial class VCListInternalInvoice : ViewController<ListView>
    {
        public VCListInternalInvoice()
        {
            InitializeComponent();
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

        private void saGetCaseInfo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (InternalInvoice internalInvoice in e.SelectedObjects)
            {
                if (string.IsNullOrWhiteSpace(internalInvoice.OurNo)) continue;
                internalInvoice.SetCaseInfo(internalInvoice.OurNo);
                View.ObjectSpace.CommitChanges();
            }
        }
    }
}
