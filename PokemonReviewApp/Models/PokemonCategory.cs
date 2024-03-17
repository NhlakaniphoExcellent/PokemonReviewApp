using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models
{
    public class PokemonCategory
    {
        [Key]
        public int Id { get; set; }
        public int PokemonID { get; set; }
        public int CategoryID { get; set; }
        public Pokemons Pokemons { get; set; }
        public Category Category { get; set; }
        private Guid _id;
        
    }
}
