using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.XtraEditors;

namespace EastIPSystem.Module.Win.Controllers
{
    public class VCDetailForeignInvoice : ViewController<DetailView>
    {
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            View.Items.Where(i => i.Control is MRUEdit).ToList().ForEach(i =>
            {
                XafDataView xpDataView = ObjectSpace.CreateDataView(i.ObjectType, i.Id, null, null) as XafDataView;
                if (xpDataView != null)
                    ((MRUEdit)i.Control).Properties.Items.AddRange(xpDataView.Cast<XpoDataViewRecord>().Where(r => r[i.Id] != null && !string.IsNullOrWhiteSpace(r[i.Id].ToString())).Select(r => r[i.Id]).Distinct().ToList());
            });

        }
    }
}