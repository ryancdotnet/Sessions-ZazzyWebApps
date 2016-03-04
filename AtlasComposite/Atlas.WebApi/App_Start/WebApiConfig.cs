using System.Web.Http;
using System.Web.Http.Cors;

namespace Atlas.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            //config.Routes.MapHttpRoute(
            //    name: "AtlasApi",
            //    routeTemplate: "/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
