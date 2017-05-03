using System.Web.UI;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web.Templates;

namespace EastIPSystem.Web
{
    public partial class Default : BaseXafPage
    {
        public override Control InnerContentPlaceHolder
        {
            get { return Content; }
        }

        protected override ContextActionsMenu CreateContextActionsMenu()
        {
            return new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
        }
    }
}