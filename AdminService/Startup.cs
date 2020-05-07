using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AdminClientServices.Controllers;
using AdminClientServices.Repository;
using Microsoft.OpenApi.Models;
using AdminClientServices.Extensions;
using Microsoft.EntityFrameworkCore;
using AdminClientServices.Manager;
using AdminClientServices.Entities;

namespace AdminClientServices
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
            services.AddDbContext<EmartDBContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("connectionstring")));
            services.AddMvc(
              config =>
              {
                
                  config.Filters.Add(typeof(CustomExceptionFilter));
                 
              }
          );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminServices", Version = "v1", Description= "Team 4AC" });
            });
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options =>
                 options.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()


               );
            });



            services.AddDbContext<EmartDBContext>();
            services.AddTransient<IAdminRepository,AdminRepositoty>();
            services.AddTransient<IManager,ManagerRepository>();
        //    services.AddTransient<AdminRepositoty,ManagerRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           app.ConfigureExceptionHandler();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors("AllowOrigin");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Admin Services");
            });
        }

    
}
}
