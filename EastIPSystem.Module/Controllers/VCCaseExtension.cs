using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.StateMachine;
using DevExpress.ExpressApp.SystemModule;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VCCaseExtension : ViewController
    {
        public VCCaseExtension()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            saGetExtensionCaseInfo.Active.SetItemValue("Security", SecuritySystem.IsGranted(ObjectSpace, typeof(CaseExtension), SecurityOperations.Write, View.CurrentObject, "s_OurNo"));
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void saGetExtensionCaseInfo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View is DetailView)
            {
                var objOurNo = ((PropertyEditor)((CompositeView)View).FindItem("s_OurNo")).PropertyValue;
                if (string.IsNullOrWhiteSpace(objOurNo?.ToString())) return;
                ((CaseExtension)e.CurrentObject).SetCaseInfo(objOurNo.ToString());
                ((PropertyEditor)((CompositeView)View).FindItem("s_ClientNo")).ReadValue();
                ((PropertyEditor)((CompositeView)View).FindItem("s_Client")).ReadValue();
                ((PropertyEditor)((CompositeView)View).FindItem("s_Applicant")).ReadValue();
                ((PropertyEditor)((CompositeView)View).FindItem("s_ApplicantNo")).ReadValue();
            }
            if (View is ListView)
            {
                foreach (CaseExtension caseExtension in e.SelectedObjects)
                {
                    if (string.IsNullOrWhiteSpace(caseExtension.s_OurNo)) continue;
                    caseExtension.SetCaseInfo(caseExtension.s_OurNo);
                    View.ObjectSpace.CommitChanges();
                }
            }
        }
    }
}
