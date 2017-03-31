using System.Windows.Forms;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Security;
using EastIPInternalInvoiceSystem.Module.BusinessObjects;

namespace EastIPInternalInvoiceSystem.Module.Win.Controllers
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
            var frm = new XFrmImport(Frame.View.ObjectSpace);
            if (frm.ShowDialog() != DialogResult.OK) return;
            Frame.View.Refresh(true);
        }
    }
}