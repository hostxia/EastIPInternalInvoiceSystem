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
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VCPatentBase : ViewController
    {
        public VCPatentBase()
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
            if (View is DetailView)
            {
                if (Frame.GetController<ObjectMethodActionsViewController>().Actions["PatentBase.GetPatentInfo"] != null)
                    Frame.GetController<ObjectMethodActionsViewController>().Actions["PatentBase.GetPatentInfo"].Active
                        .SetItemValue("Security", SecuritySystem.IsGranted(View.ObjectSpace, typeof(PatentBase),
                                            SecurityOperations.Write, View.CurrentObject, "s_Name"));
            }
            View.SelectionChanged += View_SelectionChanged;
        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
            if (Frame.GetController<ObjectMethodActionsViewController>().Actions["PatentBase.GetPatentInfo"] != null)
                Frame.GetController<ObjectMethodActionsViewController>().Actions["PatentBase.GetPatentInfo"].Active
                    .SetItemValue("Security",
                        View.SelectedObjects.Cast<PatentBase>()
                            .All(
                                p =>
                                    SecuritySystem.IsGranted(View.ObjectSpace, typeof(PatentBase),
                                        SecurityOperations.Write, p, "s_Name")));
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
