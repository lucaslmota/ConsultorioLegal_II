using AutoMapper;
using Cl.Core.Shared.ModelViews;
using CL_Core.Domain;
using CL_Manager.Interfaces;
using CL_Manager.ManagerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Manager.Implementation
{
    public class MedicoManager : IMedicoManager
    {
        private readonly IMedicoRepository _repository;
        private readonly IMapper _mapper;

        public MedicoManager(IMedicoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MedicoView>> GetMedicosAsync()
        {
            return _mapper.Map<IEnumerable<Medico>, IEnumerable<MedicoView>>(await _repository.GetMedicosAsync());
        }
        public async Task<MedicoView> GetMedicoAsync(int id)
        {
            return _mapper.Map<MedicoView>(await _repository.GetMedicoAsync(id));
        }
        public async Task<MedicoView> InsertMedicoAsync(NovoMedico novoMedico)
        {
            var medico = _mapper.Map<Medico>(novoMedico);
            return _mapper.Map<MedicoView>(await _repository.InsertMedicoAsync(medico));
        }
        public async Task<MedicoView> UpdateMedicoAsync(MedicoUpdateView alteraMedico)
        {
            var medico = _mapper.Map<Medico>(alteraMedico);
            return _mapper.Map<MedicoView>(await _repository.UpdateMedicoAsync(medico));
        }

        public async Task DeleteMedicoAsync(int id)
        {
            await _repository.DeleteMedicoAsync(id);
        }




    }
}
