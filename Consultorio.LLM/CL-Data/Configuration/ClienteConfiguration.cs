using CL_Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(p => p.ClienteNome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.DtNascimento).IsRequired();
            builder.Property(p => p.Documento).IsRequired().HasMaxLength(14);
            builder.Property(p => p.Sexo).HasConversion(p => p.ToString(), p => (Sexo)Enum.Parse(typeof(Sexo),p));
        }
    }
}
