using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.Globalization;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.XtraPrinting.Native;
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CommonInvoice : BaseObject
    {
        public CommonInvoice(Session session)
            : base(session)
        {
        }

        private string _sInvoiceNo;
        public string s_InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { SetPropertyValue("s_InvoiceNo", ref _sInvoiceNo, value); }
        }

        private string _sOurNo;
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        private string _sAppNo;
        public string s_AppNo
        {
            get { return _sAppNo; }
            set { SetPropertyValue("s_AppNo", ref _sAppNo, value); }
        }

        private string _sClientName;
        public string s_ClientName
        {
            get { return _sClientName; }
            set { SetPropertyValue("s_ClientName", ref _sClientName, value); }
        }

        private string _sClientCaseNo;
        public string s_ClientCaseNo
        {
            get { return _sClientCaseNo; }
            set { SetPropertyValue("s_ClientCaseNo", ref _sClientCaseNo, value); }
        }

        private string _sApplicantName;
        public string s_ApplicantName
        {
            get { return _sApplicantName; }
            set { SetPropertyValue("s_ApplicantName", ref _sApplicantName, value); }
        }

        private string _sAppCaseNo;
        public string s_AppCaseNo
        {
            get { return _sAppCaseNo; }
            set { SetPropertyValue("s_AppCaseNo", ref _sAppCaseNo, value); }
        }

        private string _sInternalNo;
        public string s_InternalNo
        {
            get { return _sInternalNo; }
            set { SetPropertyValue("s_InternalNo", ref _sInternalNo, value); }
        }

        private string _sContact;
        [Size(1000)]
        public string s_Contact
        {
            get { return _sContact; }
            set { SetPropertyValue("s_Contact", ref _sContact, value); }
        }

        private string _sReason;
        [Size(1000)]
        public string s_Reason
        {
            get { return _sReason; }
            set { SetPropertyValue("s_Reason", ref _sReason, value); }
        }

        private string _sNote;
        [Size(2000)]
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        private DateTime _dtBillingDate;
        public DateTime dt_BillingDate
        {
            get { return _dtBillingDate; }
            set { SetPropertyValue("dt_BillingDate", ref _dtBillingDate, value); }
        }

        private DateTime _dtActionDate;
        public DateTime dt_ActionDate
        {
            get { return _dtActionDate; }
            set { SetPropertyValue("dt_ActionDate", ref _dtActionDate, value); }
        }

        private bool _bIsWriteCase;
        public bool b_IsWriteCase
        {
            get { return _bIsWriteCase; }
            set { SetPropertyValue("b_IsWriteCase", ref _bIsWriteCase, value); }
        }

        private bool _bIsMiddleCase;
        public bool b_IsMiddleCase
        {
            get { return _bIsMiddleCase; }
            set { SetPropertyValue("b_IsMiddleCase", ref _bIsMiddleCase, value); }
        }

        private EnumsAll.Currency _nCurrency;
        public EnumsAll.Currency n_Currency
        {
            get { return _nCurrency; }
            set { SetPropertyValue("n_Currency", ref _nCurrency, value); }
        }

        private EnumsAll.Currency _nExchangeCurrency;
        public EnumsAll.Currency n_ExchangeCurrency
        {
            get { return _nExchangeCurrency; }
            set { SetPropertyValue("n_ExchangeCurrency", ref _nExchangeCurrency, value); }
        }

        private decimal _nRate;
        public decimal n_Rate
        {
            get { return _nRate; }
            set { SetPropertyValue("n_Rate", ref _nRate, value); }
        }

        private decimal _nExchangeRate;
        public decimal n_ExchangeRate
        {
            get { return _nExchangeRate; }
            set { SetPropertyValue("n_ExchangeRate", ref _nExchangeRate, value); }
        }

        public decimal n_TotalAmount => CommonInvoiceTypeItems.Sum(t => t.n_PayableAmount);

        [Association("CommonInvoice-CommonInternalItems"), Aggregated]
        public XPCollection<CommonInternalItem> CommonInternalItems => GetCollection<CommonInternalItem>("CommonInternalItems");

        [Association("CommonInvoice-CommonInvoiceTypeItems"), Aggregated]
        public XPCollection<CommonInvoiceTypeItem> CommonInvoiceTypeItems => GetCollection<CommonInvoiceTypeItem>("CommonInvoiceTypeItems");

        public List<CommonInvoiceItem> CommonInvoiceItems => CommonInvoiceTypeItems.SelectMany(i => i.CommonInvoiceItems).ToList();

        [Action]
        public void CreateInvoiceItem()
        {
            if (CommonInvoiceTypeItems.Count > 0)
                CommonInvoiceTypeItems.ToList().ForEach(i => i.Delete());
            CommonInternalItems.Where(i => !string.IsNullOrWhiteSpace(i.s_MergeCode)).GroupBy(i => i.s_MergeCode).ForEach(
                g =>
                {
                    var nAmount = g.Select(i => CalcAmount(i.n_Price * i.n_Count, i.n_Currency)).Sum();
                    var invoiceTypeItem = CommonInvoiceTypeItems.FirstOrDefault(
                        t =>
                            t.s_InvoiceType ==
                            (g.ToList()[0].CodeFee == null ? "SERVICES FEE" : g.ToList()[0].CodeFee.s_InvoiceType));
                    if (invoiceTypeItem == null)
                    {
                        invoiceTypeItem = new CommonInvoiceTypeItem(Session)
                        {
                            CommonInvoice = this,
                            s_InvoiceType = g.ToList()[0].CodeFee != null ? g.ToList()[0].CodeFee.s_InvoiceType : "SERVICES FEE",
                            n_Discount = 0
                        };
                        CommonInvoiceTypeItems.Add(invoiceTypeItem);
                    }
                    invoiceTypeItem.CommonInvoiceItems.Add(new CommonInvoiceItem(Session)
                    {
                        CommonInvoiceTypeItem = invoiceTypeItem,
                        n_Amount = Math.Round(nAmount, 2),
                        n_Discount = 0,
                        n_DiscountType = EnumsAll.DiscountType.比例,
                        s_Name = string.Join("; ", g.OrderBy(a => a.CodeFee.s_Code).Select(a => a.s_Name.Replace("{1}", a.n_Count.ToString("N1")))) + $" {g.Last().s_MergeContent?.Replace("{2}", g.Sum(a => a.n_Count).ToString("N1"))}",
                        n_PayableAmount = Math.Round(nAmount, 2),
                    });

                });
            CommonInternalItems.Where(i => i.CodeFee != null && string.IsNullOrWhiteSpace(i.CodeFee.s_MergeCode) || i.CodeFee == null).ForEach(i =>
            {
                var nAmount = CalcAmount(i.n_Price * i.n_Count, i.n_Currency);
                var invoiceTypeItem =
                    CommonInvoiceTypeItems.FirstOrDefault(
                        t => t.s_InvoiceType == (i.CodeFee == null ? "SERVICES FEE" : i.CodeFee.s_InvoiceType));
                if (invoiceTypeItem == null)
                {
                    invoiceTypeItem = new CommonInvoiceTypeItem(Session)
                    {
                        CommonInvoice = this,
                        s_InvoiceType = i.CodeFee != null ? i.CodeFee.s_InvoiceType : "SERVICES FEE",
                        n_Discount = 0
                    };
                    CommonInvoiceTypeItems.Add(invoiceTypeItem);
                }
                invoiceTypeItem.CommonInvoiceItems.Add(new CommonInvoiceItem(Session)
                {
                    CommonInvoiceTypeItem = invoiceTypeItem,
                    n_Amount = Math.Round(nAmount, 2),
                    n_Discount = 0,
                    n_DiscountType = EnumsAll.DiscountType.比例,
                    s_Name = i.s_Name.Replace("{1}", i.n_Count.ToString(CultureInfo.InvariantCulture)).Replace("{2}", i.n_Count.ToString(CultureInfo.InvariantCulture)),
                    n_PayableAmount = Math.Round(nAmount, 2),
                });
            });
            CommonInvoiceTypeItems.ForEach(t =>
            {
                t.n_PayableAmount = t.n_Amount;
                if (t.s_InvoiceType.StartsWith("G") || t.s_InvoiceType.StartsWith("S"))
                    t.n_Seq = 1;
                else if (t.s_InvoiceType.StartsWith("A"))
                    t.n_Seq = 2;
                else if (t.s_InvoiceType.StartsWith("O"))
                    t.n_Seq = 3;
                else if (t.s_InvoiceType.StartsWith("D"))
                    t.n_Seq = 4;
            });
            Save();
        }

        private decimal CalcAmount(decimal nOrgAmount, EnumsAll.Currency currency)
        {
            if (currency == _nCurrency)
                return nOrgAmount;
            if (currency == EnumsAll.Currency.人民币 && currency != _nCurrency)
                return nOrgAmount / _nRate;
            if (currency != EnumsAll.Currency.人民币 && currency != _nCurrency && currency == _nExchangeCurrency)
                return nOrgAmount * _nExchangeRate / _nRate;
            return nOrgAmount;
        }

        [Action]
        public void GetInvoiceInfo()
        {
            var internalInvoice = new UnitOfWork(Session.DataLayer).FindObject<InternalInvoice>(CriteriaOperator.Parse($"InternalNo Like '%{_sInternalNo}%'"));
            if (string.IsNullOrWhiteSpace(internalInvoice?.OurNo)) return;
            s_InternalNo = internalInvoice.InternalNo;
            s_Reason = internalInvoice.Content;
            var drs = DbHelperOra.Query($"select CLIENT,CLIENT_NAME,APPLICATION_NO,CLIENT_NUMBER,OURNO,APP_REF,BILLING_CONTACT,MAILING_ADDR,APPLICANT1,APPLICANT2,APPLICANT3,APPLICANT4,APPLICANT5 from patentcase where OURNO LIKE '%{internalInvoice.OurNo}%'").Tables[0].Rows;
            if (drs.Count < 1) return;
            s_OurNo = drs[0]["OURNO"].ToString();
            s_AppCaseNo = drs[0]["APP_REF"].ToString();
            s_AppNo = drs[0]["APPLICATION_NO"].ToString();
            s_ClientCaseNo = drs[0]["CLIENT_NUMBER"].ToString();
            s_ClientName = drs[0]["CLIENT_NAME"].ToString();
            var listAppName = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                if (!string.IsNullOrWhiteSpace(drs[0][$"APPLICANT{i}"].ToString()))
                    listAppName.Add(drs[0][$"APPLICANT{i}"].ToString());
            }
            s_ApplicantName = string.Join("; ", listAppName);

            if (!string.IsNullOrWhiteSpace(drs[0]["CLIENT_NAME"].ToString()))
                s_Contact = drs[0]["CLIENT_NAME"].ToString();
            if (!string.IsNullOrWhiteSpace(drs[0]["BILLING_CONTACT"].ToString()))
                s_Contact += "\r\n" + drs[0]["BILLING_CONTACT"];
            else if (!string.IsNullOrWhiteSpace(drs[0]["MAILING_ADDR"].ToString()))
                s_Contact += "\r\n" + drs[0]["MAILING_ADDR"];

            b_IsWriteCase = DbHelperOra.Exists($"select * from caseotherinfo where infotype = 'W_case' and caseno = '{s_OurNo}' and info like '%Y%'");
            b_IsMiddleCase = DbHelperOra.Exists($"select * from caseotherinfo where infotype = 'transferin' and caseno = '{s_OurNo}' and info like '%%'");
        }
    }
}