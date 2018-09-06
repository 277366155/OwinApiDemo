using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;

namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            //设置允许跨域
            app.UseCors(CorsOptions.AllowAll);
            HttpConfiguration config = new HttpConfiguration();
            //启用标记路由
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "defaultApi",
                routeTemplate: "api/{Controller}/{Action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            SwaggerConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}