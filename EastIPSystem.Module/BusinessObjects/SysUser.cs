using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("Name")]
    public class SysUser : PermissionPolicyUser
    {
        private string _sCode;

        private string _sName;

        private string _sEName;

        public SysUser(Session session)
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

        public string EName
        {
            get { return _sEName; }
            set { SetPropertyValue("EName", ref _sEName, value); }
        }

        private string _sDepartment;

        public string Department
        {
            get { return _sDepartment; }
            set { SetPropertyValue("s_Department", ref _sDepartment, value); }
        }

    }
}