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
    public partial class VCPatentBaseList : ViewController
    {
        public VCPatentBaseList()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            scaFilter.SelectedIndex = 0;
            Frame.GetController<FilterController>().FullTextFilterAction.Execute += FullTextFilterAction_Execute;
            ((ListView)View).CollectionSource.List.Cast<PatentBase>()
                .Where(
                    p => p.LastPatentProgress == null || p.LastPatentProgress.n_Item != EnumsAll.PatentProgressItem.已递交)
                .ToList()
                .ForEach(p =>
                {
                    if (SecuritySystem.IsGranted(ObjectSpace, p.GetType(), SecurityOperations.Write, p, "s_Name"))
                        p.GetDeadline();
                });
            Frame.GetController<FilterController>().FullTextFilterAction.DoExecute("");
        }

        private void FullTextFilterAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            if (scaFilter.SelectedItem != null)
            {
                switch (scaFilter.SelectedItem.Data.ToString())
                {
                    case "1":
                        ((ListView)View).CollectionSource.SetCriteria("Custom", $"LastPatentProgress Is Null Or LastPatentProgress.n_Item != {Convert.ToInt32(EnumsAll.PatentProgressItem.已递交)} And LastPatentProgress.n_Item != {Convert.ToInt32(EnumsAll.PatentProgressItem.指示放弃)}");
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
