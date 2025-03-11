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
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(x => new { x.ClienteId, x.Numero });
            builder.HasOne(x => x.Cliente).WithMany(x => x.Telefones).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Property(t => t.Numero).IsRequired().HasMaxLength(30);
        }
    }
}
