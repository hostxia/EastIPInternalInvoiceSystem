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

    public class TimeSheet : BaseObject
    {
        public TimeSheet(Session session)
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

        private SysUser fTimeKeeper;
        public SysUser TimeKeeper
        {
            get { return fTimeKeeper; }
            set { SetPropertyValue("n_SysUserId", ref fTimeKeeper, value); }
        }

        private DateTime _dt_WorkDate;
        public DateTime dt_WorkDate
        {
            get { return _dt_WorkDate; }
            set { SetPropertyValue("dt_WorkDate", ref _dt_WorkDate, value); }
        }

        decimal fn_Hour;
        public decimal n_Hour
        {
            get { return fn_Hour; }
            set { SetPropertyValue<decimal>("n_Hour", ref fn_Hour, value); }
        }

        private string fs_Description;
        public string s_Description
        {
            get { return fs_Description; }
            set { SetPropertyValue<string>("s_Description", ref fs_Description, value); }
        }

    }
}