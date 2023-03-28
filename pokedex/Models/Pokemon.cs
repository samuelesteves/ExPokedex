using System.Text.Json.Serialization;

namespace pokedex.Models
{

    public class PokemonList
    {
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

        public int? Page { get; set; }
    }

    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
