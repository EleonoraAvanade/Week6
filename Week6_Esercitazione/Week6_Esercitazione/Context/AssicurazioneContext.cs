using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6_Esercitazione.Models;

namespace Week6_Esercitazione.Context
{
    class AssicurazioneContext : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Polizza> Polizze { get; set; }
        //public DbSet<PolizzaFurto> PolizzeFurto { get; set; }
        //public DbSet<PolizzaRCAuto> PolizzeRCAuto { get; set; }
        //public DbSet<PolizzaVita> PolizzeVita { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = Assicurazione; Server = .\SQLEXPRESS");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration<Polizza>(new PolizzaConfiguration());
            //modelBuilder.ApplyConfiguration<PolizzaFurto>(new PolizzaFurtoConfiguration());
            //modelBuilder.ApplyConfiguration<PolizzaRCAuto>(new PolizzaRCAutoConfiguration());
            //modelBuilder.ApplyConfiguration<PolizzaVita>(new PolizzaVitaConfiguration());
        }

    }
}
