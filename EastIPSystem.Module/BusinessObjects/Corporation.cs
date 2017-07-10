using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Corporation : BaseObject
    {
        private string _sCode;

        private string _sName;

        private Country country;

        public Corporation(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        public string Code
        {
            get { return _sCode; }
            set { SetPropertyValue("Code", ref _sCode, value); }
        }

        public string Name
        {
            get { return _sName; }
            set { SetPropertyValue("Name", ref _sName, value); }
        }

        public Country Country
        {
            get { return country; }
            set { SetPropertyValue("Country", ref country, value); }
        }

        [Browsable(false)]
        [Association("Applicants-Cases")]
        public XPCollection<CaseBase> Cases
        {
            get { return GetCollection<CaseBase>("Cases"); }
        }

        [Browsable(false)]
        [Association("Applicants-FilePatents")]
        public XPCollection<FilePatent> FilePatents
        {
            get { return GetCollection<FilePatent>("FilePatents"); }
        }

        [Browsable(false)]
        [Association("PatentBases-Applicants")]
        public XPCollection<PatentBase> PatentBases
        {
            get { return GetCollection<PatentBase>("PatentBases"); }
        }


    }
}