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

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class PatentPaymentRule : BaseObject
    {
        public PatentPaymentRule(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _sPayerCode1;
        public string s_PayerCode1
        {
            get { return _sPayerCode1; }
            set { SetPropertyValue("s_PayerCode1", ref _sPayerCode1, value); }
        }

        private string _sPayerCode2;
        public string s_PayerCode2
        {
            get { return _sPayerCode2; }
            set { SetPropertyValue("s_PayerCode2", ref _sPayerCode2, value); }
        }

        private string _sPayerCode3;
        public string s_PayerCode3
        {
            get { return _sPayerCode3; }
            set { SetPropertyValue("s_PayerCode3", ref _sPayerCode3, value); }
        }

        private string _sPayerName;
        public string s_PayerName
        {
            get { return _sPayerName; }
            set { SetPropertyValue("s_PayerName", ref _sPayerName, value); }
        }
        [Browsable(false)]
        public List<string> ListPayerCode
        {
            get
            {
                var listPayerCode = new List<string>();
                if (!string.IsNullOrWhiteSpace(_sPayerCode1))
                    listPayerCode.Add(_sPayerCode1);
                if (!string.IsNullOrWhiteSpace(_sPayerCode2))
                    listPayerCode.Add(_sPayerCode2);
                if (!string.IsNullOrWhiteSpace(_sPayerCode3))
                    listPayerCode.Add(_sPayerCode3);
                return listPayerCode;
            }
        }
    }
}