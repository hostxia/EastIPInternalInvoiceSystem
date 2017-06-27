using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CaseBase : BaseObject
    {
        public CaseBase(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            s_ApplicantCodes = string.Join(";", Applicants.Select(a => a.Code).ToList());
            s_ApplicantNames = string.Join(";", Applicants.Select(a => a.Name).ToList());
            base.OnSaving();
        }

        private Corporation client;
        //[Association("Client-Cases")]
        public Corporation Client
        {
            get { return client; }
            set { SetPropertyValue("Client", ref client, value); }
        }

        private Corporation agency;
        //[Association("Agency-Cases")]
        public Corporation Agency
        {
            get { return agency; }
            set { SetPropertyValue("Agency", ref agency, value); }
        }

        //private Corporation introducer;

        //public Corporation Introducer
        //{
        //    get { return introducer; }
        //    set { SetPropertyValue("Introducer", ref introducer, value); }
        //}

        private string _sOurNo;
        [ImmediatePostData]
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }



        private DateTime _dtReceiveDate;
        public DateTime dt_ReceiveDate
        {
            get { return _dtReceiveDate; }
            set { SetPropertyValue("dt_ReceiveDate", ref _dtReceiveDate, value); }
        }

        private DateTime _dtTransferDate;
        public DateTime dt_TransferDate
        {
            get { return _dtTransferDate; }
            set { SetPropertyValue("dt_TransferDate", ref _dtTransferDate, value); }
        }

        private bool _bIsSepcified;
        public bool b_IsSepcified
        {
            get { return _bIsSepcified; }
            set { SetPropertyValue("b_IsSepcified", ref _bIsSepcified, value); }
        }

        private bool _bIsMiddle;
        public bool b_IsMiddle
        {
            get { return _bIsMiddle; }
            set { SetPropertyValue("b_IsMiddle", ref _bIsMiddle, value); }
        }

        private bool _bIsApplication;
        public bool b_IsApplication
        {
            get { return _bIsApplication; }
            set { SetPropertyValue("b_IsApplication", ref _bIsApplication, value); }
        }

        private bool _bIsDivCase;
        public bool b_IsDivCase
        {
            get { return _bIsDivCase; }
            set { SetPropertyValue("b_IsDivCase", ref _bIsDivCase, value); }
        }

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        [Association("Applicants-Cases")]
        public XPCollection<Corporation> Applicants => GetCollection<Corporation>("Applicants");


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

        public void GetCaseInfo()
        {
            EnumsAll.CaseType caseType = EnumsAll.CaseType.Internal;
            s_OurNo = CommonFunction.GetOurNo(_sOurNo, ref caseType);
            if (string.IsNullOrEmpty(s_OurNo)) return;
            switch (caseType)
            {
                case EnumsAll.CaseType.Internal:
                    {
                        var dr = DbHelperOra.Query(
                             $"select RECEIVED,CLIENT,CLIENT_NAME,APPL_CODE1,APPLICANT1,APPLICANT_CH1,APPL_CODE2,APPLICANT2,APPLICANT_CH2,APPL_CODE3,APPLICANT3,APPLICANT_CH3,APPL_CODE4,APPLICANT4,APPLICANT_CH4,APPL_CODE5,APPLICANT5,APPLICANT_CH5 from PATENTCASE where OURNO = '{_sOurNo}'").Tables[0].Rows[0];
                        if (!string.IsNullOrWhiteSpace(dr["RECEIVED"].ToString()))
                            dt_ReceiveDate = Convert.ToDateTime(dr["RECEIVED"].ToString());
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
                        break;
                    }
                case EnumsAll.CaseType.Foreign:
                    {
                        var dr = DbHelperOra.Query(
                                $"select RECEIVED from FCASE where OURNO = '{_sOurNo}'")
                            .Tables[0].Rows[0];
                        if (!string.IsNullOrWhiteSpace(dr["RECEIVED"].ToString()))
                            dt_ReceiveDate = Convert.ToDateTime(dr["RECEIVED"].ToString());

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

                        var tempagency = dt.Select("ROLE = 'AGT'");
                        if (tempagency.Length > 0)
                            Agency =
                                Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{tempagency[0]["EID"]}'")) ??
                                new Corporation(Session)
                                {
                                    Code = tempagency[0]["EID"].ToString(),
                                    Name = !string.IsNullOrWhiteSpace(tempagency[0]["ORIG_NAME"].ToString())
                                                ? tempagency[0]["ORIG_NAME"].ToString()
                                                : tempagency[0]["TRAN_NAME"].ToString()
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
            Save();
        }
    }
}