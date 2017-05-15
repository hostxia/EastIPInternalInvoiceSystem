using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace EastIPSystem.Module.Win.Controllers
{
    public partial class VCWinList : ViewController
    {
        public VCWinList()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var control = View.Control as GridControl;
            var gridView = control?.MainView as GridView;
            if (gridView != null)
            {
                gridView.OptionsView.ColumnAutoWidth = false;
                gridView.Columns.ToList().ForEach(c => c.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains);
            }
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
