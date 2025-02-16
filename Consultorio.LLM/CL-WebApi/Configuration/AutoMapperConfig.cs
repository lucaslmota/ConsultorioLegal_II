using CL_Manager.Mappings;

namespace CL_WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void UseAutoMapperCongiguration(this IServiceCollection services)
        {
            /*
             * Em frameworks como o ASP.NET Core, o typeof é usado para registrar serviços e configurar mapeamentos, como no AutoMapper:
             * Aqui,typeof(ClienteViewMappingProfile) indica que essa classe contém configurações de mapeamento que devem ser carregadas pelo AutoMapper.
             */
            services.AddAutoMapper(typeof(ClienteViewMappingProfile), typeof(ClienteUpdateViewMappingProfile));
        }
    }
}
