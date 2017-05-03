using DevExpress.ExpressApp;
using DevExpress.ExpressApp.FileAttachments.Win;
using DevExpress.ExpressApp.Win.SystemModule;

namespace EastIPSystem.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VCListViewInternalInvoice : ViewController
    {
        public VCListViewInternalInvoice()
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
            Frame.GetController<OpenObjectController>().OpenObjectAction.Active.SetItemValue("Common", false);
            Frame.GetController<FileAttachmentListViewController>().AddFromFileAction.Active.SetItemValue("Common", false);
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
