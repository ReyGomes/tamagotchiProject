
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace tamagotchiProject.Model;

public class PokemonDetailsResult
{
    [JsonPropertyName("abilities")]
    public List<AbilityDetail> Abilities { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    public int Order { get; set; }
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [JsonPropertyName("weight")]
    public int Weight { get; set; }

}

public class AbilityDetail
{
    [JsonPropertyName("ability")]
    public Ability Ability { get; set; }
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
}

public class Ability
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    public string Url { get; set; }
}

