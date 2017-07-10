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

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class FileInOfficial : BaseObject
    {
        public FileInOfficial(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private FilePatent filePatent;
        [Persistent("g_FilePatentId")]
        public FilePatent FilePatent
        {
            get { return filePatent; }
            set { SetPropertyValue("FilePatent", ref filePatent, value); }
        }

        private DateTime _dtOfficialSendDate;
        public DateTime dt_OfficialSendDate
        {
            get { return _dtOfficialSendDate; }
            set { SetPropertyValue("dt_OfficialSendDate", ref _dtOfficialSendDate, value); }
        }

        private DateTime _dtReceiveDate;
        public DateTime dt_ReceiveDate
        {
            get { return _dtReceiveDate; }
            set { SetPropertyValue("dt_ReceiveDate", ref _dtReceiveDate, value); }
        }

        private bool _bIsNoNeedTransfer;
        public bool b_IsNoNeedTransfer
        {
            get { return _bIsNoNeedTransfer; }
            set { SetPropertyValue("b_IsNoNeedTransfer", ref _bIsNoNeedTransfer, value); }
        }

        private DateTime _dtTransferDate;
        public DateTime dt_TransferDate
        {
            get { return _dtTransferDate; }
            set { SetPropertyValue("dt_TransferDate", ref _dtTransferDate, value); }
        }

        private string _sOfficialNo;
        public string s_OfficialNo
        {
            get { return _sOfficialNo; }
            set { SetPropertyValue("s_OfficialNo", ref _sOfficialNo, value); }
        }

        private string _sFileCode;
        public string s_FileCode
        {
            get { return _sFileCode; }
            set { SetPropertyValue("s_FileCode", ref _sFileCode, value); }
        }

        private string _sFileName;
        public string s_FileName
        {
            get { return _sFileName; }
            set { SetPropertyValue("s_FileName", ref _sFileName, value); }
        }

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }


        private SysUser handler;
        [Persistent("g_HandlerId")]
        public SysUser Handler
        {
            get { return handler; }
            set { SetPropertyValue("Handler", ref handler, value); }
        }

        private FileData _sInFileData;
        [DevExpress.Xpo.Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData InFileData
        {
            get { return _sInFileData; }
            set { SetPropertyValue("InFileData", ref _sInFileData, value); }
        }

        private FileData _sOutFileData;
        [DevExpress.Xpo.Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData OutFileData
        {
            get { return _sOutFileData; }
            set { SetPropertyValue("OutFileData", ref _sOutFileData, value); }
        }
    }
}