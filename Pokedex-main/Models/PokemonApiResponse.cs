using System.Text.Json.Serialization;

namespace Pokedex.Models
{
    public class PokemonApiResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("previous")]
        public object Previous { get; set; }

        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
}