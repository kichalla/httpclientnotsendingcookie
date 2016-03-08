using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Map("/getdata", appBuilder =>
            {
                appBuilder.Run(httpContext =>
                {
                    httpContext.Response.Cookies.Append(
                        ".AspNetCore.Session",
                    "RAExEmXpoCbueP_QYM",
                    new CookieOptions() { HttpOnly = true, Path = "/" });

                    httpContext.Response.Cookies.Append(
                        ".AspNetCore.Antiforgery.Xam7_OeLcN4",
                    "CfDJ8NGNxAt7CbdClq3UJ8_6w_4661wRQZT1aDtUOIUKshbcV4P0NdS8klCL5qGSN-PNBBV7w23G6MYpQ81t0PMmzIN4O04fqhZ0u1YPv66mixtkX3iTi291DgwT3o5kozfQhe08-RAExEmXpoCbueP_QYM",
                    new CookieOptions { HttpOnly = true, Path = "/" });

                    return httpContext.Response.WriteAsync("From getdata");
                });
            });

            app.Map("/postdata", appBuilder =>
            {
                appBuilder.Run(httpContext =>
                {
                    var cookies = string.Join(", ", httpContext.Request.Cookies.Select(kvp => $"{kvp.Key} : {kvp.Value}"));

                    return httpContext.Response.WriteAsync("Postdata action received the following cookies:" + cookies);
                });
            });
        }

        // Entry point for the application.
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseServer("Microsoft.AspNetCore.Server.Kestrel")
                .UseDefaultConfiguration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
