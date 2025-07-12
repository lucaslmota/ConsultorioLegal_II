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
    public class ClienteRepsitory : IClienteRepository
    {
        private readonly ClContext _context;
        public ClienteRepsitory(ClContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClienteAsync() 
        {
            return await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Cliente?> GetIdClienteAsync(int id)
        {
            return await _context.Clientes
                .Include(x => x.Endereco)
                .Include(x => x.Telefones)
                .SingleOrDefaultAsync(x  => x.ClienteId == id);
        }

        //insert
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        //Update
        public async Task<Cliente?> UpdadeteClienteAsync(Cliente cliente)
        {
            var consultCliente =  await _context.Clientes.FindAsync(cliente.ClienteId);

            if(consultCliente is null)
            {
                return null;
            }

            _context.Entry(consultCliente).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        //Delete
        public async Task<Cliente> DeleteClienteAsync(int id)
        {
            var consultCliente  =  await _context.Clientes.FindAsync(id);

            if(consultCliente is null)
            {
                return null;
            }
            var clienteRemovido = _context.Clientes.Remove(consultCliente);
            await _context.SaveChangesAsync();
            return clienteRemovido.Entity;
        }
    }
}
