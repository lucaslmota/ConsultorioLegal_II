using CL_Data.Repository;
using CL_Manager.Implementation;
using CL_Manager.Interfaces;
using CL_Manager.ManagerInterface;

namespace CL_WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void UseDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepsitory>();
            services.AddScoped<IClienteManager, ClienteManager>();
            services.AddScoped<IMedicoManager, MedicoManager>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        }
    }
}
