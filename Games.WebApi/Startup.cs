using AutoMapper;
using BusinessLayer.Abstractions;
using BusinessLayer.Services;
using BusinessLayer.Services.Mapping;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Games.WebApi.Mapping;
using System.Reflection;
using System;
using System.IO;
using BusinessLayer.Services.Validators;

namespace Games.WebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Web API",
                    Version = "v1"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            DbContextInstaller.ConfigureDbContext(services);
            RepositoriesInstaller.Install(services);
            ValidatorsInstaller.Install(services);

            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()))
                .AddTransient<IGameService, GameService>()
                .AddTransient<IDeveloperStudioService, DeveloperStudioService>()
                .AddTransient<IGenreService, GenreService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseCors(builder => builder
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GameApiMappingProfile>();
                cfg.AddProfile<DeveloperStudioApiMappingProfile>();
                cfg.AddProfile<GenreApiMappingProfile>();
                cfg.AddProfile<ServiceMappingsProfile>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}