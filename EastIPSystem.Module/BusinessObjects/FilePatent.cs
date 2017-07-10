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
    public class FilePatent : BaseObject
    {
        public FilePatent(Session session)
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

        private DateTime _dtReceiveDate;
        public DateTime dt_ReceiveDate
        {
            get { return _dtReceiveDate; }
            set { SetPropertyValue("dt_ReceiveDate", ref _dtReceiveDate, value); }
        }

        private string _sOurNo;
        [ImmediatePostData]
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

        private Corporation client;
        public Corporation Client
        {
            get { return client; }
            set { SetPropertyValue("Client", ref client, value); }
        }

        [Association("Applicants-FilePatents")]
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

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        private bool _bIsFinish;
        public bool b_IsFinish
        {
            get { return _bIsFinish; }
            set { SetPropertyValue("b_IsFinish", ref _bIsFinish, value); }
        }

        public void GetCaseInfo()
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
                             $"select RECEIVED,CLIENT,CLIENT_NAME,APPL_CODE1,APPLICANT1,APPLICANT_CH1,APPL_CODE2,APPLICANT2,APPLICANT_CH2,APPL_CODE3,APPLICANT3,APPLICANT_CH3,APPL_CODE4,APPLICANT4,APPLICANT_CH4,APPL_CODE5,APPLICANT5,APPLICANT_CH5,APPLICATION_NO,WITHDREW from PATENTCASE where OURNO = '{_sOurNo}'").Tables[0].Rows[0];
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
                        s_AppNo = dr[$"APPLICATION_NO"].ToString();
                        b_IsFinish = !string.IsNullOrWhiteSpace(dr[$"WITHDREW"].ToString());
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

                        //var tempagency = dt.Select("ROLE = 'AGT'");
                        //if (tempagency.Length > 0)
                        //    Agency =
                        //        Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{tempagency[0]["EID"]}'")) ??
                        //        new Corporation(Session)
                        //        {
                        //            Code = tempagency[0]["EID"].ToString(),
                        //            Name = !string.IsNullOrWhiteSpace(tempagency[0]["ORIG_NAME"].ToString())
                        //                        ? tempagency[0]["ORIG_NAME"].ToString()
                        //                        : tempagency[0]["TRAN_NAME"].ToString()
                        //        };


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
                case EnumsAll.CaseType.Hongkong:
                    {
                        var dr = DbHelperOra.Query($"select cn_app_ref,RECEIVED from ex_hkcase where hk_app_ref = '{_sOurNo}'").Tables[0].Rows[0];
                        if (!string.IsNullOrWhiteSpace(dr["RECEIVED"]?.ToString()))
                        {
                            dt_ReceiveDate = Convert.ToDateTime(dr["RECEIVED"].ToString());
                        }
                        if (!string.IsNullOrWhiteSpace(dr["cn_app_ref"]?.ToString()))
                        {
                            var drCN = DbHelperOra.Query(
     $"select RECEIVED,CLIENT,CLIENT_NAME,APPL_CODE1,APPLICANT1,APPLICANT_CH1,APPL_CODE2,APPLICANT2,APPLICANT_CH2,APPL_CODE3,APPLICANT3,APPLICANT_CH3,APPL_CODE4,APPLICANT4,APPLICANT_CH4,APPL_CODE5,APPLICANT5,APPLICANT_CH5 from PATENTCASE where OURNO = '{dr["cn_app_ref"]?.ToString()}'").Tables[0].Rows[0];
                            if (!string.IsNullOrWhiteSpace(drCN["CLIENT"].ToString()))
                                Client =
                                    Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{drCN["CLIENT"]}'")) ??
                                    new Corporation(Session)
                                    {
                                        Code = drCN["CLIENT"].ToString(),
                                        Name = drCN["CLIENT_NAME"].ToString()
                                    };

                            Applicants.ToList().ForEach(a => Applicants.Remove(a));
                            for (int i = 1; i <= 5; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(drCN[$"APPL_CODE{i}"].ToString()))
                                {
                                    Applicants.Add(
                                        Session.FindObject<Corporation>(CriteriaOperator.Parse($"Code = '{drCN[$"APPL_CODE{i}"]}'")) ??
                                        new Corporation(Session)
                                        {
                                            Code = drCN[$"APPL_CODE{i}"].ToString(),
                                            Name =
                                                string.IsNullOrWhiteSpace(drCN[$"APPLICANT{i}"].ToString())
                                                    ? drCN[$"APPLICANT_CH{i}"].ToString()
                                                    : drCN[$"APPLICANT{i}"].ToString()
                                        });
                                }
                            }
                        }
                        break;
                    }
            }
            Save();
        }
    }
}