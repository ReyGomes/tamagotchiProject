
namespace tamagotchiProject.Model;

public class TamagotchiDto
{
    public int Alimentacao{ get;private set; }
    public int Humor { get;private set; }
    public int Energia { get; private set; }
    public int Saude { get; private set; }
    public int Altura { get; set; }
    public int Peso { get; set; }
    public string Nome { get; set; }    

    public List<Habilidade> Habilidades { get; set; }
    public TamagotchiDto()
    {
        var rand = new Random();
        Alimentacao = rand.Next(11);
        Humor = rand.Next(11);
        Energia = rand.Next(11);
        Saude = rand.Next(11);
    }
    public void Alimentar()
    {
        Alimentacao = Math.Min(Alimentacao+2, 10);
        Energia = Math.Min(Energia--, 0);
        Console.WriteLine("Mascote alimentado!");
    }
    public void Brincar()
    {
        Humor = Math.Min(Humor +3, 10);
        Alimentacao = Math.Max(Alimentacao - 2, 0);
        Energia = Math.Max(Energia--, 0);

        Console.WriteLine("Mascote Feliz");
    }
    public void Descansar()
    {
        Energia = Math.Min(Energia + 4, 10);
        Humor = Math.Max(Humor--, 0);

        Console.WriteLine("Mascote dormindo zzzzzz");
    }
    public void DarCarinho()
    {
        Humor = Math.Min(Humor+2, 10);
        Saude = Math.Min(Saude++, 10);
        Console.WriteLine("Mascote Amando [^=^] ");
    }
    public void MostrarStatus()
    {
        Console.WriteLine($"Status do {Nome}:");
        Console.WriteLine($"Alimentação: {Alimentacao}");
        Console.WriteLine($"Humor: {Humor}");
        Console.WriteLine($"Energia: {Energia}");
        Console.WriteLine($"Saúde: {Saude}");
    }
}

public class Habilidade
{
    public string Nome { get; set; }
}