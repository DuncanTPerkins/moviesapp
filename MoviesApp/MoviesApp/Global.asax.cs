using System.Net;
using System.Web.Http;

namespace MoviesApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            if (Request.HttpMethod == "OPTIONS")
            {
                Response.StatusCode = (int)HttpStatusCode.OK;
                Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                Response.AppendHeader("Access-Control-Allow-Credentials", "true");
                Response.End();
            }
        }
    }
}
