using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace EastIPInternalInvoiceSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Fee : BaseObject
    {
        public Fee(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private Invoice invoice;
        [Association]
        public Invoice Invoice
        {
            get { return invoice; }
            set { SetPropertyValue("n_InvoiceId", ref invoice, value); }
        }


        private string fs_Description;
        public string s_Description
        {
            get { return fs_Description; }
            set { SetPropertyValue<string>("s_Description", ref fs_Description, value); }
        }

        private EnumsAll.FeeType fn_FeeType;
        public EnumsAll.FeeType FeeType
        {
            get { return fn_FeeType; }
            set { SetPropertyValue("n_FeeType", ref fn_FeeType, value); }
        }

        decimal fn_Amount;
        public decimal n_Amount
        {
            get { return fn_Amount; }
            set { SetPropertyValue<decimal>("n_Amount", ref fn_Amount, value); }
        }

    }
}