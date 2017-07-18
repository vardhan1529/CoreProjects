using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace student
{
    using Microsoft.AspNetCore.Http;
    using student.Services;

    public class QueryCheck
    {
        private readonly RequestDelegate next;

        public QueryCheck(RequestDelegate d)
        {
            next = d;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html";
                if(context.Request.Query["t"] == "test")
                {
                    var s = "The querystring is " + context.Request.QueryString.ToString();
                    byte[] b = new byte[s.Length];
                    for(var x= 0; x < s.Length; x++ )
                    {
                        b[x] = (byte)s[x];
                    }
                    return context.Response.Body.WriteAsync(b, 0, b.Length - 1);
                }

                return next(context);
        }
    }

    public static class OExtension{
        public static IApplicationBuilder UseQueryCheck(this IApplicationBuilder app)
        {
            return app.UseMiddleware<QueryCheck>();
        }
    }
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddTransient<IStudentService, StudentService>();

            services.AddDbContext<StudentContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StudentConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            // app.Use((context, next) => {
            //     context.Response.ContentType = "text/html";
            //     if(context.Request.Query["t"] == "test")
            //     {
            //         var s = "The querystring is " + context.Request.QueryString.ToString();
            //         byte[] b = new byte[s.Length];
            //         for(var x= 0; x < s.Length; x++ )
            //         {
            //             b[x] = (byte)s[x];
            //         }
            //         return context.Response.Body.WriteAsync(b, 0, b.Length - 1);
            //     }
            //     return next();
            //     });

            // app.UseQueryCheck();
            // app.Run(async (context) => {                
            //     await context.Response.Body.WriteAsync(new byte[]{20,30, 45,63,48,95,14,45,12,12,12,65,65,65,65,65}, 0, 16);});

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
