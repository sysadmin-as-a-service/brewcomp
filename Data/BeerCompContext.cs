using Microsoft.EntityFrameworkCore;

namespace BeerComp.Models
{
    public class BeerCompContext : DbContext
    {
        public BeerCompContext (DbContextOptions<BeerCompContext> options)
            : base(options)
        {
        }

        public DbSet<BeerComp.Models.BeerEntry> BeerEntry {get; set;}
        public DbSet<BeerComp.Models.Owner> Owner {get; set;}
        public DbSet<BeerComp.Models.Voter> Voter {get; set;}
        public DbSet<BeerComp.Models.ScoreCard> ScoreCard {get; set;}
        
    }
}