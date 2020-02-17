using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyJsonConfig
{
    public class Startup
    {
        public IConfiguration AppConfig { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(hostEnvironment.ContentRootPath);
            builder.AddJsonFile("JsonConfig.json");
            AppConfig = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            app.Run( async (context)=>
            { 
                    await context.Response.WriteAsync($"<p style='color:{AppConfig["Color"]};'>{AppConfig["Content"]}</p>");
                
            });
        }
    }
}
