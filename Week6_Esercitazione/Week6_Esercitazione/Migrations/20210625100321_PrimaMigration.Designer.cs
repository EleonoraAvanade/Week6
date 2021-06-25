﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week6_Esercitazione.Context;

namespace Week6_Esercitazione.Migrations
{
    [DbContext(typeof(AssicurazioneContext))]
    [Migration("20210625100321_PrimaMigration")]
    partial class PrimaMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week6_Esercitazione.Models.Cliente", b =>
                {
                    b.Property<string>("CodiceFiscale")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CodiceFiscale");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Week6_Esercitazione.Models.Polizza", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodiceFiscale")
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("DataStipula")
                        .HasColumnType("datetime");

                    b.Property<double>("ImportoAssicurato")
                        .HasColumnType("float");

                    b.Property<double>("RataMensile")
                        .HasColumnType("float");

                    b.Property<string>("Tipo polizza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.HasIndex("CodiceFiscale");

                    b.ToTable("Polizza");

                    b.HasDiscriminator<string>("Tipo polizza").HasValue("Polizza");
                });

            modelBuilder.Entity("Week6_Esercitazione.Models.PolizzaFurto", b =>
                {
                    b.HasBaseType("Week6_Esercitazione.Models.Polizza");

                    b.Property<int>("PercentualeCoperta")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Polizza furto");
                });

            modelBuilder.Entity("Week6_Esercitazione.Models.PolizzaRCAuto", b =>
                {
                    b.HasBaseType("Week6_Esercitazione.Models.Polizza");

                    b.Property<int>("Cilindrata")
                        .HasColumnType("int");

                    b.Property<string>("Targa")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Polizza RC auto");
                });

            modelBuilder.Entity("Week6_Esercitazione.Models.PolizzaVita", b =>
                {
                    b.HasBaseType("Week6_Esercitazione.Models.Polizza");

                    b.Property<int>("AnniAssicurato")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Polizza vita");
                });

            modelBuilder.Entity("Week6_Esercitazione.Models.Polizza", b =>
                {
                    b.HasOne("Week6_Esercitazione.Models.Cliente", "Cliente")
                        .WithMany("Polizze")
                        .HasForeignKey("CodiceFiscale");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Week6_Esercitazione.Models.Cliente", b =>
                {
                    b.Navigation("Polizze");
                });
#pragma warning restore 612, 618
        }
    }
}
