using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using EastIPInternalInvoiceSystem.Module.BusinessObjects;

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
            saGetCaseInfo.Active.SetItemValue("Security",
                ((PropertyEditor) ((CompositeView) View).FindItem("OurNo")).AllowEdit);
            saGenerateInternalNo.Active.SetItemValue("Security", string.IsNullOrWhiteSpace(_internalInvoice.InternalNo));
            ((PropertyEditor) ((CompositeView) View).FindItem("FirmNo")).AllowEdit.SetItemValue(string.Empty,
                _internalInvoice.IsFAgencyInvoice);
            ((PropertyEditor) ((CompositeView) View).FindItem("IsFAgencyInvoice")).ControlValueChanged +=
                VCDetailInternalInvoice_ControlValueChanged;
            ((PropertyEditor) ((CompositeView) View).FindItem("InvoiceNo")).ControlValueChanged +=
                VCDetailInternalInvoice_ControlValueChanged1;
            // Access and customize the target View control.
        }

        private void VCDetailInternalInvoice_ControlValueChanged1(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(((PropertyEditor) ((CompositeView) View).FindItem("InvoiceLogDate")).ControlValue) ==
                DateTime.MinValue)
            {
                ((PropertyEditor) ((CompositeView) View).FindItem("InvoiceLogDate")).PropertyValue = DateTime.Now;
                ((PropertyEditor) ((CompositeView) View).FindItem("InvoiceLogDate")).ReadValue();
            }
        }

        private void VCDetailInternalInvoice_ControlValueChanged(object sender, EventArgs e)
        {
            var value = ((PropertyEditor) ((CompositeView) View).FindItem("IsFAgencyInvoice")).ControlValue;
            ((PropertyEditor) ((CompositeView) View).FindItem("FirmNo")).AllowEdit.SetItemValue(string.Empty,
                value != null && value.ToString().ToLower() == "true");
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void saGetCaseInfo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var objOurNo = ((PropertyEditor) ((CompositeView) View).FindItem("OurNo")).PropertyValue;
            if (string.IsNullOrWhiteSpace(objOurNo?.ToString())) return;
            _internalInvoice.SetCaseInfo(objOurNo.ToString());
            ((PropertyEditor) ((CompositeView) View).FindItem("ClientNo")).ReadValue();
            ((PropertyEditor) ((CompositeView) View).FindItem("ClientName")).ReadValue();
            ((PropertyEditor) ((CompositeView) View).FindItem("AppName")).ReadValue();
            ((PropertyEditor) ((CompositeView) View).FindItem("AppNo")).ReadValue();
        }

        private void saGenerateInternalNo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            _internalInvoice.GenerateInternalNo();
            ((PropertyEditor) ((CompositeView) View).FindItem("InternalNo")).ReadValue();
            ((PropertyEditor) ((CompositeView) View).FindItem("PermissionPolicyUser")).ReadValue();
        }
    }
}