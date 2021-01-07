using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WMSAMG.Models.PRACTICEDB;

namespace WMSAMG
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCaching();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContextPool<Models.CSISControlModels.CSISControlContext>(c => c.UseSqlServer(_configuration.GetConnectionString("AuthContextConnection")));
            services.AddDbContextPool<Models.CSIS2017Models.CSIS2017Context>(c => c.UseSqlServer(_configuration.GetConnectionString("DataContextConnection")));
            //services.AddDbContext<Models.CSISControlModels.CSISControlContext>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("AuthContextConnection")));
            //services.AddDbContext<Models.CSIS2017Models.CSIS2017Context>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("DataContextConnection")));

            //remove default json selialize
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });
            // add cors package

            //services.AddCors();

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddDistributedMemoryCache();
            services.AddSession();
            //services.AddSession(options =>
            //{
            //    // Set a short timeout for easy testing.
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //});

            // Add detection services container and device resolver service.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
             Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzYwMzg2QDMxMzgyZTMzMmUzMEVNWHRoWHYwWngxaTVQa1NaQWZzTGo2NUJ1WGZxaEptQmJYaUpHZHpVbjQ9;MzYwMzg3QDMxMzgyZTMzMmUzMEM5SmREbHJ3RXdmYU4xbndlMkp4Y0VvMFp6VlBrZVYyb20wcU0wOEcrT2M9;MzYwMzg4QDMxMzgyZTMzMmUzMEFBdVJ1QzdTZmViYjRIWDdVTHBwK2MxSTV6TVhZQ0M0UXBobTNlY2tZTkU9;MzYwMzg5QDMxMzgyZTMzMmUzMFNRUzUzdTRuZ0trZit6MUErdjlnQmV1ZU14eUo0TmhKQlRuK09nbHNlOEE9;MzYwMzkwQDMxMzgyZTMzMmUzMGNEWlVCT1FOSEt4d1VZczAzSmM4WUVEMnRYYktsNkl3TTRwWnRWZTlJNFU9;MzYwMzkxQDMxMzgyZTMzMmUzMHBEWElOTlM3VzF6Y0k4bTF1YnVydjdrckQva3JFaDB2NFVWSEI1UFBHWlE9;MzYwMzkyQDMxMzgyZTMzMmUzMEwwYjA5TGFiL0dUdTJWRklaWk5XamN6RHRLZ1prbGpEb25RQ2dnZWVvVEU9;MzYwMzkzQDMxMzgyZTMzMmUzMFRBUVdNQVU0dVppQVBSRitsSzVUTTVmekVCdXhuQ1hBdjZRVWc0YlNRckk9;MzYwMzk0QDMxMzgyZTMzMmUzMEtBanZ1S1lndzBkVzVWRGVaUzBVcTlMTEVXZ0lUT1UxbFBJWDdBeTdmeWM9;MzYwMzk1QDMxMzgyZTMzMmUzMEpNaFFYS2JqdCtrNVFtVFI0K3V4dmhQajVTOUhrVXRtSDBKbmdwb3ZYc3c9");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            //app.UseCors(options =>
            //    options.WithOrigins("http://localhost")
            //    //options.WithOrigins("http://localhost:44336")
            //    .AllowAnyOrigin()
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    );

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
