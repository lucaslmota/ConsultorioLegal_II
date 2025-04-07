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
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly ClContext _context;

        public EspecialidadeRepository(ClContext context)
        {
            _context = context;
        }

        public bool ExisteAsync(int id)
        {
            return  _context.Especialidades.Find(id) != null;
        }
    }
}
