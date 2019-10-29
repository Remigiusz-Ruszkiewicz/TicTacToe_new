using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Data;
using TicTacToe.Repositories;
using TicTacToe.Resoursies;

namespace TicTacToe
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<Context>(
                o => o.UseSqlServer(
                    Configuration.GetConnectionString("SQL")));

            services.AddTransient<Repo, SqlRepo>();
            //services.AddScoped<Repo, JsonRepo>();
            //services.AddSingleton<Repo, JsonRepo>();

            services.AddMvc()
               .AddViewLocalization(
                   LanguageViewLocationExpanderFormat.Suffix,
                   opts => { opts.ResourcesPath = "Resources"; })
               .AddDataAnnotationsLocalization(options => options
                   .DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource)))
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("pl-PL")
                };

                options.DefaultRequestCulture = new RequestCulture("pl-PL", "pl-PL");
                options.SupportedCultures = supportCultures;
                options.SupportedUICultures = supportCultures;
            });
        }
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                app.UseRequestLocalization();
                app.UseStaticFiles();
                app.UseCookiePolicy();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }
    } 
