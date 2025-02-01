using Cl.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Validator
{
    public class ClienteUpdateValidatorView : AbstractValidator<ClienteUpdateView>
    {
        public ClienteUpdateValidatorView()
        {
            RuleFor(x => x.ClienteId).NotNull().NotEmpty().GreaterThan(0).WithMessage("Id inválido!");
            Include(new ClienteValidatorView());
        }
    }
}
