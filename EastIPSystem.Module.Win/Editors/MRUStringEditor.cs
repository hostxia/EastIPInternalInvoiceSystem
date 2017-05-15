using System;
using System.Linq;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Win.Editors
{
    [PropertyEditor(typeof(string), false)]
    public class MRUStringEditor : StringPropertyEditor
    {
        private IModelMemberViewItem _model;
        private MRUEdit _mruEdit;
        public MRUStringEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
            _model = model;
        }

        protected override void SaveModelCore()
        {
            base.SaveModelCore();
            if (string.IsNullOrWhiteSpace(_model.PredefinedValues)) return;
            _mruEdit.Properties.Items.Clear();
            _mruEdit.Properties.Items.AddRange(_model.PredefinedValues.Split(';').ToList());
        }

        protected override object CreateControlCore()
        {
            _mruEdit = new MRUEdit();
            return _mruEdit;
        }
    }
}
