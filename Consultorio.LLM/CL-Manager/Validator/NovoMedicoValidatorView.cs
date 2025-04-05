using Cl.Core.Shared.ModelViews;
using CL_Manager.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Validator
{
    public class NovoMedicoValidatorView : AbstractValidator<NovoMedico>
    {
        public NovoMedicoValidatorView()
        {
            RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(200);

            RuleFor(p => p.CRM).NotNull().NotEmpty().GreaterThan(0);
            
            RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidatorView());
        }
    }
}
