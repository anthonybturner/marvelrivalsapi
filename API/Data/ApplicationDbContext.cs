using MarvelRivals.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data.Common;
using static MarvelRivals.Models.API.HeroDto;

namespace MarvelRivals.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       
        }

        public DbSet<GameMap> GameMaps { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet <Models.Entities.Costume> Costumes { get; set; }
        public DbSet<Models.Entities.Transformation> Transformations { get; set; }

    }
}