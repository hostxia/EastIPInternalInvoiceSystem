using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    public partial class VCPatentPaymentDetail : ViewController
    {
        public VCPatentPaymentDetail()
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
            Frame.GetController<NewObjectViewController>().ObjectCreated += VCPatentPaymentDetail_ObjectCreated;
            Frame.GetController<ObjectMethodActionsViewController>().Actions["PatentPayment.SetPaid"].Active.SetItemValue("Security", ((PropertyEditor)((CompositeView)View).FindItem("dt_PaidDate")).AllowEdit);
            saGetInfo.Execute += SaGetInfo_Execute;
            ((PropertyEditor)((CompositeView)View).FindItem("n_PatentType")).ControlValueChanged += VCPatentPaymentDetail_ControlValueChanged;
            ((PropertyEditor)((CompositeView)View).FindItem("n_PayCaseType")).ControlValueChanged += VCPatentPaymentDetail_ControlValueChanged;
            ((PropertyEditor)((CompositeView)View).FindItem("s_FeeName")).ControlValueChanged += FeeName_ControlValueChanged;
            var payment = View.CurrentObject as PatentPayment;
            if (payment == null) return;
            View.Model.AsObjectView.ModelClass.FindMember("s_FeeName").PredefinedValues = string.Join(";", PatentPaymentCodeCollection.GetPatentPaymentCodes(payment.n_PayCaseType, payment.n_PatentType).Select(p => p.FeeName));
            View.SaveModel();
        }

        private void FeeName_ControlValueChanged(object sender, EventArgs e)
        {
            var payment = View.CurrentObject as PatentPayment;
            if (payment == null) return;
            var paymentcode = PatentPaymentCodeCollection.GetPatentPaymentCodes(payment.n_PayCaseType, payment.n_PatentType).FirstOrDefault(p => p.FeeName == ((PropertyEditor)((CompositeView)View).FindItem("s_FeeName")).ControlValue.ToString());
            ((PropertyEditor)((CompositeView)View).FindItem("n_Amount")).PropertyValue = paymentcode?.Amount ?? 0;
            ((PropertyEditor)((CompositeView)View).FindItem("n_Amount")).ReadValue();
        }

        private void VCPatentPaymentDetail_ControlValueChanged(object sender, EventArgs e)
        {
            var payment = View.CurrentObject as PatentPayment;
            if (payment == null) return;
            ((PropertyEditor)((CompositeView)View).FindItem("n_PatentType")).WriteValue();
            ((PropertyEditor)((CompositeView)View).FindItem("n_PayCaseType")).WriteValue();
            View.Model.AsObjectView.ModelClass.FindMember("s_FeeName").PredefinedValues = string.Join(";", PatentPaymentCodeCollection.GetPatentPaymentCodes(payment.n_PayCaseType, payment.n_PatentType).Select(p => p.FeeName));
            View.SaveModel();
            payment.s_FeeName = string.Empty;
            payment.n_Amount = 0;
        }

        private void SaGetInfo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var payment = View.CurrentObject as PatentPayment;
            if (payment == null) return;
            ((PropertyEditor)((CompositeView)View).FindItem("s_OurNo")).WriteValue();
            payment.GetInfo();
            VCPatentPaymentDetail_ControlValueChanged(null, null);
        }

        private void saClone_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Frame.GetController<ModificationsController>().SaveAndNewAction.DoExecute(Frame.GetController<NewObjectViewController>().NewObjectAction.SelectedItem);
        }

        private void VCPatentPaymentDetail_ObjectCreated(object sender, ObjectCreatedEventArgs e)
        {
            var payment = View.CurrentObject as PatentPayment;
            if (payment == null) return;
            if (!(e.CreatedObject is PatentPayment)) return;
            ((PatentPayment)e.CreatedObject).s_OurNo = payment.s_OurNo;
            ((PatentPayment)e.CreatedObject).s_AppNo = payment.s_AppNo;
            ((PatentPayment)e.CreatedObject).s_Applicant = payment.s_Applicant;
            ((PatentPayment)e.CreatedObject).s_ApplicantNo = payment.s_ApplicantNo;
            ((PatentPayment)e.CreatedObject).s_Client = payment.s_Client;
            ((PatentPayment)e.CreatedObject).s_ClientNo = payment.s_ClientNo;
            ((PatentPayment)e.CreatedObject).n_PatentType = payment.n_PatentType;
            ((PatentPayment)e.CreatedObject).n_PaidBy = payment.n_PaidBy;
            ((PatentPayment)e.CreatedObject).n_PayCaseType = payment.n_PayCaseType;
            ((PatentPayment)e.CreatedObject).s_PayerName = payment.s_PayerName;
        }
    }
}
