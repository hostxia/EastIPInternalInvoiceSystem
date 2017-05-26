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
using System.Data;
using System.Text.RegularExpressions;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("s_OurNo")]
    [DefaultListViewOptions(true, NewItemRowPosition.None)]
    public class PatentPayment : BaseObject
    {
        public PatentPayment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            dt_PayDeadline = DateTime.Now;
            Creator = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
            dt_Created = DateTime.Now;
        }

        private string _sOurNo;
        [ImmediatePostData]
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }


        private string fs_Client;
        public string s_Client
        {
            get { return fs_Client; }
            set { SetPropertyValue("s_Client", ref fs_Client, value); }
        }

        private string fs_ClientNo;
        public string s_ClientNo
        {
            get { return fs_ClientNo; }
            set { SetPropertyValue("s_ClientNo", ref fs_ClientNo, value); }
        }

        private string fs_Applicant;
        public string s_Applicant
        {
            get { return fs_Applicant; }
            set { SetPropertyValue("s_Applicant", ref fs_Applicant, value); }
        }

        private string fs_ApplicantNo;
        public string s_ApplicantNo
        {
            get { return fs_ApplicantNo; }
            set { SetPropertyValue("s_ApplicantNo", ref fs_ApplicantNo, value); }
        }


        private string _sPayerName;
        public string s_PayerName
        {
            get { return _sPayerName; }
            set { SetPropertyValue("s_PayerName", ref _sPayerName, value); }
        }

        private string _sAppNo;
        public string s_AppNo
        {
            get { return _sAppNo; }
            set { SetPropertyValue("s_AppNo", ref _sAppNo, value); }
        }

        private string _sFeeName;
        public string s_FeeName
        {
            get { return _sFeeName; }
            set { SetPropertyValue("s_FeeName", ref _sFeeName, value); }
        }

        private decimal _nAmount;
        public decimal n_Amount
        {
            get { return _nAmount; }
            set { SetPropertyValue("n_Amount", ref _nAmount, value); }
        }

        private DateTime _dtPaidDate;
        public DateTime dt_PaidDate
        {
            get { return _dtPaidDate; }
            set { SetPropertyValue("dt_PaidDate", ref _dtPaidDate, value); }
        }

        private DateTime _dtPayDeadline;
        public DateTime dt_PayDeadline
        {
            get { return _dtPayDeadline; }
            set { SetPropertyValue("dt_PayDeadline", ref _dtPayDeadline, value); }
        }

        private EnumsAll.PaidBy _nPaidBy;
        public EnumsAll.PaidBy n_PaidBy
        {
            get { return _nPaidBy; }
            set { SetPropertyValue("s_PaidBy", ref _nPaidBy, value); }
        }

        private EnumsAll.PayCaseType _nPayCaseType;
        public EnumsAll.PayCaseType n_PayCaseType
        {
            get { return _nPayCaseType; }
            set { SetPropertyValue("n_PayCaseType", ref _nPayCaseType, value); }
        }

        private EnumsAll.PatentType _nPatentType;
        public EnumsAll.PatentType n_PatentType
        {
            get { return _nPatentType; }
            set { SetPropertyValue("n_PatentType", ref _nPatentType, value); }
        }

        private SysUser fCreator;
        public SysUser Creator
        {
            get { return fCreator; }
            set { SetPropertyValue("Creator", ref fCreator, value); }
        }

        private DateTime fdt_Created;
        public DateTime dt_Created
        {
            get { return fdt_Created; }
            set { SetPropertyValue("dt_Created", ref fdt_Created, value); }
        }

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        private bool _bAudited;
        public bool b_Audited
        {
            get { return _bAudited; }
            set { SetPropertyValue("b_Audited", ref _bAudited, value); }
        }

        private bool _bReceipted;
        public bool b_Receipted
        {
            get { return _bReceipted; }
            set { SetPropertyValue("b_Receipted", ref _bReceipted, value); }
        }

        [Action(PredefinedCategory.OpenObject)]
        public void SetPaid()
        {
            dt_PaidDate = DateTime.Now;
            Save();
            Session.CommitTransaction();
        }

        public void GetInfo()
        {
            if (string.IsNullOrWhiteSpace(_sOurNo)) return;
            var sOurNo = _sOurNo;
            var sClientNo = string.Empty;
            var sClient = string.Empty;
            var sApplicantNo = string.Empty;
            var sApplicant = string.Empty;
            CommonFunction.GetCaseInfo(ref sOurNo, ref sClientNo, ref sClient, ref sApplicantNo, ref sApplicant);
            s_OurNo = sOurNo;
            s_ClientNo = sClientNo;
            s_Client = sClient;
            s_ApplicantNo = sApplicantNo;
            s_Applicant = sApplicant;

            var dtResult =
                DbHelperOra.Query($"select OURNO,APPLICATION_NO,PCT_NUMBER from patentcase where ourno like '%{_sOurNo.Trim().Replace("'", "''").ToUpper()}%'").Tables[0];
            if (dtResult.Rows.Count > 0)
            {

                s_OurNo = dtResult.Rows[0][0].ToString();
                s_AppNo = dtResult.Rows[0][1].ToString();
                var sPCTAppNo = dtResult.Rows[0][2].ToString();
                if (!string.IsNullOrWhiteSpace(s_AppNo))
                {
                    n_PayCaseType = EnumsAll.PayCaseType.国内;
                    SetCaseType();
                }
                else
                {
                    n_PayCaseType = EnumsAll.PayCaseType.PCT国家;
                    s_AppNo = sPCTAppNo;
                    n_PatentType = s_OurNo.Substring(0, s_OurNo.IndexOf("-")).Contains("PU")
                        ? EnumsAll.PatentType.实用新型
                        : EnumsAll.PatentType.发明;
                }
                GetPayerName();
            }
            else
            {
                dtResult =
DbHelperOra.Query($"select OURNO,APPNO from fcase where ourno like '%{_sOurNo.Trim().Replace("'", "''").ToUpper()}%'").Tables[0];
                if (dtResult.Rows.Count > 0)
                {
                    s_OurNo = dtResult.Rows[0][0].ToString();
                    s_AppNo = dtResult.Rows[0][1].ToString();
                    n_PayCaseType = s_OurNo.Substring(0, s_OurNo.IndexOf("-")).Contains("DJ")
                        ? EnumsAll.PayCaseType.国内
                        : EnumsAll.PayCaseType.PCT国际;
                    if (n_PayCaseType == EnumsAll.PayCaseType.国内)
                        n_PatentType = EnumsAll.PatentType.集成电路;
                    GetPayerName();
                }
            }
        }

        private void GetPayerName()
        {
            var sAgencyName = "北京东方亿思知识产权代理有限责任公司";
            var listApp = new List<string>();
            var dtResult = DbHelperOra.Query($"select appl_code1, appl_code2, appl_code3, appl_code4, appl_code5 from patentcase where ourno = '{_sOurNo}'").Tables[0];
            if (dtResult.Rows.Count > 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (!string.IsNullOrWhiteSpace(dtResult.Rows[0][$"appl_code{i}"].ToString()))
                        listApp.Add(dtResult.Rows[0][$"appl_code{i}"].ToString());
                }
            }
            else
            {
                dtResult = DbHelperOra.Query($"select EID from fcase_ent_rel where ourno = '{_sOurNo}' and (role = 'APP' or role = 'APPCLI')").Tables[0];
                dtResult.Rows.Cast<DataRow>().ToList().ForEach(r => listApp.Add(r[0].ToString()));
            }
            if (listApp.Count < 1) return;
            var rule = new XPCollection<PatentPaymentRule>(Session).FirstOrDefault(r => r.ListPayerCode.Count == listApp.Count && r.ListPayerCode.All(c => listApp.Contains(c)));
            s_PayerName = rule != null ? rule.s_PayerName : sAgencyName;
        }

        private void SetCaseType()
        {
            var cType = s_AppNo.Length > 10 ? s_AppNo[4] : s_AppNo[2];
            if (cType == '1' || cType == '8')
                n_PatentType = EnumsAll.PatentType.发明;
            else if (cType == '2' || cType == '9')
                n_PatentType = EnumsAll.PatentType.实用新型;
            else if (cType == '3')
                n_PatentType = EnumsAll.PatentType.外观设计;
        }
    }
}