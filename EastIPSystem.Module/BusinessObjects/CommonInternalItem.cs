using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CommonInternalItem : BaseObject
    {
        public CommonInternalItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private CommonInvoice commonInvoice;
        [Association("CommonInvoice-CommonInternalItems")]
        public CommonInvoice CommonInvoice
        {
            get { return commonInvoice; }
            set { SetPropertyValue("CommonInvoice", ref commonInvoice, value); }
        }

        private CodeFee codeFee;
        [ImmediatePostData]
        public CodeFee CodeFee
        {
            get { return codeFee; }
            set
            {
                SetPropertyValue("codeFee", ref codeFee, value);
                if (!IsLoading && !IsSaving && codeFee != null)
                {
                    s_Name = codeFee.s_Name;
                    n_Price = codeFee.n_Price;
                    n_Count = 1;
                    n_Currency = codeFee.n_Currency;
                }
            }
        }

        private string _sName;
        public string s_Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }

        private decimal _nPrice;
        [ImmediatePostData]
        public decimal n_Price
        {
            get { return _nPrice; }
            set { SetPropertyValue("n_Price", ref _nPrice, value); }
        }

        private decimal _nCount;
        [ImmediatePostData]
        public decimal n_Count
        {
            get { return _nCount; }
            set { SetPropertyValue("n_Count", ref _nCount, value); }
        }

        private EnumsAll.Currency _nCurrency;
        public EnumsAll.Currency n_Currency
        {
            get { return _nCurrency; }
            set { SetPropertyValue("n_Currency", ref _nCurrency, value); }
        }

        public decimal n_Amount => _nPrice * _nCount;

        [Browsable(false)]
        public string s_MergeCode => codeFee != null ? codeFee.s_MergeCode : string.Empty;

        [Browsable(false)]
        public string s_MergeContent => codeFee != null ? codeFee.s_MergeContent : string.Empty;
    }
}