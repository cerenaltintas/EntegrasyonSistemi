using AutoMapper;
using EntegrasyonSistemi.Interfaces;
using EntegrasyonSistemi.Models;
using EntegrasyonSistemi.Repository;
using EntegrasyonSistemi.Services.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace EntegrasyonSistemi
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
            var connectionstring = "server=127.0.0.1;port=5432;Database=Integration;user ID=postgres;password=1;CommandTimeout=300";
            services.AddControllers();        
            services.AddDbContext<IntegrationDatabaseContext>(db => db.UseNpgsql(connectionstring));
            services.AddAutoMapper();
            services.AddTransient(typeof(IUserManager), typeof(UserManager));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EntegrasyonSistemi", Version = "v1" });
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","EntegrasyonSistemi v1"));

            app.UseCors(x => x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
