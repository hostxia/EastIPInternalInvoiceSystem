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
    public class CommonInvoiceItem : BaseObject
    {
        public CommonInvoiceItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private CommonInvoiceTypeItem commonInvoiceTypeItem;
        [Association("CommonInvoiceTypeItem-CommonInvoiceItems"), Aggregated]
        public CommonInvoiceTypeItem CommonInvoiceTypeItem
        {
            get { return commonInvoiceTypeItem; }
            set { SetPropertyValue("CommonInvoiceTypeItem", ref commonInvoiceTypeItem, value); }
        }

        private string _sName;
        public string s_Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }

        private decimal _nAmount;
        [ImmediatePostData]
        public decimal n_Amount
        {
            get { return _nAmount; }
            set
            {
                SetPropertyValue("n_Amount", ref _nAmount, value);
                if (!IsLoading)
                    CalcPayableAmount();
            }
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


        private bool _bIsDiable;
        [ImmediatePostData]
        public bool b_IsDiable
        {
            get { return _bIsDiable; }
            set
            {
                SetPropertyValue("b_IsDiable", ref _bIsDiable, value);
                if (!IsLoading)
                {
                    if (_bIsDiable)
                        n_PayableAmount = 0;
                    else
                        CalcPayableAmount();

                    commonInvoiceTypeItem?.CalcPayableAmount();
                }
            }
        }

        private void CalcPayableAmount()
        {
            if (_nDiscountType == EnumsAll.DiscountType.比例)
                n_PayableAmount = _nDiscount == 1 ? 0 : _nAmount * (1 - _nDiscount);
            else if (_nDiscountType == EnumsAll.DiscountType.金额)
                n_PayableAmount = _nAmount - _nDiscount;
        }
    }
}