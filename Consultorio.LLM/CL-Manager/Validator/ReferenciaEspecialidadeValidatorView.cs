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
    public class ReferenciaEspecialidadeValidatorView : AbstractValidator<ReferenciaEspecialidade>
    {

        public ReferenciaEspecialidadeValidatorView()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
