using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Web_Basico.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API_Web_Basico
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //creamos la funcion
            services.AddDbContext<PersonasDBContext>
            (options => options.UseSqlServer(
                //DevConnection viene del appsettings.json
                Configuration.GetConnectionString("DevConnection")
                )
            );
            //Iniciamos el cors
            services.AddCors();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Iniciamos e instanciamos el cors
            app.UseCors(options =>
            options.WithOrigins("http://localhost:5500")
            .AllowAnyHeader()
            .AllowAnyMethod()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
