using Cl.Core.Shared.ModelViews;
using CL_Core.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Validator
{
    public class ClienteValidatorView : AbstractValidator<NewCliente>
    {
        public ClienteValidatorView()
        {
            RuleFor(x => x.ClienteNome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(80).WithMessage("Nome pode estar muito curto ou muito grande");
            RuleFor(x => x.DtNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130)).WithMessage("Data de nascimento inválida!");
            RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(11).MaximumLength(14).WithMessage("Quantidade de caractes invalido!");
            RuleFor(x => x.Telefones).NotNull().NotEmpty();
            RuleFor(x => x.Sexo).NotNull();
            RuleFor(x => x.Endereco).SetValidator(new EnderecoValidatorView());
             
        }

    }
}
