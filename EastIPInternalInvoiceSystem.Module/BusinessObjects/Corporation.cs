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
    public class Corporation : BaseObject
    {
        private string _sCode;

        private string _sName;

        public Corporation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        public string Code
        {
            get { return _sCode; }
            set { SetPropertyValue("s_Code", ref _sCode, value); }
        }

        public string Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }

        [Browsable(false)]
        [Association("Applicants-Cases")]
        public XPCollection<CaseBase> Cases
        {
            get { return GetCollection<CaseBase>("Cases"); }
        }
    }
}