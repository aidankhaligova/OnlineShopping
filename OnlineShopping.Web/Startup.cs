using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Core.Enums;
using OnlineShopping.Core.Factories;
using OnlineShopping.Web.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineShopping.Web
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher<User>, CustomPasswordHasher>();
            services.AddSingleton(serviceProvider =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                return DBFactory.Create(ServerType.SqlServer, connectionString);
            });

            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IRoleStore<Role>, RoleStore>();

            services.AddIdentity<User, Role>();

            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Account/Index";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler("/Error/InternalError");
                // app.UseStatusCodePagesWithRedirects("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Index}/{id?}");

                //endpoints.MapAreaControllerRoute(
                //    name: "areas",
                //    areaName: "areas",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
