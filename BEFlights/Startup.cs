using BEFlights.Domain.IRepositories;
using BEFlights.Domain.IServices;
using BEFlights.Persistence.Context;
using BEFlights.Persistence.Repositories;
using BEFlights.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace BEFlights
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Repository
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            // Service
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();

            // Cors
            services.AddCors(options => options.AddPolicy("AllowWebapp",
                                                builder => builder.AllowAnyOrigin()
                                                                .AllowAnyHeader()
                                                                .AllowAnyMethod()));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BEFlights", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BEFlights v1"));
            }         

            app.UseHttpsRedirection();

            app.UseCors("AllowWebapp");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
