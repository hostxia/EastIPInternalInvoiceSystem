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
using System.Text.RegularExpressions;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("s_OurNo")]
    public class PatentSubmitList : BaseObject
    {
        public PatentSubmitList(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            dt_SubmitDate = dt_CreateDate = DateTime.Now;
            Creator = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
        }

        private string _sOurNo;
        [ImmediatePostData]
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        private DateTime _dtSubmitDate;
        public DateTime dt_SubmitDate
        {
            get { return _dtSubmitDate; }
            set { SetPropertyValue("dt_SubmitDate", ref _dtSubmitDate, value); }
        }

        private string _sClientNo;
        public string s_ClientNo
        {
            get { return _sClientNo; }
            set { SetPropertyValue("s_ClientNo", ref _sClientNo, value); }
        }

        private string _sClientName;
        public string s_ClientName
        {
            get { return _sClientName; }
            set { SetPropertyValue("s_ClientName", ref _sClientName, value); }
        }

        private string _sAppNo;
        public string s_AppNo
        {
            get { return _sAppNo; }
            set { SetPropertyValue("s_AppNo", ref _sAppNo, value); }
        }

        private string _sAppName;
        public string s_AppName
        {
            get { return _sAppName; }
            set { SetPropertyValue("s_AppName", ref _sAppName, value); }
        }

        private string _sDeptName;
        public string s_DeptName
        {
            get { return _sDeptName; }
            set { SetPropertyValue("s_DeptName", ref _sDeptName, value); }
        }

        private EnumsAll.PatentDirection patentDirection;
        [Persistent("n_PatentDirection")]
        public EnumsAll.PatentDirection PatentDirection
        {
            get { return patentDirection; }
            set { SetPropertyValue("PatentDirection", ref patentDirection, value); }
        }

        private EnumsAll.PatentCaseType patentCaseType;
        [Persistent("n_PatentCaseType")]
        public EnumsAll.PatentCaseType PatentCaseType
        {
            get { return patentCaseType; }
            set { SetPropertyValue("PatentCaseType", ref patentCaseType, value); }
        }

        private EnumsAll.PatentProcess patentProcess;
        [Persistent("n_PatentProcess")]
        public EnumsAll.PatentProcess PatentProcess
        {
            get { return patentProcess; }
            set { SetPropertyValue("PatentProcess", ref patentProcess, value); }
        }

        private string _sContent;
        public string s_Content
        {
            get { return _sContent; }
            set { SetPropertyValue("s_Content", ref _sContent, value); }
        }

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        private InternalInvoice internalInvoice;
        [Persistent("g_InternalInvoiceIde")]
        [Association("InternalInvoice-PatentSubmitLists")]
        public InternalInvoice InternalInvoice
        {
            get { return internalInvoice; }
            set { SetPropertyValue("InternalInvoice", ref internalInvoice, value); }
        }

        public string InternalNo => internalInvoice?.InternalNo;

        private bool _bNoNeedInvoice;
        public bool b_NoNeedInvoice
        {
            get { return _bNoNeedInvoice; }
            set { SetPropertyValue("b_NoNeedInvoice", ref _bNoNeedInvoice, value); }
        }

        //private bool _bIsWriteCase;
        //public bool b_IsWriteCase
        //{
        //    get { return _bIsWriteCase; }
        //    set { SetPropertyValue("b_IsWriteCase", ref _bIsWriteCase, value); }
        //}

        private bool _bIsDivCase;
        public bool b_IsDivCase
        {
            get { return _bIsDivCase; }
            set { SetPropertyValue("b_IsDivCase", ref _bIsDivCase, value); }
        }

        private bool _bIsReexamCase;
        public bool b_IsReexamCase
        {
            get { return _bIsReexamCase; }
            set { SetPropertyValue("b_IsReexamCase", ref _bIsReexamCase, value); }
        }

        [Association("PatentSubmitList-PatentPayments")]
        public XPCollection<PatentPayment> PatentPayments => GetCollection<PatentPayment>("PatentPayments");

        private DateTime _dtCreateDate;
        public DateTime dt_CreateDate
        {
            get { return _dtCreateDate; }
            set { SetPropertyValue("dt_CreateDate", ref _dtCreateDate, value); }
        }

        private SysUser creator;
        [NoForeignKey]
        [Persistent("g_CreatorId")]
        public SysUser Creator
        {
            get { return creator; }
            set { SetPropertyValue("Creator", ref creator, value); }
        }

        public void SetCaseInfo(string sCaseNo)
        {
            try
            {
                var sOurNo = s_OurNo;
                var sClientNo = string.Empty;
                var sClientName = string.Empty;
                var sAppNo = string.Empty;
                var sAppName = string.Empty;

                CommonFunction.GetCaseInfo(ref sOurNo, ref sClientNo, ref sClientName, ref sAppNo, ref sAppName);
                if (string.IsNullOrWhiteSpace(sOurNo)) return;

                s_OurNo = sOurNo;
                s_ClientNo = sClientNo;
                s_ClientName = sClientName;
                s_AppNo = sAppNo;
                s_AppName = sAppName;

                var sCaseNoShort = sOurNo.Substring(0, sOurNo.IndexOf("-"));

                var bIsWriteCase = DbHelperOra.Exists($"select 1 from CASEOTHERINFO where infotype = 'W_case' and caseno = '{_sOurNo}' and info = 'Y'");

                //b_IsWriteCase = bIsWriteCase;

                var sDeptName = DbHelperOra.GetSingle($"select info from CASEOTHERINFO where infotype = 'department' and caseno = '{_sOurNo}'");
                if (!string.IsNullOrWhiteSpace(sDeptName?.ToString()))
                    s_DeptName = sDeptName + "部";

                if (sCaseNoShort.Contains("PI"))
                {
                    PatentCaseType = EnumsAll.PatentCaseType.中国申请_PCT进国家_发明;
                }
                else if (sCaseNoShort.Contains("PU"))
                {
                    PatentCaseType = EnumsAll.PatentCaseType.中国申请_PCT进国家_实用新型;
                }
                else if (sCaseNoShort.Contains("SE"))
                {
                    PatentCaseType = EnumsAll.PatentCaseType.其他注册申请_保密审查;
                }
                else if (sCaseNoShort.Contains("DJ"))
                {
                    PatentCaseType = EnumsAll.PatentCaseType.其他注册申请_版权登记;
                }
                else if (sCaseNoShort.Contains("P"))
                {
                    PatentCaseType = EnumsAll.PatentCaseType.国外申请_国际申请;
                }
                else if (sCaseNoShort.Contains("NI") || sCaseNoShort.Contains("I"))
                {
                    PatentCaseType = !bIsWriteCase ? EnumsAll.PatentCaseType.中国申请_巴黎公约_发明 : EnumsAll.PatentCaseType.中国申请_撰写_发明;
                }
                else if (sCaseNoShort.Contains("NU") || sCaseNoShort.Contains("U"))
                {
                    PatentCaseType = !bIsWriteCase ? EnumsAll.PatentCaseType.中国申请_巴黎公约_实用新型 : EnumsAll.PatentCaseType.中国申请_撰写_实用新型;
                }
                else if (sCaseNoShort.Contains("ND") || sCaseNoShort.Contains("D"))
                {
                    PatentCaseType = !bIsWriteCase ? EnumsAll.PatentCaseType.中国申请_巴黎公约_外观设计 : EnumsAll.PatentCaseType.中国申请_撰写_外观设计;
                }

                if (!string.IsNullOrWhiteSpace(s_AppNo))
                {
                    var sCodeCountry = Session.FindObject<Corporation>(CriteriaOperator.Parse("Code = ?", s_AppNo))?.Country?.s_Code;
                    if (!string.IsNullOrWhiteSpace(sCodeCountry))
                    {
                        if (PatentCaseType.ToString().Contains("中国") && sCodeCountry == "CN")
                            PatentDirection = EnumsAll.PatentDirection.内到内;
                        else if (PatentCaseType.ToString().Contains("国外") && sCodeCountry == "CN")
                            PatentDirection = EnumsAll.PatentDirection.内到外;
                        else if (PatentCaseType.ToString().Contains("中国") && sCodeCountry != "CN")
                            PatentDirection = EnumsAll.PatentDirection.外到内;
                        else if (PatentCaseType.ToString().Contains("国外") && sCodeCountry != "CN")
                            PatentDirection = EnumsAll.PatentDirection.外到外;
                        else
                        {
                            if (sCodeCountry == "CN")
                                PatentDirection = EnumsAll.PatentDirection.内到内;
                            else
                                PatentDirection = EnumsAll.PatentDirection.外到内;
                            PatentDirection = EnumsAll.PatentDirection.外到内;
                        }
                    }
                }


                b_IsDivCase = Regex.IsMatch(sCaseNoShort, @"\d{4}(D|d)");

                if (InternalInvoice == null)
                {
                    var tempInvoice = Session.FindObject<InternalInvoice>(CriteriaOperator.Parse("OurNo = ? And PatentSubmitLists.Count = 0", _sOurNo));
                    if (tempInvoice != null)
                        InternalInvoice = tempInvoice;
                }

                if (PatentPayments.Count == 0)
                {
                    var listPatentPayments = new XPQuery<PatentPayment>(Session).Where(p => p.PatentSubmitList == null && p.s_OurNo == _sOurNo).ToList();
                    if (listPatentPayments.Count > 0)
                        PatentPayments.AddRange(listPatentPayments);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [Action]
        public void CreateInternalInvoice()
        {
            if (InternalInvoice != null || b_NoNeedInvoice) return;
            var tempInternalInvoice = new InternalInvoice(Session)
            {
                Content = s_Content,
                InternalType = (EnumsAll.InternalType)(int)patentProcess,
                OurNo = s_OurNo,
                ClientName = s_ClientName,
                ClientNo = s_ClientNo,
                AppName = s_AppName,
                AppNo = s_AppNo,
                CreateDate = dt_SubmitDate,
                SendDate = dt_SubmitDate.AddDays(3),
                Deadline = dt_SubmitDate.AddDays(7)
            };
            InternalInvoice = tempInternalInvoice;
            Save();
            Session.CommitTransaction();
        }
    }
}