using API.Veiculos;
using API.Seeds;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Context
{
    public class DEVInCarContext : DbContext 
    {
        public DEVInCarContext() {}

        public DEVInCarContext(DbContextOptions<DEVInCarContext> options) : base(options){}

        public DbSet<Alimento> Alimentos {get;set;}
        public DbSet<TipoAlimento> TipoAlimentos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Alimento>().HasData(AlimentoSeed.AlimentoSeeder);
            modelBuilder.Entity<TipoAlimento>().HasData(AlimentoSeed.TipoAlimentoSeeder);
        }
    }
}