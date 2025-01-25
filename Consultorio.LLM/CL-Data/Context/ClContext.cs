using CL_Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Data.Context
{
    public class ClContext : DbContext
    {
        public ClContext(DbContextOptions<ClContext> options) : base(options){}
        public DbSet<Cliente> Clientes { get; set; }
    }
}
