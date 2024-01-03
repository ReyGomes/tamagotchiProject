using Newtonsoft.Json;
using RestSharp;
using tamagotchiProject.Model;

namespace Tamagotchi.Service;

public class PokemonApiService
{
    public  List<PokemonResult> ObterEspeciesDisponiveis()
    {
        
        var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest();
        var response = client.Execute(request);
        var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);
        return pokemonEspeciesResposta.Results;
    }

    public PokemonDetailsResult ObterDetalhesDaEspecie(PokemonResult especie)
    {
        // Obter as características do Pokémon escolhido
        var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.Name}");
        var request = new RestRequest();
        var response = client.Execute(request);
        return JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);

    }
}