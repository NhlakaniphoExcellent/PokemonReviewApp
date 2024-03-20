using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.DataContext
{
    public class PokemonReviewDB : DbContext
    {
        public PokemonReviewDB(DbContextOptions<PokemonReviewDB> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemons> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(x => new { x.PokemonID, x.CategoryID });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(x => x.Pokemons)
                .WithMany(x => x.PokemonCategories)
                .HasForeignKey(c => c.PokemonID);

            modelBuilder.Entity<PokemonCategory>()
               .HasOne(x => x.Category)
                .WithMany(x => x.PokemonCategories)
                .HasForeignKey(c => c.CategoryID);

            modelBuilder.Entity<PokemonOwner>()
               .HasKey(x => new { x.PokemonId, x.OwnerId });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(x => x.Pokemons)
                .WithMany(x => x.PokemonOwners)
                .HasForeignKey(c => c.PokemonId);

            modelBuilder.Entity<PokemonOwner>()
               .HasOne(x => x.Owner)
                .WithMany(x => x.PokemonOwners)
                .HasForeignKey(c => c.OwnerId);
        }
        
    }

}
