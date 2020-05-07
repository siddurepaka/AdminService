using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminClientServices.Entities;
using AdminClientServices.Repositories;
using AdminClientServices.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AdminClientServices.Manager;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdminClientServices", Version = "v1", Description = "Team 4AC" });
            });
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options =>
                 options.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()


               );
            });
            services.AddDbContext<EmartDBContext>();
            services.AddTransient<IAdminClientRepository, AdminClientRepositorycs>();
            services.AddTransient<IAdminClientManager, AdminClientMagerRepository>();
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
             app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdminClientServices");
            });

            app.UseAuthorization();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
