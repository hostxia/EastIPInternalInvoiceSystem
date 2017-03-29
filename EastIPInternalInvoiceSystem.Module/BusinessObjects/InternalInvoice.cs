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
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public InternalInvoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (string.IsNullOrWhiteSpace(_sInvoiceNo))
            {
                CreateDate = DateTime.Now;
                InternalNo = GetMaxFlow();
                PermissionPolicyUser = Session.GetObjectByKey<PermissionPolicyUser>(SecuritySystem.CurrentUserId);
                SendDate = CreateDate.AddDays(3);
            }
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private DateTime _dtCreateDate;
        public DateTime CreateDate
        {
            get { return _dtCreateDate; }
            set { SetPropertyValue("s_CreateDate", ref _dtCreateDate, value); }
        }

        private string _sOurNo;
        public string OurNo
        {
            get { return _sOurNo; }
            set { SetPropertyValue("s_OurNo", ref _sOurNo, value); }
        }

        private string _sClientNo;
        public string ClientNo
        {
            get { return _sClientNo; }
            set { SetPropertyValue("s_ClientNo", ref _sClientNo, value); }
        }


        private string _sClientName;
        public string ClientName
        {
            get { return _sClientName; }
            set { SetPropertyValue("s_ClientName", ref _sClientName, value); }
        }

        private string _sAppNo;
        public string AppNo
        {
            get { return _sAppNo; }
            set { SetPropertyValue("s_AppNo", ref _sAppNo, value); }
        }

        private string _sAppName;
        public string AppName
        {
            get { return _sAppName; }
            set { SetPropertyValue("s_AppName", ref _sAppName, value); }
        }


        private string _sInternalNo;
        public string InternalNo
        {
            get { return _sInternalNo; }
            set { SetPropertyValue("s_InternalNo", ref _sInternalNo, value); }
        }

        private string _sFirmNo;
        public string FirmNo
        {
            get { return _sFirmNo; }
            set { SetPropertyValue("s_FirmNo", ref _sFirmNo, value); }
        }

        private string _sContent;
        public string Content
        {
            get { return _sContent; }
            set { SetPropertyValue("s_Content", ref _sContent, value); }
        }

        private string _sType;
        public string Type
        {
            get { return _sType; }
            set { SetPropertyValue("s_Type", ref _sType, value); }
        }

        private InternalAgent _sAgent1;
        [NoForeignKey]
        public InternalAgent Agent1
        {
            get { return _sAgent1; }
            set { SetPropertyValue("s_Agent1", ref _sAgent1, value); }
        }

        private InternalAgent _sAgent2;
        [NoForeignKey]
        public InternalAgent Agent2
        {
            get { return _sAgent2; }
            set { SetPropertyValue("s_Agent2", ref _sAgent2, value); }
        }

        private InternalAgent _sAgent3;
        [NoForeignKey]
        public InternalAgent Agent3
        {
            get { return _sAgent3; }
            set { SetPropertyValue("s_Agent3", ref _sAgent3, value); }
        }

        private InternalAgent _sAgent4;
        [NoForeignKey]
        public InternalAgent Agent4
        {
            get { return _sAgent4; }
            set { SetPropertyValue("s_Agent4", ref _sAgent4, value); }
        }

        private DateTime _dtSendDate;//CreateDate + 3天
        public DateTime SendDate
        {
            get { return _dtSendDate; }
            set { SetPropertyValue("s_SendDate", ref _dtSendDate, value); }
        }

        private DateTime _dtDeadline;
        public DateTime Deadline
        {
            get { return _dtDeadline; }
            set { SetPropertyValue("s_Deadline", ref _dtDeadline, value); }
        }

        private string _sInvoiceNo;
        public string InvoiceNo
        {
            get { return _sInvoiceNo; }
            set { SetPropertyValue("s_InvoiceNo", ref _sInvoiceNo, value); }
        }

        private string _sNote;
        public string Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }

        private string _sInvoiceNote;
        public string InvoiceNote
        {
            get { return _sInvoiceNote; }
            set { SetPropertyValue("s_InvoiceNote", ref _sInvoiceNote, value); }
        }

        private bool _bIsInvalid;
        public bool IsInvalid
        {
            get { return _bIsInvalid; }
            set { SetPropertyValue("b_IsInvalid", ref _bIsInvalid, value); }
        }

        private bool _bNoNeedInvoice;
        public bool NoNeedInvoice
        {
            get { return _bNoNeedInvoice; }
            set { SetPropertyValue("b_NoNeedInvoice", ref _bNoNeedInvoice, value); }
        }

        private bool _bIsFAgencyInvoice;
        public bool IsFAgencyInvoice
        {
            get { return _bIsFAgencyInvoice; }
            set { SetPropertyValue("b_IsFAgencyInvoice", ref _bIsFAgencyInvoice, value); }
        }

        private EnumsAll.InternalType _nInternalType;
        public EnumsAll.InternalType InternalType
        {
            get { return _nInternalType; }
            set { SetPropertyValue("n_InternalType", ref _nInternalType, value); }
        }

        private PermissionPolicyUser _permissionPolicyUser;
        [NoForeignKey]
        public PermissionPolicyUser PermissionPolicyUser
        {
            get { return _permissionPolicyUser; }
            set { SetPropertyValue("s_User", ref _permissionPolicyUser, value); }
        }

        private FileData _sInvoiceFile;
        [DevExpress.Xpo.Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData InvoiceFile
        {
            get { return _sInvoiceFile; }
            set { SetPropertyValue("s_InvoiceFile", ref _sInvoiceFile, value); }
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

        private string GetMaxFlow()
        {
            var dtNow = DateTime.Now;
            var sInternalNo =
                new XPQuery<InternalInvoice>(Session).Where(
                        i => i.CreateDate >= dtNow.Date && i.CreateDate < dtNow.AddDays(1).Date)
                    .Select(i => i.InternalNo)
                    .OrderByDescending(i => i)
                    .FirstOrDefault();
            if (string.IsNullOrWhiteSpace(sInternalNo))
            {
                return dtNow.ToString("yyMMdd") + 1.ToString("0000");
            }
            return dtNow.ToString("yyMMdd") + (Convert.ToInt32(sInternalNo.Substring(6)) + 1).ToString("0000");
        }
    }
}