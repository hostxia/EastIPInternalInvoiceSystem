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
    [DefaultProperty("性别")]
    public class 人员信息 : BaseObject
    {
        public 人员信息(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string fs_人员编号;
        public string 人员编号
        {
            get { return fs_人员编号; }
            set { SetPropertyValue("人员编号", ref fs_人员编号, value); }
        }

        private string fs_人员姓名;
        public string 人员姓名
        {
            get { return fs_人员姓名; }
            set { SetPropertyValue("人员姓名", ref fs_人员姓名, value); }
        }

        private bool fs_性别;
        [CaptionsForBoolValues("男", "女")]
        public bool 性别
        {
            get { return fs_性别; }
            set { SetPropertyValue("性别", ref fs_性别, value); }
        }
    }
}