using CL_Core.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Validator
{
    public class TelefoneValidatorView : AbstractValidator<Telefone>
    {
        public TelefoneValidatorView()
        {
            RuleFor(x => x.Numero).Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}[-]?\d{4}$").WithMessage("Formato de telefone incorreto!");
        }
    }
}
