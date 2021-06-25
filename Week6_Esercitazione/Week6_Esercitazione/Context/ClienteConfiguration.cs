using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Esercitazione.Models;

namespace Week6_Esercitazione.Context
{
    class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        void IEntityTypeConfiguration<Cliente>.Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(k => k.CodiceFiscale);
            builder.Property(k => k.CodiceFiscale).HasMaxLength(16);
            builder.Property("Nome").HasMaxLength(20).IsRequired();
            builder.Property("Cognome").HasMaxLength(20).IsRequired();
            builder.Property("Indirizzo").HasMaxLength(50).IsRequired();
        }
    }
}
