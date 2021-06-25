using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Esercitazione.Models;

namespace Week6_Esercitazione.Context
{
    class PolizzaConfiguration:IEntityTypeConfiguration<Polizza>
    {
        void IEntityTypeConfiguration<Polizza>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Polizza> builder)
        {
            builder.ToTable("Polizza");
            builder.HasKey(k => k.Numero);
            builder.Property(k => k.DataStipula).HasColumnType("datetime").IsRequired();
            builder.Property(k => k.ImportoAssicurato).HasColumnType("float").IsRequired();
            builder.Property(k => k.RataMensile).HasColumnType("float").IsRequired();
            builder.HasOne(c => c.Cliente).WithMany(p => p.Polizze).HasForeignKey(k => k.CodiceFiscale);
            builder.HasDiscriminator<string>("Tipo polizza")
                .HasValue<PolizzaFurto>("Polizza furto")
                .HasValue<PolizzaRCAuto>("Polizza RC auto")
                .HasValue<PolizzaVita>("Polizza vita");
        }
    }
}
