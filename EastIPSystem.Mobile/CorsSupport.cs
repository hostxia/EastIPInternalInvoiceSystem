using System.Web;

namespace EastIPSystem.Mobile
{
    // NOTE
    // The following change to web.config is required
    // <system.serviceModel>
    //    <serviceHostingEnvironment aspNetCompatibilityEnabled="true" /> 

    internal static class CorsSupport
    {
        public static void HandlePreflightRequest(HttpContext context)
        {
            var req = context.Request;
            var res = context.Response;
            var origin = req.Headers["Origin"];

            if (!string.IsNullOrEmpty(origin))
            {
                res.AddHeader("Access-Control-Allow-Origin", origin);
                res.AddHeader("Access-Control-Allow-Credentials", "true");
                res.AddHeader("Vary", "Origin");

                var methods = req.Headers["Access-Control-Request-Method"];
                var headers = req.Headers["Access-Control-Request-Headers"];

                if (!string.IsNullOrEmpty(methods))
                    res.AddHeader("Access-Control-Allow-Methods", methods);

                if (!string.IsNullOrEmpty(headers))
                    res.AddHeader("Access-Control-Allow-Headers", headers);

                if (req.HttpMethod == "OPTIONS")
                {
                    res.StatusCode = 204;
                    res.End();
                }
            }
        }
    }
}