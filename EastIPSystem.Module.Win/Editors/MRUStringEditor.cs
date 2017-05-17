using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Win.Editors
{
    [PropertyEditor(typeof(string), false)]
    public class MRUStringEditor : StringPropertyEditor
    {
        private IModelMemberViewItem _model;
        private MyMRUEdit _mruEdit;
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
            _mruEdit = new MyMRUEdit();
            _mruEdit.Properties.AllowRemoveMRUItems = false;
            return _mruEdit;
        }
    }

    public class MyMRUEdit : MRUEdit
    {
        protected override PopupBaseForm CreatePopupForm()
        {
            return new MyPopupMRUForm(this);
        }

        protected override int FindItem(string text, int startIndex)
        {
            if (text != null)
            {
                startIndex = Math.Max(startIndex, 0);
                if (text.Length == 0)
                {
                    for (int i = startIndex; i < this.Properties.Items.Count; i++)
                    {
                        if (string.Empty == this.GetItemDescription(this.Properties.Items[i]))
                        {
                            return i;
                        }
                    }
                }
                else
                {
                    if (!this.Properties.CaseSensitiveSearch)
                    {
                        text = text.ToLower();
                    }
                    for (int j = startIndex; j < this.Properties.Items.Count; j++)
                    {
                        string itemDescription = this.GetItemDescription(this.Properties.Items[j]);
                        if (!this.Properties.CaseSensitiveSearch)
                        {
                            itemDescription = itemDescription.ToLower();
                        }
                        if (itemDescription.Contains(text))
                        {
                            return j;
                        }
                    }
                }
            }
            return -1;
        }
    }
    public class MyPopupMRUForm : PopupMRUForm
    {
        public MyPopupMRUForm(ComboBoxEdit ownerEdit) : base(ownerEdit) { }
        public override void SetMruFilter(string text)
        {
            base.SetMruFilter(text);
            if (OwnerEdit == null || Properties.TextEditStyle != TextEditStyles.Standard) return;
            SelectedItemIndex = -1;
            ((MyPopupListBox)ListBox).MySetFilter(OwnerEdit.AutoSearchText);
        }
        protected override PopupListBox CreateListBox()
        {
            return new MyPopupListBox(this);
        }
    }
    class MyPopupListBox : PopupListBox
    {
        public MyPopupListBox(PopupListBoxForm ownerForm) : base(ownerForm) { }
        public void MySetFilter(string text)
        {
            try
            {
                string filter = string.Empty;
                if (!string.IsNullOrEmpty(text))
                {
                    //string likeClause = DevExpress.Data.Filtering.Helpers.LikeData.CreateStartsWithPattern(text);
                    string likeClause = "%" + text + "%";
                    filter = new BinaryOperator("Column", likeClause, BinaryOperatorType.Like).ToString();
                }
                DataAdapter.FilterExpression = filter;
            }
            catch
            {
                DataAdapter.FilterExpression = string.Empty;
            }
        }
    }
}
