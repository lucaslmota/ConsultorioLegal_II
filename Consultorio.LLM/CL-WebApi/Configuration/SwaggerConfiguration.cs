using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CL_WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "Api estudo .net",
                        Version = "v1",
                        Description = "Uma api para exercitar novamente",
                        Contact = new OpenApiContact
                        {
                            Name = "Lucas Mota - Bacharel em SI",
                            Email = "lucaslmota0431@gmail.com"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "Cl.Core.Shared.xml");
                c.IncludeXmlComments(xmlPath);
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
