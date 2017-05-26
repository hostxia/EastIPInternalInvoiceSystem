using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace EastIPSystem.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class PatentProgress : BaseObject
    {
        public PatentProgress(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (patentBase != null)
                patentBase.LastPatentProgress =
                    patentBase.PatentProgresses.OrderByDescending(g => g.dt_ItemDate).FirstOrDefault();
        }


        private PatentBase deletepatent;
        protected override void OnDeleting()
        {
            base.OnDeleting();
            if (patentBase != null)
                deletepatent = patentBase;
        }

        protected override void OnDeleted()
        {
            base.OnDeleted();
            if (deletepatent != null)
                deletepatent.LastPatentProgress =
                    deletepatent.PatentProgresses.OrderByDescending(g => g.dt_ItemDate).FirstOrDefault();
        }

        private PatentBase patentBase;
        [Association("PatentBase-PatentProgresses")]
        public PatentBase PatentBase
        {
            get { return patentBase; }
            set { SetPropertyValue("PatentBase", ref patentBase, value); }
        }

        private EnumsAll.PatentProgressItem _nItem;
        public EnumsAll.PatentProgressItem n_Item
        {
            get { return _nItem; }
            set { SetPropertyValue("n_Item", ref _nItem, value); }
        }

        private DateTime _dtItemDate;
        public DateTime dt_ItemDate
        {
            get { return _dtItemDate; }
            set { SetPropertyValue("dt_ItemDate", ref _dtItemDate, value); }
        }

        private string _sNote;
        public string s_Note
        {
            get { return _sNote; }
            set { SetPropertyValue("s_Note", ref _sNote, value); }
        }
    }
}