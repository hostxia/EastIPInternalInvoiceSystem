using System;
using System.Web;

namespace EastIPInternalInvoiceSystem.Mobile
{
    public class Global : HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CorsSupport.HandlePreflightRequest(HttpContext.Current);
        }
    }
}