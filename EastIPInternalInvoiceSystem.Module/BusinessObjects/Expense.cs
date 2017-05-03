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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace EastIPInternalInvoiceSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Expense : BaseObject
    {
        public Expense(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private Invoice invoice;
        [Association]
        [Browsable(false)]
        public Invoice Invoice
        {
            get { return invoice; }
            set { SetPropertyValue("n_InvoiceId", ref invoice, value); }
        }

        private string _sExpenseNo;
        public string s_ExpenseNo
        {
            get { return _sExpenseNo; }
            set { SetPropertyValue("s_ExpenseNo", ref _sExpenseNo, value); }
        }

        private string _sOurNo;
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        private DateTime _dtPaidDate;
        public DateTime dt_PaidDate
        {
            get { return _dtPaidDate; }
            set { SetPropertyValue("dt_PaidDate", ref _dtPaidDate, value); }
        }

        private DateTime _dtExpenseDate;
        public DateTime dt_ExpenseDate
        {
            get { return _dtExpenseDate; }
            set { SetPropertyValue("dt_ExpenseDate", ref _dtExpenseDate, value); }
        }



        private string fs_Description;
        public string s_Description
        {
            get { return fs_Description; }
            set { SetPropertyValue<string>("s_Description", ref fs_Description, value); }
        }

        private string fs_CertificateNo;
        public string s_CertificateNo
        {
            get { return fs_CertificateNo; }
            set { SetPropertyValue<string>("s_CertificateNo", ref fs_CertificateNo, value); }
        }

        private string fs_Note;
        public string s_Note
        {
            get { return fs_Note; }
            set { SetPropertyValue<string>("s_Note", ref fs_Note, value); }
        }

        decimal fn_Amount;
        public decimal n_Amount
        {
            get { return fn_Amount; }
            set { SetPropertyValue<decimal>("n_Amount", ref fn_Amount, value); }
        }

        private FileData _expenseFile;
        [DevExpress.Xpo.Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData ExpenseFile
        {
            get { return _expenseFile; }
            set { SetPropertyValue("s_InvoiceFile", ref _expenseFile, value); }
        }

        public string PerNo => invoice == null ? string.Empty : invoice.s_PreNo;

        public string InvoiceNo => invoice == null ? string.Empty : invoice.s_InvoiceNo;


    }
}