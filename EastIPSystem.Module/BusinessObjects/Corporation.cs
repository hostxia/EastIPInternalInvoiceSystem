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
            set { SetPropertyValue("s_Code", ref _sCode, value); }
        }

        public string Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }

        [Browsable(false)]
        [Association("Applicants-Cases")]
        public XPCollection<CaseBase> Cases
        {
            get { return GetCollection<CaseBase>("Cases"); }
        }
    }
}