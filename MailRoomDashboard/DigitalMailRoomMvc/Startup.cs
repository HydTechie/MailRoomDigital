using MailRoom.Repository;
using MailRoom.Repository.Interfaces;
using MailRoom.Repository.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalMailRoomMvc
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

            // Add Entity Framework services to the services container
            services.AddDbContext<MailRoomContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MailRoom"));
                //options.UseSqlServer(Configuration.GetConnectionString("MailRoom"));
                //options.UseSqlite(Configuration.GetConnectionString("MailRoomSqlite"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Add data repository mappings
            services.AddTransient<IStagingClaimRepository, StagingClaimRepository>();
            
            //services.AddTransient<IStagingEngine, StagingEngine>();
            services.AddTransient<DatabaseInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DatabaseInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                // Seed the database here
                dbInitializer.SeedAsync().Wait();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Dashboard}/{id?}");
            });
        }
    }
}
