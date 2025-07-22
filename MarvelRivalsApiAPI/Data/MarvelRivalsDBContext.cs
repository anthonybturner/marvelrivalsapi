using MarvelRivalsApiAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarvelRivalsApiAPI.Data
{
    public class MarvelRivalsDBContext : DbContext
    {
        public MarvelRivalsDBContext(DbContextOptions<MarvelRivalsDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
        // Define DbSets for your entities here
        // public DbSet<YourEntity> YourEntities { get; set; }

        // Example:
        // public DbSet<Player> Players { get; set; }
        public DbSet<MatchHistory> MatchHistory { get; set; }
        public DbSet<MatchPlayer> MatchPlayer { get; set; }
        public DbSet<MatchDetail> MatchDetail { get; set; }
        public DbSet<Badge> Badge { get; set; }

        public DbSet<IsWinInfo> IsWinInfo { get; set; }

    }
}
