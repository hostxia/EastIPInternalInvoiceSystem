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
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using EastIPInternalInvoiceSystem.Module.BusinessObjects;

namespace EastIPInternalInvoiceSystem.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VCDetailForeignInvoice : ViewController
    {
        public VCDetailForeignInvoice()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            Frame.GetController<NewObjectViewController>().NewObjectAction.Items[0].Caption = View.Caption;
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.

            ((PropertyEditor)((CompositeView)View).FindItem("dt_DateForeignInvoice")).ControlValueChanged += VCDetailForeignInvoice_ControlValueChanged;
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeOfficial")).ControlValueChanged += VCDetailForeignInvoice_ControlValueChanged1;
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeAgent")).ControlValueChanged += VCDetailForeignInvoice_ControlValueChanged1;
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeService")).ControlValueChanged += VCDetailForeignInvoice_ControlValueChanged1;
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeDistribution")).ControlValueChanged += VCDetailForeignInvoice_ControlValueChanged1;
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeTranslation")).ControlValueChanged += VCDetailForeignInvoice_ControlValueChanged1;
        }

        private void VCDetailForeignInvoice_ControlValueChanged1(object sender, EventArgs e)
        {
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeOfficial")).WriteValue();
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeAgent")).WriteValue();
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeService")).WriteValue();
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeDistribution")).WriteValue();
            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeTranslation")).WriteValue();

            decimal nAmount = 0m;
            nAmount += (decimal)((PropertyEditor)((CompositeView)View).FindItem("n_FeeOfficial")).ControlValue;
            nAmount += (decimal)((PropertyEditor)((CompositeView)View).FindItem("n_FeeAgent")).ControlValue;
            nAmount += (decimal)((PropertyEditor)((CompositeView)View).FindItem("n_FeeService")).ControlValue;
            nAmount += (decimal)((PropertyEditor)((CompositeView)View).FindItem("n_FeeDistribution")).ControlValue;
            nAmount += (decimal)((PropertyEditor)((CompositeView)View).FindItem("n_FeeTranslation")).ControlValue;

            ((PropertyEditor)((CompositeView)View).FindItem("n_FeeTotal")).PropertyValue = nAmount;
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void VCDetailForeignInvoice_ControlValueChanged(object sender, EventArgs e)
        {
            ((PropertyEditor)((CompositeView)View).FindItem("dt_DateForeignInvoice")).WriteValue();
            if (Convert.ToDateTime(((PropertyEditor)((CompositeView)View).FindItem("dt_DateForeignInvoice")).ControlValue) != DateTime.MinValue)
                ((PropertyEditor)((CompositeView)View).FindItem("dt_DateApplication")).PropertyValue = Convert.ToDateTime(((PropertyEditor)((CompositeView)View).FindItem("dt_DateForeignInvoice")).ControlValue).AddDays(60);
        }
    }
}
