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
    [DefaultProperty("s_InvoiceType")]
    public class CommonInvoiceTypeItem : BaseObject
    {
        public CommonInvoiceTypeItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private CommonInvoice commonInvoice;
        [Association("CommonInvoice-CommonInvoiceTypeItems")]
        public CommonInvoice CommonInvoice
        {
            get { return commonInvoice; }
            set { SetPropertyValue("CommonInvoice", ref commonInvoice, value); }
        }

        private string _sInvoiceType;
        public string s_InvoiceType
        {
            get { return _sInvoiceType; }
            set { SetPropertyValue("s_InvoiceType", ref _sInvoiceType, value); }
        }

        private string _sFormatText;
        public string s_FormatText
        {
            get { return _sFormatText; }
            set { SetPropertyValue("s_FormatText", ref _sFormatText, value); }
        }

        private EnumsAll.DiscountType _nDiscountType;
        [ImmediatePostData]
        public EnumsAll.DiscountType n_DiscountType
        {
            get { return _nDiscountType; }
            set
            {
                SetPropertyValue("n_DiscountType", ref _nDiscountType, value);
                if (!IsLoading)
                    CalcPayableAmount();
            }
        }

        private decimal _nDiscount;
        [ImmediatePostData]
        public decimal n_Discount
        {
            get { return _nDiscount; }
            set
            {
                SetPropertyValue("n_Discount", ref _nDiscount, value);
                if (!IsLoading)
                    CalcPayableAmount();
            }
        }

        private decimal _nPayableAmount;
        public decimal n_PayableAmount
        {
            get { return _nPayableAmount; }
            set { SetPropertyValue("n_PayableAmount", ref _nPayableAmount, value); }
        }

        private int _nSeq;
        public int n_Seq
        {
            get { return _nSeq; }
            set
            {
                SetPropertyValue("n_Seq", ref _nSeq, value);
            }
        }

        [Association("CommonInvoiceTypeItem-CommonInvoiceItems"), Aggregated]
        public XPCollection<CommonInvoiceItem> CommonInvoiceItems => GetCollection<CommonInvoiceItem>("CommonInvoiceItems");

        public decimal n_Amount => CommonInvoiceItems.Where(i => !i.b_IsDiable).Sum(i => i.n_PayableAmount);
        public void CalcPayableAmount()
        {
            if (_nDiscountType == EnumsAll.DiscountType.比例)
                n_PayableAmount = _nDiscount == 1 ? 0 : n_Amount * (1 - _nDiscount);
            else if (_nDiscountType == EnumsAll.DiscountType.金额)
                n_PayableAmount = n_Amount - _nDiscount;
        }
    }
}