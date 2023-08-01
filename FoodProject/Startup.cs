using FoodProject.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Threading.Tasks;

namespace FoodProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireUppercase = false;   // b�y�k harf mecburiyeti ortadan kalks�n
                x.Password.RequireNonAlphanumeric = false; // alfa n�merik karakter zorunlulu�u ortadan kalks�n
                x.Password.RequiredLength = 3; // parola uzunlu�u en az 3 karakter olmal�
                x.Password.RequireLowercase = false; // k���k harf zorunlulu�u ortadan kalks�n
            }).AddEntityFrameworkStores<Context>();

            services.AddDbContext<Context>();

            services.AddRazorPages();

            services.AddMvc();

            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index/"; // e�er kullan�c� giri� yapmad�ysa y�nlendirece�i sayfa burada belirtilmi�tir
				});

            services.ConfigureApplicationCookie(opts =>
            {
                //Cookie settings
                opts.Cookie.HttpOnly = true;
                opts.ExpireTimeSpan = TimeSpan.FromMinutes(180); // belirtilen s�re kadar sistemde kalacak
              //  opts.AccessDeniedPath = new PathString("/Login/AccessDenied/");
                opts.LoginPath = "/Login/Index/";
                opts.SlidingExpiration = true;
            });

            // Authorize i�lemini controller seviyesine ��karma
            services.AddMvc(config=>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
            });
        }
    }
}
