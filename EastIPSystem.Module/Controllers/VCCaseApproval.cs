﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.StateMachine;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using EastIPSystem.Module.BusinessObjects;

namespace EastIPSystem.Module.Controllers
{
    public partial class VCCaseApproval : ViewController
    {
        public VCCaseApproval()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            if (View is ListView)
            {
                View.SelectionChanged += View_SelectionChanged;
            }
            else if (View is DetailView)
            {
                SetApprovalState(View);
            }
            Frame.GetController<StateMachineController>().TransitionExecuted += VCCaseApproval_TransitionExecuted;
        }

        private void VCCaseApproval_TransitionExecuted(object sender, ExecuteTransitionEventArgs e)
        {
            var caseEnxtension = e.TargetObject as CaseExtension;
            if (caseEnxtension == null) return;
            if ((EnumsAll.CaseExtensionState)e.Transition.TargetState.Marker != EnumsAll.CaseExtensionState.确认延期) return;
            CommonFunction.UpdateCaseExtensionInPatentCase(caseEnxtension.s_OurNo, caseEnxtension.n_ExtendItem, caseEnxtension.dt_ExtendDate);
            if (caseEnxtension.n_ExtendItem2.HasValue)
                CommonFunction.UpdateCaseExtensionInPatentCase(caseEnxtension.s_OurNo, caseEnxtension.n_ExtendItem2.Value, caseEnxtension.dt_ExtendDate2);
        }

        private void View_SelectionChanged(object sender, EventArgs e)
        {
            SetApprovalState();
        }

        private void SetApprovalState(View view = null)
        {
            if (View.CurrentObject == null) return;
            var sysUser = (SysUser)SecuritySystem.CurrentUser;
            var changeStateAction = Frame.GetController<StateMachineController>().ChangeStateAction;
            var state = ((CaseExtension)View.CurrentObject).n_State;
            if (state == EnumsAll.CaseExtensionState.未提交 || state == EnumsAll.CaseExtensionState.部门审核未通过 ||
                state == EnumsAll.CaseExtensionState.修改延期未通过)
            {
                changeStateAction.Active["A"] = sysUser.IsUserInRole("管理部-OA组") || sysUser.IsUserInRole("管理部-国外组") ||
                                                sysUser.IsUserInRole("管理部-立案组") || sysUser.IsUserInRole("管理部-新申请组") ||
                                                sysUser.IsUserInRole("管理部-质检组");
            }
            else if (state == EnumsAll.CaseExtensionState.部门审核)
            {
                changeStateAction.Active["A"] = sysUser.IsUserInRole("管理部-经理");
            }
            else if (state == EnumsAll.CaseExtensionState.修改延期 || state == EnumsAll.CaseExtensionState.确认延期)
            {
                changeStateAction.Active["A"] = sysUser.IsUserInRole("管理部-质检组") || sysUser.IsUserInRole("管理部-经理");
            }
            if (view != null)
                view.AllowEdit["A"] = changeStateAction.Active["A"];
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
