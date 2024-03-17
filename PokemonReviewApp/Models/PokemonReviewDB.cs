using Microsoft.EntityFrameworkCore;

namespace PokemonReviewApp.Models
{
    public class PokemonReviewDB : DbContext
    {
        public PokemonReviewDB(DbContextOptions options) : base(options)
            {

            }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemons> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<PokemonOwner> PokemonOwners{ get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
    }

}
