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
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraEditors;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class VCPatentSubmitDetail : ViewController<DetailView>
    {
        public VCPatentSubmitDetail()
        {
            InitializeComponent();
        }
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
