using Microsoft.AspNetCore.Mvc;
using pokedex.Models;
using Pokedex.Models;
using System.Text.Json;

namespace pokedex.Controllers
{
    public class PokemonController : Controller
    {
        public async Task<IActionResult> Index(int? pagina = 0)
        {
            const string apiUrl = "http://pokeapi.co/api/v2/pokemon";
            int limit = 200;
            var httpClient = new HttpClient();
            var resonse = await httpClient.GetAsync($"{apiUrl}?limit={limit}&offset={limit * pagina}");

            var content = await resonse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PokemonApiResponse>(content);

            int? i = limit * pagina;

            var pokemonList = new PokemonList();
            foreach(var p in result.Results)
            {
                i++;

                Pokemon pokemon = new();
                pokemon.Name = p.Name;
                pokemon.Url = $"https://assets.pokemon.com/assets/cms2/img/pokedex/detail/{i?.ToString("#000")}.png";

                pokemonList.Pokemons.Add(pokemon);
                pokemonList.Page = pagina;
            }

            return View(pokemonList);
        }

        public async Task<IActionResult> Details(int id)
        {
            const string apiUrl = "http://pokeapi.co/api/v2/pokemon";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{apiUrl}/{id}");

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PokemonDetails.Root>(content);

            result.imageUrl = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{id}.png";

            return PartialView(result);

        }
    }
}
