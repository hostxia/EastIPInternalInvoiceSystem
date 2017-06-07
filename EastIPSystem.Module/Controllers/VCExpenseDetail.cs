using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    public partial class VCExpenseDetail : ViewController
    {
        public VCExpenseDetail()
        {
            InitializeComponent();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            saExpenseClone.Active.SetItemValue("Security", View.AllowEdit && View.AllowNew);
            Frame.GetController<NewObjectViewController>().ObjectCreated += VCExpenseDetail_ObjectCreated;
        }

        private void VCExpenseDetail_ObjectCreated(object sender, ObjectCreatedEventArgs e)
        {
            if ((sender as NewObjectViewController)?.Tag == null ||
                ((NewObjectViewController)sender).Tag.ToString() != "Clone") return;
            var expense = View.CurrentObject as Expense;
            if (expense == null) return;
            if (!(e.CreatedObject is Expense)) return;
            ((Expense)e.CreatedObject).s_OurNo = expense.s_OurNo;
            ((Expense)e.CreatedObject).dt_ExpenseDate = expense.dt_ExpenseDate;
        }

        private void saExpenseClone_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Frame.GetController<NewObjectViewController>().Tag = "Clone";
            Frame.GetController<ModificationsController>()
                .SaveAndNewAction.DoExecute(Frame.GetController<NewObjectViewController>().NewObjectAction.SelectedItem);
        }
    }
}