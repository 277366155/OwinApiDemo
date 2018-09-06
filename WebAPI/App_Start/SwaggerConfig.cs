using System.Web.Http;
using WebActivatorEx;
using WebAPI;
using Swashbuckle.Application;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebAPI
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebAPI");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    })
                .EnableSwaggerUi("swagger/{*assetPath}",
                                c => { c.DisableValidator(); });
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\WebAPI.xml", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
