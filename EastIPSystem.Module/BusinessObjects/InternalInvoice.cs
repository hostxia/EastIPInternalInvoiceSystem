using System;
using System.ComponentModel;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using EastIPSystem.Module.DBUtility;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
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

        private SysUser _permissionPolicyUser;

        private SysUser _sAgent1;

        private SysUser _sAgent2;

        private SysUser _sAgent3;

        private SysUser _sAgent4;

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

        public InternalInvoice(Session session)
            : base(session)
        {
        }

        private Invoice invoice;
        [Association]
        [Browsable(false)]
        public Invoice Invoice
        {
            get { return invoice; }
            set { SetPropertyValue("Invoice", ref invoice, value); }
        }

        public DateTime CreateDate
        {
            get { return _dtCreateDate; }
            set { SetPropertyValue("CreateDate", ref _dtCreateDate, value); }
        }

        public string OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("OurNo", ref _sOurNo, value); }
        }

        public string ClientNo
        {
            get { return _sClientNo; }
            set { SetPropertyValue("ClientNo", ref _sClientNo, value); }
        }

        public string ClientName
        {
            get { return _sClientName; }
            set { SetPropertyValue("ClientName", ref _sClientName, value); }
        }

        public string AppNo
        {
            get { return _sAppNo; }
            set { SetPropertyValue("AppNo", ref _sAppNo, value); }
        }

        public string AppName
        {
            get { return _sAppName; }
            set { SetPropertyValue("AppName", ref _sAppName, value); }
        }

        public string InternalNo
        {
            get { return _sInternalNo; }
            set { SetPropertyValue("InternalNo", ref _sInternalNo, value); }
        }

        public string Content
        {
            get { return _sContent; }
            set { SetPropertyValue("Content", ref _sContent, value); }
        }

        public string Type
        {
            get { return _sType; }
            set { SetPropertyValue("Type", ref _sType, value); }
        }

        [NoForeignKey]
        public SysUser Agent1
        {
            get { return _sAgent1; }
            set { SetPropertyValue("Agent1", ref _sAgent1, value); }
        }

        [NoForeignKey]
        public SysUser Agent2
        {
            get { return _sAgent2; }
            set { SetPropertyValue("Agent2", ref _sAgent2, value); }
        }

        [NoForeignKey]
        public SysUser Agent3
        {
            get { return _sAgent3; }
            set { SetPropertyValue("Agent3", ref _sAgent3, value); }
        }

        [NoForeignKey]
        public SysUser Agent4
        {
            get { return _sAgent4; }
            set { SetPropertyValue("Agent4", ref _sAgent4, value); }
        }

        public DateTime SendDate
        {
            get { return _dtSendDate; }
            set { SetPropertyValue("SendDate", ref _dtSendDate, value); }
        }

        public DateTime Deadline
        {
            get { return _dtDeadline; }
            set { SetPropertyValue("Deadline", ref _dtDeadline, value); }
        }

        public string Note
        {
            get { return _sNote; }
            set { SetPropertyValue("Note", ref _sNote, value); }
        }

        public bool IsInvalid
        {
            get { return _bIsInvalid; }
            set { SetPropertyValue("IsInvalid", ref _bIsInvalid, value); }
        }

        [Browsable(false)]
        [Association("InternalInvoice-PatentSubmitLists")]
        public XPCollection<PatentSubmitList> PatentSubmitLists => GetCollection<PatentSubmitList>("PatentSubmitLists");

        #region 账单信息
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { SetPropertyValue("InvoiceNo", ref _sInvoiceNo, value); }
        }

        public string InvoiceNote
        {
            get { return _sInvoiceNote; }
            set { SetPropertyValue("InvoiceNote", ref _sInvoiceNote, value); }
        }

        public bool NoNeedInvoice
        {
            get { return _bNoNeedInvoice; }
            set { SetPropertyValue("NoNeedInvoice", ref _bNoNeedInvoice, value); }
        }

        public DateTime InvoiceLogDate
        {
            get { return _dtInvoiceLogDate; }
            set { SetPropertyValue("InvoiceLogDate", ref _dtInvoiceLogDate, value); }
        }
        #endregion

        public EnumsAll.InternalType InternalType
        {
            get { return _nInternalType; }
            set { SetPropertyValue("InternalType", ref _nInternalType, value); }
        }

        [NoForeignKey]
        public SysUser PermissionPolicyUser
        {
            get { return _permissionPolicyUser; }
            set { SetPropertyValue("PermissionPolicyUser", ref _permissionPolicyUser, value); }
        }

        [Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData InvoiceFile
        {
            get { return _sInvoiceFile; }
            set { SetPropertyValue("InvoiceFile", ref _sInvoiceFile, value); }
        }

        #region 第三方账单信息

        private bool fb_IsNotInternalInvoice;
        public bool b_IsNotInternalInvoice
        {
            get { return fb_IsNotInternalInvoice; }
            set { SetPropertyValue("b_IsNotInternalInvoice", ref fb_IsNotInternalInvoice, value); }
        }

        public string FirmNo
        {
            get { return _sFirmNo; }
            set { SetPropertyValue("FirmNo", ref _sFirmNo, value); }
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

        decimal fn_Hour;
        public decimal n_Hour
        {
            get { return fn_Hour; }
            set { SetPropertyValue<decimal>("n_Hour", ref fn_Hour, value); }
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
            set { SetPropertyValue("FInvoiceFile", ref _sFInvoiceFile, value); }
        }
        #endregion

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            CreateDate = DateTime.Now;
            SendDate = CreateDate.AddDays(3);
            Deadline = CreateDate.AddDays(7);
        }
        protected override void OnSaving()
        {
            base.OnSaving();
        }
        [Browsable(false)]
        public bool InternalNoUnique
        {
            get
            {
                if (string.IsNullOrWhiteSpace(InternalNo)) return true;
                XPCollection<InternalInvoice> xpc;
                using (xpc = new XPCollection<InternalInvoice>(new UnitOfWork(Session.DataLayer), CriteriaOperator.Parse($"InternalNo = '{InternalNo}' And Oid != '{Oid}'")))
                {
                    return xpc.Count == 0;
                }
            }
        }

        public void GenerateInternalNo()
        {
            //if (!string.IsNullOrWhiteSpace(_sInvoiceNo)) return;
            InternalNo = GetMaxFlow();
            PermissionPolicyUser = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
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