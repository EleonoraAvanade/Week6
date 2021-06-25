using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Esercitazione.Models;

namespace Week6_Esercitazione.Context
{
    class PolizzaRCAutoConfiguration: IEntityTypeConfiguration<PolizzaRCAuto>
    {
        void IEntityTypeConfiguration<PolizzaRCAuto>.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PolizzaRCAuto> builder) {
            builder.ToTable("PolizzaRCAuto");
            builder.HasKey(k => k.Numero);
            builder.Property(k => k.DataStipula).HasColumnType("datetime").IsRequired();
            builder.Property(k => k.ImportoAssicurato).HasColumnType("float").IsRequired();
            builder.Property(k => k.RataMensile).HasColumnType("float").IsRequired();
            builder.Property(k => k.Cilindrata).HasColumnType("intger").IsRequired();
            builder.Property(k => k.Targa).HasMaxLength(5).IsRequired();
        }
    }
}
