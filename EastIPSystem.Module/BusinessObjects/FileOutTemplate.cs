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
    public class FileOutTemplate : BaseObject
    {
        public FileOutTemplate(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _sFileCode;
        public string s_FileCode
        {
            get { return _sFileCode; }
            set { SetPropertyValue("s_FileCode", ref _sFileCode, value); }
        }

        private string _sName;
        public string s_Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }

        private string _sClientNo;
        public string s_ClientNo
        {
            get { return _sClientNo; }
            set { SetPropertyValue("s_ClientNo", ref _sClientNo, value); }
        }

        private string _sApplicantNo;
        public string s_ApplicantNo
        {
            get { return _sApplicantNo; }
            set { SetPropertyValue("s_ApplicantNo", ref _sApplicantNo, value); }
        }

        private string _sFileName;
        public string s_FileName
        {
            get { return _sFileName; }
            set { SetPropertyValue("s_FileName", ref _sFileName, value); }
        }

        private EnumsAll.Language _nLanguage;
        public EnumsAll.Language n_Language
        {
            get { return _nLanguage; }
            set { SetPropertyValue("n_Language", ref _nLanguage, value); }
        }

        private FileData _sTemplateData;
        [DevExpress.Xpo.Aggregated]
        [ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData TemplateData
        {
            get { return _sTemplateData; }
            set { SetPropertyValue("TemplateData", ref _sTemplateData, value); }
        }
    }
}