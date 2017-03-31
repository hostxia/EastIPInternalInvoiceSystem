using System;
using System.ComponentModel;
using System.Linq;
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

        public string FirmNo
        {
            get { return _sFirmNo; }
            set { SetPropertyValue("s_FirmNo", ref _sFirmNo, value); }
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

        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { SetPropertyValue("s_InvoiceNo", ref _sInvoiceNo, value); }
        }

        public string Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        public string InvoiceNote
        {
            get { return _sInvoiceNote; }
            set { SetPropertyValue("s_InvoiceNote", ref _sInvoiceNote, value); }
        }

        public bool IsInvalid
        {
            get { return _bIsInvalid; }
            set { SetPropertyValue("b_IsInvalid", ref _bIsInvalid, value); }
        }

        public bool NoNeedInvoice
        {
            get { return _bNoNeedInvoice; }
            set { SetPropertyValue("b_NoNeedInvoice", ref _bNoNeedInvoice, value); }
        }

        public bool IsFAgencyInvoice
        {
            get { return _bIsFAgencyInvoice; }
            set { SetPropertyValue("b_IsFAgencyInvoice", ref _bIsFAgencyInvoice, value); }
        }

        public DateTime InvoiceLogDate
        {
            get { return _dtInvoiceLogDate; }
            set { SetPropertyValue("s_InvoiceLogDate", ref _dtInvoiceLogDate, value); }
        }

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

        public void GenerateInternalNo()
        {
            if (string.IsNullOrWhiteSpace(_sInternalNo))
            {
                InternalNo = GetMaxFlow();
                PermissionPolicyUser = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
            }
        }

        public string GetMaxFlow()
        {
            var sInternalNo =
                new XPQuery<InternalInvoice>(Session).Where(
                        i => i.CreateDate >= CreateDate.Date && i.CreateDate < CreateDate.AddDays(1).Date)
                    .Select(i => i.InternalNo)
                    .OrderByDescending(i => i)
                    .FirstOrDefault();
            if (string.IsNullOrWhiteSpace(sInternalNo))
                return CreateDate.ToString("yyMMdd") + 1.ToString("0000");
            return CreateDate.ToString("yyMMdd") + (Convert.ToInt32(sInternalNo.Substring(6, 4)) + 1).ToString("0000");
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
                            $"select eid,role,orig_name from fcase_ent_rel where ourno = '{sCaseNo.Replace("'", "''")}' order by ent_order asc")
                        .Tables[0];
                if (dtFResult.Rows.Count > 0)
                {
                    var drsClient = dtFResult.Select("role = 'CLI' or role = 'APPCLI'");
                    var drsApp = dtFResult.Select("role = 'APP' or role = 'APPCLI'");
                    if (drsClient.Length > 0)
                    {
                        ClientNo = drsClient[0]["eid"]?.ToString();
                        ClientName = drsClient[0]["orig_name"]?.ToString();
                    }
                    if (drsApp.Length > 0)
                    {
                        AppName = drsApp[0]?["orig_name"].ToString();
                        AppNo = drsApp[0]?["eid"].ToString();
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