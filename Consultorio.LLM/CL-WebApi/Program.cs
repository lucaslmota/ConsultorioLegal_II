
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

namespace CL_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ClContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ClConnection"));
            });

            builder.Services.AddControllers();

            // Adcionando as chamadas das config
            builder.Services.UseFluenteValidationConfig();

            builder.Services.UseAutoMapperCongiguration();

            builder.Services.UseDependencyInjectionConfiguration();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerConfiguration();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
                
            }

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
