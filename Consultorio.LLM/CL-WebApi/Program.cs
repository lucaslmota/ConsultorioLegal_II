
using Cl.Core.Shared.ModelViews;
using CL_Data.Context;
using CL_Data.Repository;
using CL_Manager.Implementation;
using CL_Manager.Interfaces;
using CL_Manager.ManagerInterface;
using CL_Manager.Mappings;
using CL_Manager.Validator;
using CL_WebApi.Configuration;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

namespace CL_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().WriteTo.File("log.txt").CreateLogger();
            IConfigurationRoot configuration = GetConfiguration();

            ConfiguraLog(configuration);

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDataBaseConfigiration(builder.Configuration);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            // Adcionando as chamadas das config
            builder.Services.UseFluenteValidationConfig();

            builder.Services.UseAutoMapperCongiguration();

            builder.Services.UseDependencyInjectionConfiguration();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerConfiguration();

            builder.Host.UseSerilog();

            var app = builder.Build();

            app.UseExceptionHandler("/erro");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();

            }

            app.UseDataBaseConfiguration();

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void ConfiguraLog(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            string? ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{ambiente}.json")
                .Build();
            return configuration;
        }
    }
}
