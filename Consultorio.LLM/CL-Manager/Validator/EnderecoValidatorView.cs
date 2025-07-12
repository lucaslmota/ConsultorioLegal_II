using Cl.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Validator
{
    public class EnderecoValidatorView : AbstractValidator<NewEndereco>
    {
        public EnderecoValidatorView()
        {
            RuleFor(p => p.CEP).NotNull().NotEmpty().Matches(@"^\d{5}-\d{3}$").WithMessage("Formato de CEP incorreto!");
            RuleFor(p => p.Estado).NotNull();
        }
    }
}
