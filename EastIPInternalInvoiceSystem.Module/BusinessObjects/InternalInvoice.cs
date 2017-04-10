﻿using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using EastIPInternalInvoiceSystem.Module.DBUtility;

namespace EastIPInternalInvoiceSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [FileAttachment("InvoiceFile")]
    [DefaultProperty("InternalNo")]
    public class InternalInvoice : XPObject
    {
        private bool _bIsFAgencyInvoice;

        private bool _bIsInvalid;

        private bool _bNoNeedInvoice;

        private DateTime _dtCreateDate;

        private DateTime _dtDeadline;

        private DateTime _dtInvoiceLogDate;

        private DateTime _dtSendDate; //CreateDate + 3天

        private EnumsAll.InternalType _nInternalType;

        private PermissionPolicyUser _permissionPolicyUser;

        private InternalAgent _sAgent1;

        private InternalAgent _sAgent2;

        private InternalAgent _sAgent3;

        private InternalAgent _sAgent4;

        private string _sAppName;

        private string _sAppNo;


        private string _sClientName;

        private string _sClientNo;

        private string _sContent;

        private string _sFirmNo;


        private string _sInternalNo;

        private FileData _sInvoiceFile;

        private FileData _sFInvoiceFile;

        private string _sInvoiceNo;

        private string _sInvoiceNote;

        private string _sNote;

        private string _sOurNo;

        private string _sType;
        // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).

        public InternalInvoice(Session session)
            : base(session)
        {
        }

        public DateTime CreateDate
        {
            get { return _dtCreateDate; }
            set { SetPropertyValue("s_CreateDate", ref _dtCreateDate, value); }
        }

        public string OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        public string ClientNo
        {
            get { return _sClientNo; }
            set { SetPropertyValue("s_ClientNo", ref _sClientNo, value); }
        }

        public string ClientName
        {
            get { return _sClientName; }
            set { SetPropertyValue("s_ClientName", ref _sClientName, value); }
        }

        public string AppNo
        {
            get { return _sAppNo; }
            set { SetPropertyValue("s_AppNo", ref _sAppNo, value); }
        }

        public string AppName
        {
            get { return _sAppName; }
            set { SetPropertyValue("s_AppName", ref _sAppName, value); }
        }

        public string InternalNo
        {
            get { return _sInternalNo; }
            set { SetPropertyValue("s_InternalNo", ref _sInternalNo, value); }
        }

        public string Content
        {
            get { return _sContent; }
            set { SetPropertyValue("s_Content", ref _sContent, value); }
        }

        public string Type
        {
            get { return _sType; }
            set { SetPropertyValue("s_Type", ref _sType, value); }
        }

        [NoForeignKey]
        public InternalAgent Agent1
        {
            get { return _sAgent1; }
            set { SetPropertyValue("s_Agent1", ref _sAgent1, value); }
        }

        [NoForeignKey]
        public InternalAgent Agent2
        {
            get { return _sAgent2; }
            set { SetPropertyValue("s_Agent2", ref _sAgent2, value); }
        }

        [NoForeignKey]
        public InternalAgent Agent3
        {
            get { return _sAgent3; }
            set { SetPropertyValue("s_Agent3", ref _sAgent3, value); }
        }

        [NoForeignKey]
        public InternalAgent Agent4
        {
            get { return _sAgent4; }
            set { SetPropertyValue("s_Agent4", ref _sAgent4, value); }
        }

        public DateTime SendDate
        {
            get { return _dtSendDate; }
            set { SetPropertyValue("s_SendDate", ref _dtSendDate, value); }
        }

        public DateTime Deadline
        {
            get { return _dtDeadline; }
            set { SetPropertyValue("s_Deadline", ref _dtDeadline, value); }
        }

        public string Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        public bool IsInvalid
        {
            get { return _bIsInvalid; }
            set { SetPropertyValue("b_IsInvalid", ref _bIsInvalid, value); }
        }

        #region 账单信息
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { SetPropertyValue("s_InvoiceNo", ref _sInvoiceNo, value); }
        }

        public string InvoiceNote
        {
            get { return _sInvoiceNote; }
            set { SetPropertyValue("s_InvoiceNote", ref _sInvoiceNote, value); }
        }

        public bool NoNeedInvoice
        {
            get { return _bNoNeedInvoice; }
            set { SetPropertyValue("b_NoNeedInvoice", ref _bNoNeedInvoice, value); }
        }

        public DateTime InvoiceLogDate
        {
            get { return _dtInvoiceLogDate; }
            set { SetPropertyValue("s_InvoiceLogDate", ref _dtInvoiceLogDate, value); }
        } 
        #endregion

        public EnumsAll.InternalType InternalType
        {
            get { return _nInternalType; }
            set { SetPropertyValue("n_InternalType", ref _nInternalType, value); }
        }

        [NoForeignKey]
        public PermissionPolicyUser PermissionPolicyUser
        {
            get { return _permissionPolicyUser; }
            set { SetPropertyValue("s_User", ref _permissionPolicyUser, value); }
        }

        [Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData InvoiceFile
        {
            get { return _sInvoiceFile; }
            set { SetPropertyValue("s_InvoiceFile", ref _sInvoiceFile, value); }
        }

        #region 第三方账单信息
        //public bool IsFAgencyInvoice
        //{
        //    get { return _bIsFAgencyInvoice; }
        //    set { SetPropertyValue("b_IsFAgencyInvoice", ref _bIsFAgencyInvoice, value); }
        //}

        public string FirmNo
        {
            get { return _sFirmNo; }
            set { SetPropertyValue("s_FirmNo", ref _sFirmNo, value); }
        }

        string fs_Currency;
        [Size(255)]
        public string s_Currency
        {
            get { return fs_Currency; }
            set { SetPropertyValue<string>("s_Currency", ref fs_Currency, value); }
        }

        decimal fn_FeeTotal;
        public decimal n_FeeTotal
        {
            get { return fn_FeeTotal; }
            set { SetPropertyValue<decimal>("n_FeeTotal", ref fn_FeeTotal, value); }
        }

        float fn_Hour;
        public float n_Hour
        {
            get { return fn_Hour; }
            set { SetPropertyValue<float>("n_Hour", ref fn_Hour, value); }
        }

        decimal fn_FeeAgent;
        public decimal n_FeeAgent
        {
            get { return fn_FeeAgent; }
            set { SetPropertyValue<decimal>("n_FeeAgent", ref fn_FeeAgent, value); }
        }

        decimal fn_FeeTranslation;
        public decimal n_FeeTranslation
        {
            get { return fn_FeeTranslation; }
            set { SetPropertyValue<decimal>("n_FeeTranslation", ref fn_FeeTranslation, value); }
        }

        decimal fn_FeeService;
        public decimal n_FeeService
        {
            get { return fn_FeeService; }
            set { SetPropertyValue<decimal>("n_FeeService", ref fn_FeeService, value); }
        }

        decimal fn_FeeDistribution;
        public decimal n_FeeDistribution
        {
            get { return fn_FeeDistribution; }
            set { SetPropertyValue<decimal>("n_FeeDistribution", ref fn_FeeDistribution, value); }
        }

        decimal fn_FeeOfficial;
        public decimal n_FeeOfficial
        {
            get { return fn_FeeOfficial; }
            set { SetPropertyValue<decimal>("n_FeeOfficial", ref fn_FeeOfficial, value); }
        }

        string fs_ForeignAgency;
        [Size(255)]
        public string s_ForeignAgency
        {
            get { return fs_ForeignAgency; }
            set { SetPropertyValue<string>("s_ForeignAgency", ref fs_ForeignAgency, value); }
        }

        DateTime fdt_DateApplication;
        public DateTime dt_DateApplication
        {
            get { return fdt_DateApplication; }
            set { SetPropertyValue<DateTime>("dt_DateApplication", ref fdt_DateApplication, value); }
        }

        DateTime fdt_DateApproval;
        public DateTime dt_DateApproval
        {
            get { return fdt_DateApproval; }
            set { SetPropertyValue<DateTime>("dt_DateApproval", ref fdt_DateApproval, value); }
        }

        DateTime fdt_DateForeignInvoice;
        public DateTime dt_DateForeignInvoice
        {
            get { return fdt_DateForeignInvoice; }
            set { SetPropertyValue<DateTime>("dt_DateForeignInvoice", ref fdt_DateForeignInvoice, value); }
        }

        [Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData FInvoiceFile
        {
            get { return _sFInvoiceFile; }
            set { SetPropertyValue("s_FInvoiceFile", ref _sFInvoiceFile, value); }
        }
        #endregion

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            CreateDate = DateTime.Now;
            SendDate = CreateDate.AddDays(3);
            Deadline = CreateDate.AddDays(7);
        }

        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue("PersistentProperty", ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}

        protected override void OnSaving()
        {
            base.OnSaving();
        }

        public void GenerateInternalNo()
        {
            //if (!string.IsNullOrWhiteSpace(_sInvoiceNo)) return;
            InternalNo = GetMaxFlow();
            PermissionPolicyUser = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
        }

        public string GetMaxFlow()
        {
            var dtNow = DateTime.Now;
            var sInternalNo =
                new XPCollection<InternalInvoice>(new UnitOfWork(Session.DataLayer), CriteriaOperator.Parse($"InternalNo Like '{dtNow:yyMMdd}%' And Oid != {Oid}"))
                    .Select(i => i.InternalNo)
                    .OrderByDescending(i => i)
                    .FirstOrDefault();
            if (string.IsNullOrWhiteSpace(sInternalNo))
                return dtNow.ToString("yyMMdd") + 1.ToString("0000");
            return dtNow.ToString("yyMMdd") + (Convert.ToInt32(sInternalNo.Substring(6, 4)) + 1).ToString("0000");
        }

        public void SetCaseInfo(string sCaseNo)
        {
            try
            {
                var dtResult =
                    DbHelperOra.Query(
                            $"select client,client_name,appl_code1,applicant_ch1 from patentcase where ourno = '{sCaseNo.Replace("'", "''")}'")
                        .Tables[0];
                if (dtResult.Rows.Count > 0)
                {
                    ClientNo = dtResult.Rows[0]["client"].ToString();
                    ClientName = dtResult.Rows[0]["client_name"].ToString();
                    AppName = dtResult.Rows[0]["applicant_ch1"].ToString();
                    AppNo = dtResult.Rows[0]["appl_code1"].ToString();
                    return;
                }
                var dtFResult =
                    DbHelperOra.Query(
                            $"select eid,role,orig_name,tran_name from fcase_ent_rel where ourno = '{sCaseNo.Replace("'", "''")}' order by ent_order asc")
                        .Tables[0];
                if (dtFResult.Rows.Count > 0)
                {
                    var drsClient = dtFResult.Select("role = 'CLI' or role = 'APPCLI'");
                    var drsApp = dtFResult.Select("role = 'APP' or role = 'APPCLI'");
                    if (drsClient.Length > 0)
                    {
                        ClientNo = drsClient[0]["eid"]?.ToString();
                        ClientName = drsClient[0]["orig_name"]?.ToString();
                        if (string.IsNullOrWhiteSpace(ClientName))
                            ClientName = drsClient[0]["tran_name"]?.ToString();
                    }
                    if (drsApp.Length > 0)
                    {
                        AppNo = drsApp[0]["eid"]?.ToString();
                        AppName = drsApp[0]["orig_name"]?.ToString();
                        if (string.IsNullOrWhiteSpace(AppName))
                            AppName = drsApp[0]["tran_name"]?.ToString();
                    }
                    return;
                }
                var dtHResult =
                    DbHelperOra.Query(
                            $"select p.client,p.client_name,p.appl_code1,p.applicant_ch1 from ex_hkcase h,patentcase p where p.ourno(+) = h.cn_app_ref and h.hk_app_ref = '{sCaseNo.Replace("'", "''")}'")
                        .Tables[0];
                if (dtHResult.Rows.Count > 0)
                {
                    ClientNo = dtHResult.Rows[0]["client"].ToString();
                    ClientName = dtHResult.Rows[0]["client_name"].ToString();
                    AppName = dtHResult.Rows[0]["applicant_ch1"].ToString();
                    AppNo = dtHResult.Rows[0]["appl_code1"].ToString();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}