using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Utils.MVVM.Services;
using DevExpress.Xpo;
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class CaseExtension : BaseObject, ISupportNotifications
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

        private DateTime fdt_ExtendDate2;
        public DateTime dt_ExtendDate2
        {
            get { return fdt_ExtendDate2; }
            set { SetPropertyValue("dt_ExtendDate2", ref fdt_ExtendDate2, value); }
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
                    if (fn_State == EnumsAll.CaseExtensionState.部门审核 && (value == EnumsAll.CaseExtensionState.部门审核未通过 || value == EnumsAll.CaseExtensionState.修改延期))
                    {
                        AlarmTime = dt_DepartApprovalDate = DateTime.Now;
                        IsPostponed = false;
                        DepartApprover = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    }
                    else if (fn_State == EnumsAll.CaseExtensionState.修改延期 && (value == EnumsAll.CaseExtensionState.修改延期未通过 || value == EnumsAll.CaseExtensionState.确认延期))
                    {
                        AlarmTime = dt_ModifyApprovalDate = DateTime.Now;
                        IsPostponed = false;
                        ModifyApprover = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    }
                    else if (fn_State == EnumsAll.CaseExtensionState.确认延期 && value == EnumsAll.CaseExtensionState.确认延期通过)
                    {
                        AlarmTime = dt_ConfirmApprovalDate = DateTime.Now;
                        IsPostponed = false;
                        ConfirmApprover = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                    }
                    else if (fn_State == EnumsAll.CaseExtensionState.未提交 && (value == EnumsAll.CaseExtensionState.部门审核 || value == EnumsAll.CaseExtensionState.修改延期))
                    {
                        AlarmTime = DateTime.Now;
                        IsPostponed = false;
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


        private EnumsAll.CaseExtensionItem? fn_ExtendItem2;
        public EnumsAll.CaseExtensionItem? n_ExtendItem2
        {
            get { return fn_ExtendItem2; }
            set { SetPropertyValue("n_ExtendItem2", ref fn_ExtendItem2, value); }
        }

        #region 部门审批
        private SysUser fDepartApprover;
        public SysUser DepartApprover
        {
            get { return fDepartApprover; }
            set { SetPropertyValue("n_DepartApproverId", ref fDepartApprover, value); }
        }

        //private EnumsAll.ApprovalState fn_DepartApprovalState;
        //public EnumsAll.ApprovalState n_DepartApprovalState
        //{
        //    get { return fn_DepartApprovalState; }
        //    set { SetPropertyValue("n_DepartApprovalState", ref fn_DepartApprovalState, value); }
        //}

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

        //private EnumsAll.ApprovalState fn_ModifyApprovalState;
        //public EnumsAll.ApprovalState n_ModifyApprovalState
        //{
        //    get { return fn_ModifyApprovalState; }
        //    set { SetPropertyValue("n_ModifyApprovalState", ref fn_ModifyApprovalState, value); }
        //}

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
            var sOurNo = sCaseNo;
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
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }

        protected override void OnLoading()
        {
            base.OnLoading();
        }

        #region 通知成员

        private DateTime? alarmTime;
        [Browsable(false)]
        public DateTime? AlarmTime
        {
            get { return alarmTime; }
            set { SetPropertyValue("AlarmTime", ref alarmTime, value); }
        }

        [Browsable(false), NonPersistent]
        public object UniqueId => Oid;

        [Browsable(false), NonPersistent]
        public string NotificationMessage => fs_OurNo + ": " + fn_ExtendItem;

        private bool isPostponed;

        [Browsable(false)]
        public bool IsPostponed
        {
            get { return isPostponed; }
            set { SetPropertyValue("IsPostponed", ref isPostponed, value); }
        }
        #endregion
    }
}