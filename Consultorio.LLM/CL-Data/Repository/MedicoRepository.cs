using Cl.Core.Shared.Extensions;
using CL_Core.Domain;
using CL_Data.Context;
using CL_Manager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Data.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClContext _clContext;

        public MedicoRepository(ClContext clContext)
        {
            _clContext = clContext;
        }

        public async Task<IEnumerable<Medico>> GetMedicosAsync()
        {
            return await _clContext.Medicos
                   .Include(x => x.Especialidades)
                   .AsNoTracking().ToListAsync();
        }
        public async Task<Medico?> GetMedicoAsync(int id)
        {
            return await _clContext.Medicos
                .Include(p => p.Especialidades)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Medico> InsertMedicoAsync(Medico medico)
        {
            await InsertMedicosEspecilaidades(medico);
            await _clContext.Medicos.AddAsync(medico);
            await _clContext.SaveChangesAsync();
            return medico;
        }
        public async Task<Medico> UpdateMedicoAsync(Medico medico)
        {
            var medicoCnsultado = await _clContext.Medicos.Include(x => x.Especialidades).SingleOrDefaultAsync(x => x.Id == medico.Id);

            if(medicoCnsultado == null)
            {
                return null;
            }
            _clContext.Entry(medicoCnsultado).CurrentValues.SetValues(medico);
            await UpdateMedicoEspecialidades(medico, medicoCnsultado);
            await _clContext.SaveChangesAsync();
            return medicoCnsultado;

        }
        public async Task<Medico> DeleteMedicoAsync(int id)
        {
            var medicoConsultado = await _clContext.Medicos.FindAsync(id);
            if (medicoConsultado == null)
            {
                return null;
            }
            var medicoRemovido = _clContext.Medicos.Remove(medicoConsultado);
            await _clContext.SaveChangesAsync();
            return medicoRemovido.Entity;
        }


        private async Task InsertMedicosEspecilaidades(Medico medico)
        {
            var especialidadesConsultadas = new List<Especialidade>();
            foreach(var especialidade in medico.Especialidades)
            {
                var especialidadesConsultada = await _clContext.Especialidades.FindAsync(especialidade.Id);
                especialidadesConsultadas.Add(especialidadesConsultada);
            }

            medico.Especialidades = especialidadesConsultadas;
        }

        private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
        {
            medicoConsultado.Especialidades.RemoveAll(p => !medico.Especialidades.Contains(p));
            var especialidadesAdicionadas = medico.Especialidades.Except(medicoConsultado.Especialidades).Select(p => p.Id);
            var especialidadesConsultadas = await _clContext.Especialidades.Where(p => especialidadesAdicionadas.Contains(p.Id)).ToListAsync();
            medicoConsultado.Especialidades.AddRange(especialidadesConsultadas);
        }
    }
}
