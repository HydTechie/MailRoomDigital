using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MailRoom.Repository;
using MailRoom.Repository.Seeding;
using MailRoom.Repository.Helpers;
using MailRoom.Repository.Interfaces;
using MailRoom.Model;

namespace MailRoom
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
            // Add Entity Framework services to the services container
            services.AddDbContext<MailRoomContext>(options =>
                {
                    options.UseMySql(Configuration.GetConnectionString("MailRoom"));
                    //options.UseSqlServer(Configuration.GetConnectionString("MailRoom"));
                    //options.UseSqlite(Configuration.GetConnectionString("MailRoomSqlite"));
                });

            // Add MVC services to the services container.
            services.AddMvc();

            

            //Add data repository mappings
            services.AddTransient<IStagingClaimRepository, StagingClaimRepository>();
            //services.AddTransient<IMarketsAndNewsRepository, MarketsAndNewsRepository>();
            //services.AddTransient<ISecurityRepository, SecurityRepository>();
            services.AddTransient<IStagingEngine, StagingEngine>();
            services.AddTransient<DatabaseInitializer>();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            DatabaseInitializer dbInitializer)
        {
            // Configure the HTTP request pipeline.

            // Add the following to the request pipeline only in development environment.
            if (env.IsDevelopment())
            {
                  app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // sends the request to the following path or controller action.
                app.UseExceptionHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add MVC to the request pipeline.
            //app.UseMvcWithDefaultRoute();

          
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Seed the database here
            dbInitializer.SeedAsync().Wait();
        }
    }
}
