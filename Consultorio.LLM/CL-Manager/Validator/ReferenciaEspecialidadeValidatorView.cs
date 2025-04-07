using Cl.Core.Shared.ModelViews;
using CL_Manager.Interfaces;
using FluentValidation;

namespace CL_Manager.Validator
{
    public class ReferenciaEspecialidadeValidatorView : AbstractValidator<ReferenciaEspecialidade>
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        public ReferenciaEspecialidadeValidatorView(IEspecialidadeRepository especialidadeRepository)
        {
            _especialidadeRepository = especialidadeRepository;
            RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0)
                .Must(id => ExisteNaBase(id)).WithMessage("Especialidade não cadastrada");
        }

        private bool ExisteNaBase(int id)
        {
            return _especialidadeRepository.ExisteAsync(id);
        }
    }
}
