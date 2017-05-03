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

namespace EastIPInternalInvoiceSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultListViewOptions(true, NewItemRowPosition.Bottom)]
    public class WorkItem : BaseObject
    {
        public WorkItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Creator = Worker = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
            dt_Created = dt_WorkDate = DateTime.Now;
        }


        private SysUser fWorker;
        public SysUser Worker
        {
            get { return fWorker; }
            set { SetPropertyValue("n_SysUserId", ref fWorker, value); }
        }

        private DateTime _dt_WorkDate;
        public DateTime dt_WorkDate
        {
            get { return _dt_WorkDate; }
            set { SetPropertyValue("dt_WorkDate", ref _dt_WorkDate, value); }
        }

        private EnumsAll.WorkItemState _nState;
        public EnumsAll.WorkItemState State
        {
            get { return _nState; }
            set { SetPropertyValue("n_State", ref _nState, value); }
        }

        decimal fn_Quantity;
        public decimal n_Quantity
        {
            get { return fn_Quantity; }
            set { SetPropertyValue<decimal>("n_Quantity", ref fn_Quantity, value); }
        }

        private string fs_Description;
        public string s_Description
        {
            get { return fs_Description; }
            set { SetPropertyValue<string>("s_Description", ref fs_Description, value); }
        }

        private string _sOurNo;
        public string s_OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        private EnumsAll.WorkType _nWorkType;
        public EnumsAll.WorkType WorkType
        {
            get { return _nWorkType; }
            set { SetPropertyValue("n_WorkType", ref _nWorkType, value); }
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

        private DateTime fdt_SubmitDate;
        public DateTime dt_SubmitDate
        {
            get { return fdt_SubmitDate; }
            set { SetPropertyValue("dt_SubmitDate", ref fdt_SubmitDate, value); }
        }

        #region 审批信息
        private DateTime fdt_DepartApprovalDate;
        public DateTime dt_DepartApprovalDate
        {
            get { return fdt_DepartApprovalDate; }
            set { SetPropertyValue("dt_DepartApprovalDate", ref fdt_DepartApprovalDate, value); }
        }

        private SysUser fDepartApprover;
        public SysUser DepartApprover
        {
            get { return fDepartApprover; }
            set { SetPropertyValue("n_DepartApproverId", ref fDepartApprover, value); }
        }

        decimal fn_BillingQuantity;
        public decimal n_BillingQuantity
        {
            get { return fn_BillingQuantity; }
            set { SetPropertyValue<decimal>("n_BillingQuantity", ref fn_BillingQuantity, value); }
        }

        decimal fn_RewardQuantity;
        public decimal n_RewardQuantity
        {
            get { return fn_RewardQuantity; }
            set { SetPropertyValue<decimal>("n_RewardQuantity", ref fn_RewardQuantity, value); }
        }
        #endregion
    }
}