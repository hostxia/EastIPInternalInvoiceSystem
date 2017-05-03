using System;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;

namespace EastIPSystem.Module.Win.Editors
{
    [PropertyEditor(typeof(string), false)]
    public class MRUStringEditor : StringPropertyEditor
    {
        private IModelMemberViewItem _model;
        public MRUStringEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {
            _model = model;
        }

        protected override object CreateControlCore()
        {
            return new MRUEdit();
        }
    }
}
