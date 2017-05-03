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
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using EastIPInternalInvoiceSystem.Module.DBUtility;

namespace EastIPInternalInvoiceSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CaseExtension : BaseObject
    {
        public CaseExtension(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Creator = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
            dt_Created = DateTime.Now;
        }
        private string fs_OurNo;
        public string s_OurNo
        {
            get { return fs_OurNo; }
            set { SetPropertyValue("s_OurNo", ref fs_OurNo, value); }
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

        private SysUser fOwner;
        public SysUser Owner
        {
            get { return fOwner; }
            set { SetPropertyValue("n_OwnerId", ref fOwner, value); }
        }

        private SysUser fCreator;
        public SysUser Creator
        {
            get { return fCreator; }
            set { SetPropertyValue("n_CreatorId", ref fCreator, value); }
        }

        private DateTime fdt_Created;
        public DateTime dt_Created
        {
            get { return fdt_Created; }
            set { SetPropertyValue("dt_Created", ref fdt_Created, value); }
        }

        private DateTime fdt_ExtendDate;
        public DateTime dt_ExtendDate
        {
            get { return fdt_ExtendDate; }
            set { SetPropertyValue("dt_ExtendDate", ref fdt_ExtendDate, value); }
        }

        //private string fs_ExtendItem;
        //public string s_ExtendItem
        //{
        //    get { return fs_ExtendItem; }
        //    set { SetPropertyValue("s_ExtendItem", ref fs_ExtendItem, value); }
        //}

        private string fs_ExtendNote;
        public string s_ExtendNote
        {
            get { return fs_ExtendNote; }
            set { SetPropertyValue("s_ExtendNote", ref fs_ExtendNote, value); }
        }

        private string fs_AlertWay;
        public string s_AlertWay
        {
            get { return fs_AlertWay; }
            set { SetPropertyValue("s_AlertWay", ref fs_AlertWay, value); }
        }

        private bool fb_OurProblem;
        [CaptionsForBoolValues("我方原因", "客户原因")]
        public bool b_OurProblem
        {
            get { return fb_OurProblem; }
            set { SetPropertyValue("b_OurProblem", ref fb_OurProblem, value); }
        }

        private EnumsAll.CaseExtensionState fn_State;
        public EnumsAll.CaseExtensionState n_State
        {
            get { return fn_State; }
            set
            {
                if (!IsLoading)
                {
                    if (value == EnumsAll.CaseExtensionState.部门审核未通过 || value == EnumsAll.CaseExtensionState.修改延期)
                    {
                        dt_DepartApprovalDate = DateTime.Now;
                        DepartApprover = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    }
                    else if (value == EnumsAll.CaseExtensionState.修改延期未通过 || value == EnumsAll.CaseExtensionState.确认延期)
                    {
                        dt_ModifyApprovalDate = DateTime.Now;
                        ModifyApprover = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    }
                    else if (value == EnumsAll.CaseExtensionState.确认延期通过)
                    {
                        dt_ConfirmApprovalDate = DateTime.Now;
                        ConfirmApprover = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    }
                }
                SetPropertyValue("n_State", ref fn_State, value);
            }
        }

        private EnumsAll.CaseExtensionItem fn_ExtendItem;
        public EnumsAll.CaseExtensionItem n_ExtendItem
        {
            get { return fn_ExtendItem; }
            set { SetPropertyValue("n_ExtendItem", ref fn_ExtendItem, value); }
        }

        #region 部门审批
        private SysUser fDepartApprover;
        public SysUser DepartApprover
        {
            get { return fDepartApprover; }
            set { SetPropertyValue("n_DepartApproverId", ref fDepartApprover, value); }
        }

        private EnumsAll.ApprovalState fn_DepartApprovalState;
        public EnumsAll.ApprovalState n_DepartApprovalState
        {
            get { return fn_DepartApprovalState; }
            set { SetPropertyValue("n_DepartApprovalState", ref fn_DepartApprovalState, value); }
        }

        private string fs_DepartReason;
        public string s_DepartReason
        {
            get { return fs_DepartReason; }
            set { SetPropertyValue("s_DepartReason", ref fs_DepartReason, value); }
        }

        private DateTime fdt_DepartApprovalDate;
        public DateTime dt_DepartApprovalDate
        {
            get { return fdt_DepartApprovalDate; }
            set { SetPropertyValue("dt_DepartApprovalDate", ref fdt_DepartApprovalDate, value); }
        }
        #endregion

        #region 修改审批
        private SysUser fModifyApprover;
        public SysUser ModifyApprover
        {
            get { return fModifyApprover; }
            set { SetPropertyValue("n_ModifyApproverId", ref fModifyApprover, value); }
        }

        private EnumsAll.ApprovalState fn_ModifyApprovalState;
        public EnumsAll.ApprovalState n_ModifyApprovalState
        {
            get { return fn_ModifyApprovalState; }
            set { SetPropertyValue("n_ModifyApprovalState", ref fn_ModifyApprovalState, value); }
        }

        private string fs_ModifyReason;
        public string s_ModifyReason
        {
            get { return fs_ModifyReason; }
            set { SetPropertyValue("s_ModifyReason", ref fs_ModifyReason, value); }
        }

        private DateTime fdt_ModifyApprovalDate;
        public DateTime dt_ModifyApprovalDate
        {
            get { return fdt_ModifyApprovalDate; }
            set { SetPropertyValue("dt_ModifyApprovalDate", ref fdt_ModifyApprovalDate, value); }
        }
        #endregion

        #region 确认审批
        private SysUser fConfirmApprover;
        public SysUser ConfirmApprover
        {
            get { return fConfirmApprover; }
            set { SetPropertyValue("n_ConfirmApproverId", ref fConfirmApprover, value); }
        }

        private DateTime fdt_ConfirmApprovalDate;
        public DateTime dt_ConfirmApprovalDate
        {
            get { return fdt_ConfirmApprovalDate; }
            set { SetPropertyValue("dt_ConfirmApprovalDate", ref fdt_ConfirmApprovalDate, value); }
        }
        #endregion

        public void SetCaseInfo(string sCaseNo)
        {
            if (string.IsNullOrWhiteSpace(sCaseNo)) return;
            try
            {
                var dtResult =
                    DbHelperOra.Query(
                            $"select ourno,client,client_name,appl_code1,applicant_ch1 from patentcase where ourno like '%{sCaseNo.ToUpper().Replace("'", "''")}%'")
                        .Tables[0];
                if (dtResult.Rows.Count > 0)
                {
                    s_OurNo = dtResult.Rows[0]["ourno"].ToString();
                    s_ClientNo = dtResult.Rows[0]["client"].ToString();
                    s_Client = dtResult.Rows[0]["client_name"].ToString();
                    s_Applicant = dtResult.Rows[0]["applicant_ch1"].ToString();
                    s_ApplicantNo = dtResult.Rows[0]["appl_code1"].ToString();
                    return;
                }
                var dtFResult =
                    DbHelperOra.Query(
                            $"select eid,role,orig_name,tran_name,ourno from fcase_ent_rel where ourno like '%{sCaseNo.ToUpper().Replace("'", "''")}%' order by ent_order asc")
                        .Tables[0];
                if (dtFResult.Rows.Count > 0)
                {
                    s_OurNo = dtResult.Rows[0]["ourno"].ToString();
                    var drsClient = dtFResult.Select("role = 'CLI' or role = 'APPCLI'");
                    var drsApp = dtFResult.Select("role = 'APP' or role = 'APPCLI'");
                    if (drsClient.Length > 0)
                    {
                        s_ClientNo = drsClient[0]["eid"]?.ToString();
                        s_Client = drsClient[0]["orig_name"]?.ToString();
                        if (string.IsNullOrWhiteSpace(s_Client))
                            s_Client = drsClient[0]["tran_name"]?.ToString();
                    }
                    if (drsApp.Length > 0)
                    {
                        s_ApplicantNo = drsApp[0]["eid"]?.ToString();
                        s_Applicant = drsApp[0]["orig_name"]?.ToString();
                        if (string.IsNullOrWhiteSpace(s_Applicant))
                            s_Applicant = drsApp[0]["tran_name"]?.ToString();
                    }
                    return;
                }
                var dtHResult =
                    DbHelperOra.Query(
                            $"select p.client,p.client_name,p.appl_code1,p.applicant_ch1,h.hk_app_ref from ex_hkcase h,patentcase p where p.ourno(+) = h.cn_app_ref and h.hk_app_ref like '%{sCaseNo.ToUpper().Replace("'", "''")}%'")
                        .Tables[0];
                if (dtHResult.Rows.Count > 0)
                {
                    s_OurNo = dtResult.Rows[0]["hk_app_ref"].ToString();
                    s_ClientNo = dtHResult.Rows[0]["client"].ToString();
                    s_Client = dtHResult.Rows[0]["client_name"].ToString();
                    s_Applicant = dtHResult.Rows[0]["applicant_ch1"].ToString();
                    s_ApplicantNo = dtHResult.Rows[0]["appl_code1"].ToString();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}