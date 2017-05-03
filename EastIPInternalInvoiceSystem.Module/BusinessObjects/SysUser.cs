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
    [DefaultProperty("Name")]
    public class SysUser : PermissionPolicyUser
    {
        private string _sCode;

        private string _sName;

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
            set { SetPropertyValue("s_Code", ref _sCode, value); }
        }

        public string Name
        {
            get { return _sName; }
            set { SetPropertyValue("s_Name", ref _sName, value); }
        }


        private string _sDepartment;

        public string Department
        {
            get { return _sDepartment; }
            set { SetPropertyValue("s_Department", ref _sDepartment, value); }
        }

    }
}