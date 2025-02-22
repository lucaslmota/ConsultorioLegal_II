using CL_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CL_WebApi.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfigiration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ClConnection"));
            });
        }

        //Um ponto legal para usar em trabalhos futuros pois grante que aplica migrações pendentes.
        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetService<ClContext>();
            context?.Database.Migrate();
            //Para que caso ocorra um erro no migation ele cria o BD, mas cria o banco de dados, mas ignora completamente as migrações.
            //context?.Database.EnsureCreated();
        }

    }
}
