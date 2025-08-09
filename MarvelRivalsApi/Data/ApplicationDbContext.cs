using MarvelRivalsApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace MarvelRivals.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hero>(entity =>
            {
                entity.Property(e => e.Team)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null)
                    );
            });

            //   modelBuilder.Entity<MatchHistory>()
            //   .HasOne(mh => mh.MatchPlayer)
            //    .WithMany(mp => mp.PlayerHero);
        }

        public DbSet<GameMap> GameMaps { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<MatchHistory> MatchHistory { get; set; }

    }
}