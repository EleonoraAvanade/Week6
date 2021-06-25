using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Esercitazione.Models;

namespace Week6_Esercitazione.Context
{
    class PolizzaVitaConfiguration : IEntityTypeConfiguration<PolizzaVita>
    {
        void IEntityTypeConfiguration<PolizzaVita>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PolizzaVita> builder)
        {
            builder.ToTable("PolizzaVita");
            builder.HasKey(k => k.Numero);
            builder.Property(k => k.DataStipula).HasColumnType("datetime").IsRequired();
            builder.Property(k => k.ImportoAssicurato).HasColumnType("float").IsRequired();
            builder.Property(k => k.RataMensile).HasColumnType("float").IsRequired();
            builder.Property(k => k.AnniAssicurato).HasColumnType("smallint").IsRequired();
        }
    }
}
