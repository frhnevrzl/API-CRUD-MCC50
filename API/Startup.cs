using API.Context;
using API.Repository.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
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
            //services.AddControllers();
            // Untuk Lazy Loading
            //Install newtonsoft json 3.1.12
            services.AddControllers()
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Agar bisa dijalankan startup harus ditambah/register addscope tiap repository
            services.AddScoped<PersonRepository>();
            services.AddScoped<AccountRepository>();
            services.AddScoped<EducationRepository>();
            services.AddScoped<UniversityRepository>();
            services.AddScoped<ProfilingRepository>();
            //harus install nuget package console
            //Install-Package Microsoft.EntityFrameworkCore.SqlServer
            //Install-Package Microsoft.EntityFrameworkCore.Design
            //Install - Package Microsoft.EntityFrameworkCore.Tools
            //services.AddDbContext<MyContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApiContext")));
            //Tiap ada Perubahan harus melakukan
            //Command di Nuget:
            //Enable-Migrations
            //Add-Migrations  ->commit name
            //update-database

            //LazyLoading
            services.AddDbContext<MyContext>(options => options.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("ApiContext")));
        }

        private void options(DbContextOptionsBuilder obj)
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
