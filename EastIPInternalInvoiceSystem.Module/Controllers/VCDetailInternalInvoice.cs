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
using EastIPInternalInvoiceSystem.Module.BusinessObjects;
using EastIPReportClient.DBUtility;

namespace EastIPInternalInvoiceSystem.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VCDetailInternalInvoice : ViewController
    {
        private InternalInvoice _internalInvoice;
        public VCDetailInternalInvoice()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            _internalInvoice = View.CurrentObject as InternalInvoice;
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            saGetCaseInfo.Active.SetItemValue("Security", ((PropertyEditor)((CompositeView)View).FindItem("OurNo")).AllowEdit);
            ((PropertyEditor)((CompositeView)View).FindItem("FirmNo")).AllowEdit.SetItemValue(string.Empty, _internalInvoice.IsFAgencyInvoice);
            ((PropertyEditor)((CompositeView)View).FindItem("IsFAgencyInvoice")).ControlValueChanged += VCDetailInternalInvoice_ControlValueChanged;
            // Access and customize the target View control.
        }

        private void VCDetailInternalInvoice_ControlValueChanged(object sender, EventArgs e)
        {
            var value = ((PropertyEditor)((CompositeView)View).FindItem("IsFAgencyInvoice")).ControlValue;
            ((PropertyEditor)((CompositeView)View).FindItem("FirmNo")).AllowEdit.SetItemValue(string.Empty, value != null && value.ToString().ToLower() == "true");
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void saGetCaseInfo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var objOurNo = ((PropertyEditor)((CompositeView)View).FindItem("OurNo")).PropertyValue;
            if (string.IsNullOrWhiteSpace(objOurNo?.ToString())) return;
            try
            {
                var dtResult = DbHelperOra.Query(
                      $"select client,client_name,appl_code1,applicant_ch1 from patentcase where ourno = '{objOurNo.ToString().Replace("'", "''")}'").Tables[0];
                if (dtResult.Rows.Count > 0)
                {
                    ((PropertyEditor)((CompositeView)View).FindItem("ClientNo")).PropertyValue =
                        dtResult.Rows[0]["client"].ToString();
                    ((PropertyEditor)((CompositeView)View).FindItem("ClientNo")).ReadValue();
                    ((PropertyEditor)((CompositeView)View).FindItem("ClientName")).PropertyValue =
                        dtResult.Rows[0]["client_name"].ToString();
                    ((PropertyEditor)((CompositeView)View).FindItem("ClientName")).ReadValue();
                    ((PropertyEditor)((CompositeView)View).FindItem("AppName")).PropertyValue =
                        dtResult.Rows[0]["applicant_ch1"].ToString();
                    ((PropertyEditor)((CompositeView)View).FindItem("AppName")).ReadValue();
                    ((PropertyEditor)((CompositeView)View).FindItem("AppNo")).PropertyValue =
                        dtResult.Rows[0]["appl_code1"].ToString();
                    ((PropertyEditor)((CompositeView)View).FindItem("AppNo")).ReadValue();
                }
                else
                {
                    var dtFResult = DbHelperOra.Query(
      $"select eid,role,orig_name from fcase_ent_rel where ourno = '{objOurNo.ToString().Replace("'", "''")}' order by ent_order asc").Tables[0];
                    if (dtFResult.Rows.Count > 0)
                    {
                        var drsClient = dtFResult.Select("role = 'CLI' or role = 'APPCLI'");
                        var drsApp = dtFResult.Select("role = 'APP' or role = 'APPCLI'");
                        ((PropertyEditor)((CompositeView)View).FindItem("ClientNo")).PropertyValue = drsClient[0]?["eid"].ToString();
                        ((PropertyEditor)((CompositeView)View).FindItem("ClientNo")).ReadValue();
                        ((PropertyEditor)((CompositeView)View).FindItem("ClientName")).PropertyValue = drsClient[0]?["orig_name"].ToString();
                        ((PropertyEditor)((CompositeView)View).FindItem("ClientName")).ReadValue();
                        ((PropertyEditor)((CompositeView)View).FindItem("AppName")).PropertyValue = drsApp[0]?["orig_name"].ToString();
                        ((PropertyEditor)((CompositeView)View).FindItem("AppName")).ReadValue();
                        ((PropertyEditor)((CompositeView)View).FindItem("AppNo")).PropertyValue = drsApp[0]?["eid"].ToString();
                        ((PropertyEditor)((CompositeView)View).FindItem("AppNo")).ReadValue();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
