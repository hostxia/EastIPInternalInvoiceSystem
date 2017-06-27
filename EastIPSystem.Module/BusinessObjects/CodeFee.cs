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
    public class CodeFee : BaseObject
    {
        public CodeFee(Session session)
            : base(session)
        {
        }

        private EnumsAll.Language _nLanguage;
        public EnumsAll.Language n_Language
        {
            get { return _nLanguage; }
            set { SetPropertyValue("n_Language", ref _nLanguage, value); }
        }

        private EnumsAll.Currency _nCurrency;
        public EnumsAll.Currency n_Currency
        {
            get { return _nCurrency; }
            set { SetPropertyValue("n_Currency", ref _nCurrency, value); }
        }

        private string _sCode;
        public string s_Code
        {
            get { return _sCode; }
            set { SetPropertyValue("s_Code", ref _sCode, value); }
        }

        private string _sName;
        public string s_Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }

        private decimal _nPrice;
        public decimal n_Price
        {
            get { return _nPrice; }
            set { SetPropertyValue("n_Price", ref _nPrice, value); }
        }

        private string _sInternalType;
        public string s_InternalType
        {
            get { return _sInternalType; }
            set { SetPropertyValue("s_InternalType", ref _sInternalType, value); }
        }

        private string _sInvoiceType;
        public string s_InvoiceType
        {
            get { return _sInvoiceType; }
            set { SetPropertyValue("s_InvoiceType", ref _sInvoiceType, value); }
        }

        private string _sMergeCode;
        public string s_MergeCode
        {
            get { return _sMergeCode; }
            set { SetPropertyValue("s_MergeCode", ref _sMergeCode, value); }
        }

        private string _sMergeContent;
        public string s_MergeContent
        {
            get { return _sMergeContent; }
            set { SetPropertyValue("s_MergeContent", ref _sMergeContent, value); }
        }
    }
}