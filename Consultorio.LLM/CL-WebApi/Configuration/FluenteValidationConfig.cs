using CL_Manager.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CL_WebApi.Configuration
{
    public static class FluenteValidationConfig
    {
        public static void UseFluenteValidationConfig(this IServiceCollection services)
        {
            // Add FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ClienteValidatorView>();
            services.AddValidatorsFromAssemblyContaining<ClienteUpdateValidatorView>();
            services.AddValidatorsFromAssemblyContaining<EnderecoValidatorView>();
            services.AddValidatorsFromAssemblyContaining<TelefoneValidatorView>();
        }
    }
}
