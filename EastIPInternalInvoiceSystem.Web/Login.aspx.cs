﻿using System.Web.UI;
using DevExpress.ExpressApp.Web.Templates;

namespace EastIPInternalInvoiceSystem.Web
{
    public partial class LoginPage : BaseXafPage
    {
        public override Control InnerContentPlaceHolder
        {
            get { return Content; }
        }
    }
}