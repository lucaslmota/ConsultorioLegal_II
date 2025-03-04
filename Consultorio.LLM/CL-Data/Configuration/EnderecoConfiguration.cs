using CL_Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CL_Data.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.ClienteId);
            builder.HasOne(p => p.Cliente).WithOne(p => p.Endereco).HasForeignKey<Endereco>(p => p.ClienteId);
        }
    }
}
