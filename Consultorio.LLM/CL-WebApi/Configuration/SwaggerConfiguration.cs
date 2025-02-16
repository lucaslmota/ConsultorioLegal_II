using Microsoft.OpenApi.Models;

namespace CL_WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api estudo .net", Version = "v1" });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder builder)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI();
            //builder.UseSwaggerUI( c =>
            //{
            //    c.RoutePrefix = string.Empty;
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json","Lucas v1");
            //});
        }
    }
}
