using System;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("s_PreNo")]
    public class Invoice : BaseObject
    {
        public Invoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _sPreNo;
        public string s_PreNo
        {
            get { return _sPreNo; }
            set { SetPropertyValue("s_PreNo", ref _sPreNo, value); }
        }

        private string _sOurNo;
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        private string _sDescription;
        public string s_Description
        {
            get { return _sDescription; }
            set { SetPropertyValue("s_Description", ref _sDescription, value); }
        }

        private EnumsAll.InvoiceState _state;
        public EnumsAll.InvoiceState State
        {
            get { return _state; }
            set { SetPropertyValue("n_State", ref _state, value); }
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

        #region 账单信息

        private string _sInvoiceNo;
        public string s_InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { SetPropertyValue("s_InvoiceNo", ref _sInvoiceNo, value); }
        }

        private DateTime _dtInvoiceLogDate;
        public DateTime dt_InvoiceLogDate
        {
            get { return _dtInvoiceLogDate; }
            set { SetPropertyValue("dt_InvoiceLogDate", ref _dtInvoiceLogDate, value); }
        }
        #endregion
        [Association]
        public XPCollection<TimeSheet> TimeSheets
        {
            get { return GetCollection<TimeSheet>("TimeSheets"); }
        }

        [Association]
        public XPCollection<InternalInvoice> InternalInvoices
        {
            get { return GetCollection<InternalInvoice>("InternalInvoices"); }
        }

        [Association]
        public XPCollection<Expense> Expenses
        {
            get { return GetCollection<Expense>("Expenses"); }
        }

        [Association]
        public XPCollection<Fee> Fees
        {
            get { return GetCollection<Fee>("Fees"); }
        }

    }
}