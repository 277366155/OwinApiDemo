using Microsoft.Owin.Hosting;
using System;
using System.Configuration;
using System.Diagnostics;
using WebAPI;

namespace WebAPIHost
{
    class Program
    {
        public static string BaseUrl = ConfigurationManager.AppSettings["HostUrl"];
        static void Main(string[] args)
        {
            Console.ForegroundColor = (ConsoleColor)new Random().Next(0, 16);


            //WebApp.Start<T>() 方法会自动执行 T.Configuration() 方法
            //当要启用API路由时，需Startup类与API在同一个项目中
            using (WebApp.Start<Startup>(BaseUrl))
            {
                //HttpClient client = new HttpClient();
                Console.WriteLine("已启动...");
                Process.Start(BaseUrl + "/api/default/getData/1");
                var input = Console.ReadLine();
               
                    while (string.IsNullOrWhiteSpace(input)||input.ToLower() != "q")
                    {
                        Console.WriteLine($"请继续输入...");
                        Console.WriteLine($"退出请输入[q]\r\n");
                        input = Console.ReadLine();
                    }
            }
            //HostFactory.Run(a =>
            //{
            //    a.RunAsNetworkService();
            //    a.SetDescription("服务介绍。。");
            //    a.SetServiceName("WebApiHost");
            //});
        }
    }
}
