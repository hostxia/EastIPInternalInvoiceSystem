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
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("s_OurNo")]
    public class PatentBase : BaseObject
    {
        public PatentBase(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            PatentProgresses.Add(new PatentProgress(Session) { dt_ItemDate = DateTime.Now, PatentBase = this, n_Item = EnumsAll.PatentProgressItem.未处理 });
        }

        protected override void OnSaving()
        {
            s_ApplicantCodes = string.Join(";", Applicants.Select(a => a.Code).ToList());
            s_ApplicantNames = string.Join(";", Applicants.Select(a => a.Name).ToList());
            base.OnSaving();
        }

        private string _sOurNo;
        [ImmediatePostData]
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        private string _sName;
        public string s_Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }

        private DateTime _dtReceiveDate;
        public DateTime dt_ReceiveDate
        {
            get { return _dtReceiveDate; }
            set { SetPropertyValue("dt_ReceiveDate", ref _dtReceiveDate, value); }
        }

        private Corporation client;
        public Corporation Client
        {
            get { return client; }
            set { SetPropertyValue("Client", ref client, value); }
        }

        private string _sClientRef;
        public string s_ClientRef
        {
            get { return _sClientRef; }
            set { SetPropertyValue("s_ClientRef", ref _sClientRef, value); }
        }

        private string _sClientContact;
        public string s_ClientContact
        {
            get { return _sClientContact; }
            set { SetPropertyValue("s_ClientContact", ref _sClientContact, value); }
        }

        //private Corporation introducer;

        //public Corporation Introducer
        //{
        //    get { return introducer; }
        //    set { SetPropertyValue("Introducer", ref introducer, value); }
        //}

        private string _sApplicantCodes;
        public string s_ApplicantCodes
        {
            get { return _sApplicantCodes; }
            set { SetPropertyValue("s_ApplicantCodes", ref _sApplicantCodes, value); }
        }

        private string _sApplicantNames;
        public string s_ApplicantNames
        {
            get { return _sApplicantNames; }
            set { SetPropertyValue("s_ApplicantNames", ref _sApplicantNames, value); }
        }

        //private string _sAppRef;
        //public string s_AppRef
        //{
        //    get { return _sAppRef; }
        //    set { SetPropertyValue("s_AppRef", ref _sAppRef, value); }
        //}

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        private string _sAgentNote;
        public string s_AgentNote
        {
            get { return _sAgentNote; }
            set { SetPropertyValue("s_AgentNote", ref _sAgentNote, value); }
        }

        private string _sInstruction;
        public string s_Instruction
        {
            get { return _sInstruction; }
            set { SetPropertyValue("s_Instruction", ref _sInstruction, value); }
        }

        private EnumsAll.PatentType _sPatentType;
        public EnumsAll.PatentType s_PatentType
        {
            get { return _sPatentType; }
            set { SetPropertyValue("s_PatentType", ref _sPatentType, value); }
        }

        private string _sDeptName;
        public string s_DeptName
        {
            get { return _sDeptName; }
            set { SetPropertyValue("s_DeptName", ref _sDeptName, value); }
        }

        private SysUser _sWriter;
        public SysUser Writer
        {
            get { return _sWriter; }
            set { SetPropertyValue("Writer", ref _sWriter, value); }
        }

        private SysUser _sTeacher;
        public SysUser Teacher
        {
            get { return _sTeacher; }
            set { SetPropertyValue("Teacher", ref _sTeacher, value); }
        }

        private SysUser _sManager;
        public SysUser Manager
        {
            get { return _sManager; }
            set { SetPropertyValue("Manager", ref _sManager, value); }
        }

        [Association("PatentBases-Applicants")]
        public XPCollection<Corporation> Applicants => GetCollection<Corporation>("Applicants");

        [Association("PatentBase-PatentProgresses"), DevExpress.Xpo.Aggregated]
        public XPCollection<PatentProgress> PatentProgresses => GetCollection<PatentProgress>("PatentProgresses");

        public XPCollection<CaseExtension> CaseExtensions => new XPCollection<CaseExtension>(Session, CriteriaOperator.Parse("s_OurNo = ?", _sOurNo));

        private PatentProgress lastPatentProgress;
        [NoForeignKey]
        public PatentProgress LastPatentProgress
        {
            get { return lastPatentProgress; }
            set { SetPropertyValue("LastPatentProgress", ref lastPatentProgress, value); }
        }

        private DateTime _dtReturnInventorDate;
        public DateTime dt_ReturnInventorDate
        {
            get { return _dtReturnInventorDate; }
            set { SetPropertyValue("dt_ReturnInventorDate", ref _dtReturnInventorDate, value); }
        }

        private DateTime _dtReturnIPRDate;
        public DateTime dt_ReturnIPRDate
        {
            get { return _dtReturnIPRDate; }
            set { SetPropertyValue("dt_ReturnIPRDate", ref _dtReturnIPRDate, value); }
        }

        private DateTime _dtFilingDeadline;
        public DateTime dt_FilingDeadline
        {
            get { return _dtFilingDeadline; }
            set { SetPropertyValue("dt_FilingDeadline", ref _dtFilingDeadline, value); }
        }

        public void GetDeadline()
        {
            var objDate =
                DbHelperOra.GetSingle(
                    $"select duedate from generalalert where typeid = 'tohandle_presubmit' and comments like '%返稿发明人%' and ourno = '{s_OurNo}'");
            if (objDate != null)
                dt_ReturnInventorDate = Convert.ToDateTime(objDate);
            objDate = DbHelperOra.GetSingle(
                $"select duedate from generalalert where typeid = 'tohandle_presubmit' and comments like '%返稿工程师%' and ourno = '{s_OurNo}'");
            if (objDate != null)
                dt_ReturnIPRDate = Convert.ToDateTime(objDate);
            Save();
        }

        [Action(PredefinedCategory.RecordEdit)]
        public void GetPatentInfo()
        {
            EnumsAll.CaseType caseType = EnumsAll.CaseType.Internal;
            var sOurNo = CommonFunction.GetOurNo(_sOurNo, ref caseType);
            if (string.IsNullOrEmpty(sOurNo)) return;
            s_OurNo = sOurNo;
            switch (caseType)
            {
                case EnumsAll.CaseType.Internal:
                    {
                        var dr = DbHelperOra.Query(
                             $"select RECEIVED,CLIENT,CLIENT_NAME,APPL_CODE1,APPLICANT1,APPLICANT_CH1,APPL_CODE2,APPLICANT2,APPLICANT_CH2,APPL_CODE3,APPLICANT3,APPLICANT_CH3,APPL_CODE4,APPLICANT4,APPLICANT_CH4,APPL_CODE5,APPLICANT5,APPLICANT_CH5,TITLE_CHINESE,CLIENT_NUMBER,FILING_DUE,TITLE from PATENTCASE where OURNO = '{_sOurNo}'").Tables[0].Rows[0];
                        s_Name = dr["TITLE_CHINESE"].ToString();
                        if (string.IsNullOrWhiteSpace(s_Name))
                            s_Name = dr["TITLE"].ToString();
                        s_ClientRef = dr["CLIENT_NUMBER"].ToString();

                        if (!string.IsNullOrWhiteSpace(dr["RECEIVED"].ToString()))
                            dt_ReceiveDate = Convert.ToDateTime(dr["RECEIVED"].ToString());
                        if (!string.IsNullOrWhiteSpace(dr["FILING_DUE"].ToString()))
                            dt_FilingDeadline = Convert.ToDateTime(dr["FILING_DUE"].ToString());
                        if (!string.IsNullOrWhiteSpace(dr["CLIENT"].ToString()))
                            Client =
                                Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{dr["CLIENT"]}'")) ??
                                new Corporation(Session)
                                {
                                    Code = dr["CLIENT"].ToString(),
                                    Name = dr["CLIENT_NAME"].ToString()
                                };
                        Applicants.ToList().ForEach(a => Applicants.Remove(a));
                        for (int i = 1; i <= 5; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(dr[$"APPL_CODE{i}"].ToString()))
                            {
                                Applicants.Add(
                                    Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{dr[$"APPL_CODE{i}"]}'")) ??
                                    new Corporation(Session)
                                    {
                                        Code = dr[$"APPL_CODE{i}"].ToString(),
                                        Name =
                                            string.IsNullOrWhiteSpace(dr[$"APPLICANT{i}"].ToString())
                                                ? dr[$"APPLICANT_CH{i}"].ToString()
                                                : dr[$"APPLICANT{i}"].ToString()
                                    });
                            }
                        }
                        var objDate =
                            DbHelperOra.GetSingle(
                                $"select duedate from generalalert where typeid = 'tohandle_presubmit' and comments like '%返稿发明人%' and ourno = '{s_OurNo}'");
                        if (objDate != null)
                            dt_ReturnInventorDate = Convert.ToDateTime(objDate);
                        objDate = DbHelperOra.GetSingle(
                            $"select duedate from generalalert where typeid = 'tohandle_presubmit' and comments like '%返稿工程师%' and ourno = '{s_OurNo}'");
                        if (objDate != null)
                            dt_ReturnIPRDate = Convert.ToDateTime(objDate);
                        break;
                    }
                case EnumsAll.CaseType.Foreign:
                    {
                        var dr = DbHelperOra.Query(
                                $"select RECEIVED,CTITLE,TITLE from FCASE where OURNO = '{_sOurNo}'")
                            .Tables[0].Rows[0];
                        if (!string.IsNullOrWhiteSpace(dr["RECEIVED"].ToString()))
                            dt_ReceiveDate = Convert.ToDateTime(dr["RECEIVED"].ToString());
                        s_Name = dr["CTITLE"].ToString();
                        if (string.IsNullOrWhiteSpace(s_Name))
                            s_Name = dr["TITLE"].ToString();
                        var dt = DbHelperOra.Query($"select EID,ROLE,ORIG_NAME,TRAN_NAME,ENT_ORDER from FCASE_ENT_REL where OURNO = '{_sOurNo}'").Tables[0];
                        var tempclient = dt.Select("ROLE = 'CLI' OR ROLE = 'APPCLI'");
                        if (tempclient.Length > 0)
                            Client =
                                Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{tempclient[0]["EID"]}'")) ??
                                new Corporation(Session)
                                {
                                    Code = tempclient[0]["EID"].ToString(),
                                    Name = !string.IsNullOrWhiteSpace(tempclient[0]["ORIG_NAME"].ToString())
                                                ? tempclient[0]["ORIG_NAME"].ToString()
                                                : tempclient[0]["TRAN_NAME"].ToString()
                                };

                        Applicants.ToList().ForEach(a => Applicants.Remove(a));
                        foreach (var dataRow in dt.Select("ROLE = 'APP' OR ROLE = 'APPCLI'", "ENT_ORDER ASC"))
                        {
                            Applicants.Add(
                                Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{dataRow["EID"]}'")) ??
                                new Corporation(Session)
                                {
                                    Code = dataRow["EID"].ToString(),
                                    Name =
                                        !string.IsNullOrWhiteSpace(dataRow["ORIG_NAME"].ToString())
                                            ? dataRow["ORIG_NAME"].ToString()
                                            : dataRow["TRAN_NAME"].ToString()
                                });
                        }
                        break;
                    }
            }
            var sOurNoShort = s_OurNo.Substring(0, s_OurNo.IndexOf("-", StringComparison.Ordinal));
            if (sOurNoShort.Contains("I"))
                s_PatentType = EnumsAll.PatentType.发明;
            else if (sOurNoShort.Contains("U"))
                s_PatentType = EnumsAll.PatentType.实用新型;
            else if (sOurNoShort.Contains("D"))
                s_PatentType = EnumsAll.PatentType.外观设计;
            else if (sOurNoShort.Contains("CR"))
                s_PatentType = EnumsAll.PatentType.软件著作权;
            Save();
        }
    }
}