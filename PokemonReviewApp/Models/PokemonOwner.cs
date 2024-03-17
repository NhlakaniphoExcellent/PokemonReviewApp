using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models
{
    public class PokemonOwner
    {
        [Key]
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int OwnerId { get; set; }
        public Pokemons Pokemons{ get; set; }
        public Owner Owner { get; set; }
    }
}
