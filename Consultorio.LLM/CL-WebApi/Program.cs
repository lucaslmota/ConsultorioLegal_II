
using CL_Data.Context;
using CL_Data.Repository;
using CL_Manager.Implementation;
using CL_Manager.Interfaces;
using CL_Manager.ManagerInterface;
using CL_Manager.Validator;
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

            builder.Services.AddScoped<IClienteRepository, ClienteRepsitory>();
            builder.Services.AddScoped<IClienteManager, ClienteManager>();

            // Add services to the container.

            builder.Services.AddControllers();

            // Add FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<ClienteValidator>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
