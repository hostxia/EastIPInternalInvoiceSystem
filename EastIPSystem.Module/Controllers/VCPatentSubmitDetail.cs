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
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    public partial class VCPatentSubmitDetail : ViewController
    {
        public VCPatentSubmitDetail()
        {
            InitializeComponent();
        }

        private void saSubmitListGetCaseInfo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var patentSubmitList = e.CurrentObject as PatentSubmitList;
            patentSubmitList?.SetCaseInfo(patentSubmitList?.s_OurNo);
        }

        private void pwsaOpenInternalInvoice_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var patentSubmitList = View.CurrentObject as PatentSubmitList;
            if (patentSubmitList?.InternalInvoice == null) return;
            var objectSpace = Application.CreateObjectSpace();
            var internalInvoice = objectSpace.GetObjectByKey<InternalInvoice>(patentSubmitList.InternalInvoice.Oid);
            e.Context = TemplateContext.View;
            e.View = Application.CreateDetailView(objectSpace, internalInvoice);
        }
    }
}
