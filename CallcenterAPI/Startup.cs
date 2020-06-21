using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallcenterAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CallcenterAPI.Model;
using Microsoft.AspNetCore.Identity;

namespace CallcenterAPI
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
            services.AddDbContext<callcenterEntities>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("connCallcenter")));
            services.AddTransient< IColas, ColaService>();
            services.AddTransient< IOperaciones, OperacionesService>();
            services.AddTransient<IPersona,PersonasService>();
            services.AddTransient< ISeguimiento, SeguimientosService>();
            services.AddTransient<IUsuario, UsuarioService>();
            services.AddTransient<IAgenda, AgendaService>();
            services.AddTransient<IHome, HomeService>();


            services.AddCors(opciones => 
            {
                opciones.AddPolicy("PermitirTodo", accesso => accesso.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
            
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("PermitirTodo");

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
