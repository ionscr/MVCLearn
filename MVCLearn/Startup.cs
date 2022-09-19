 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCLearn.Filters;
using MVCLearn.Middlewares;
using MVCLearn.Models;
using MVCLearn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCLearn
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => 
            {
                options.Filters.Add(typeof(ModelValidationFilter));
                options.Filters.Add(typeof(ExceptionFilter));
            });
            services.AddHttpClient("ApiClient");
            //services.AddScoped<IWebApiService, WebApiService>(s => 
            //    new WebApiService(Configuration.GetConnectionString("WebAPI"), IHttpClientFactory)
            //);
            services.AddScoped<IWebApiService, WebApiService>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<MaintenanceMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
