using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Security;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class VCImportFromExcel : ViewController
    {
        public VCImportFromExcel()
        {
            InitializeComponent();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            saImportData.Active.SetItemValue("Security",
                SecuritySystem.IsGranted(View.ObjectSpace, typeof(InternalInvoice), SecurityOperations.Create, null,
                    null));
        }

        private void saImportData_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            new XFrmImport(Frame.View.ObjectSpace, XFrmImport.FormType.Invoice).Show();
        }
    }
}