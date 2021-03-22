using IRAO.Domain.Entities;
using IRAO.Domain.Interfaces;
using IRAO.Domain.Interfaces.Core;
using IRAO.Repositories;
using IRAO.Repositories.Context;
using IRAO.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRAO.API
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

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IRAO.API", Version = "v1" });
            });
            services.AddDbContext<IraoDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            
            services.AddScoped<IUnitOfWork, IraoDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();

            //Get Interface types from Domain Library
            var interfaces = typeof(Company).Assembly.GetTypes().Where(t => t.IsInterface && t != typeof(IUnitOfWork));
            //Add Repository Dependencies
            foreach (var t in typeof(CompanyRepository).Assembly.GetTypes())
            {
                foreach (var i in interfaces.Where(x => x.IsAssignableFrom(t)))
                {
                    services.AddScoped(i, t);
                }
            }
            //Add Service Dependencies
            foreach (var s in typeof(CompanyService).Assembly.GetTypes())
            {
                foreach (var i in interfaces.Where(x => x.IsAssignableFrom(s)))
                {
                    services.AddScoped(i, s);
                }
            }

            // In production, the Angular files will be served from this directory
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IRAO.API v1"));
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
