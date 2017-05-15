using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Data.WcfLinq.Helpers;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace EastIPSystem.Module.BusinessObjects
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
            Creator = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
            dt_Created = DateTime.Now;
        }

        protected override void OnSaving()
        {
            if (string.IsNullOrEmpty(s_ExpenseNo))
            {
                var dtNow = dt_Created.Date;
                var dtFirstDate = new DateTime(dtNow.Year, dtNow.Month, 1);
                var sMaxNo = new XPQuery<Expense>(Session).Where(e => e.dt_Created >= dtFirstDate && e.dt_Created < dtFirstDate.AddMonths(1)).Max(e => e.s_ExpenseNo);
                s_ExpenseNo = string.IsNullOrWhiteSpace(sMaxNo) ? DateTime.Now.ToString("yyyyMMdd") + "0001" : (Convert.ToInt64(sMaxNo) + 1).ToString();
            }
            base.OnSaving();

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

        private SysUser fCreator;
        public SysUser Creator
        {
            get { return fCreator; }
            set { SetPropertyValue("n_CreatorId", ref fCreator, value); }
        }

        private DateTime fdt_Created;
        public DateTime dt_Created
        {
            get { return fdt_Created; }
            set { SetPropertyValue("dt_Created", ref fdt_Created, value); }
        }

        public string PerNo => invoice == null ? string.Empty : invoice.s_PreNo;

        public string InvoiceNo => invoice == null ? string.Empty : invoice.s_InvoiceNo;

        [Action(PredefinedCategory.Edit)]
        public void GetCaseInfo()
        {
            s_OurNo = CommonFunction.GetOurNo(_sOurNo);
        }
    }
}