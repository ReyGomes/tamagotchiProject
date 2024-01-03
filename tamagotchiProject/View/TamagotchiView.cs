using System.Globalization;
using tamagotchiProject.Model;

namespace tamagotchiProject.View;

internal class TamagotchiView
{

    //MostrarDetalhesDaEspecie(PokemonDetailsResult detalhes)  ConfirmarAdocao()
    //MostrarMascotesAdotados(List<PokemonDetailsResult> mascotesAdotados)
    //ObterEspecieEscolhida(List<PokemonResult> especies)
    public string ExibirMensagemDeBoasVindas()
    {
        Console.WriteLine("\n ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Bem vindo ao PokeGotchi!");
        Console.Write("Digite seu nome: ");
        string nomeDoJogador = Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"\nOlá {nomeDoJogador} bem vindo ao Jogo! \n     Vamos começar!!\n");
        return nomeDoJogador;
    }
    public void ExibirMenuPrincipal()
    {
            Console.WriteLine("Selecione a opção desejada: " +
            $"\n1 - Adotar um mascote virtual" +
            $"\n2 - Ver seus mascotes" +
            $"\n3 - Sair");
    }
    public int ObterEscolhaDoJogador(int auxMax)
    {
        //Condição feita na negativa, qualquer uma das condeições se retornar true emite a mesagem e mantem a requisiçao através do loop ...
        int escolha;
        while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > auxMax)
        {
            Console.WriteLine($"Escolha invalida. Por favor escolha uma opção entre 1 e {auxMax}");
        }
        return escolha;
    }
    public void ExibirMenuDeAdocao()
    {
        Console.Clear();
        Console.WriteLine("\n────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Menu de adoção:");
        Console.WriteLine("1 - Ver espécies disponíveis");
        Console.WriteLine("2 - Ver detalhes de uma espécie");
        Console.WriteLine("3 - Adotar um mascote");
        Console.WriteLine("4 - Voltar ao menu principal");
        Console.WriteLine("Selecione uma opção...");
    }
    public void ExibirEspeciesDisponiveis(List<PokemonResult> especies)
    {
        Console.Clear();
        Console.WriteLine("\n───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Lista de espécies:");
        for (int i = 0; i< especies.Count(); i++)
        {
            Console.WriteLine($"{i+1} - {especies[i].Name}");
        }
    }
    public void ExibirDetalhesDaEspecie(PokemonDetailsResult detalhes)
    {
        Console.WriteLine("\n ──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Detalhes da Espécie:");
        Console.WriteLine("Nome: " + detalhes.Name);
        Console.WriteLine("Altura: " + detalhes.Height);
        Console.WriteLine("Peso: " + detalhes.Weight);
        Console.WriteLine("Habilidades:");
        foreach (var habilidade in detalhes.Abilities)
        {
            Console.WriteLine("- " + habilidade.Ability.Name);
        }
    }
    public int ObterEspecieEscolhida(List<PokemonResult> especies)
    {
        Console.WriteLine("\n───────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        int escolha;
        while (true)
        {
            Console.WriteLine($"Escolha uma espécie pelo numero 1 - {especies.Count}");
            if (int.TryParse(Console.ReadLine(),out escolha)&& escolha >=1 && escolha<=especies.Count+1)
            {
                break;
            }else Console.WriteLine("Escolha inválida");
        }
        return escolha-1;
    }

    public bool ConfirmarAdocao()
    {
        
            Console.WriteLine("\n ──────────────");
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";

    }

    public bool ExibirMascotesAdotados(List<TamagotchiDto> mascotesAdotados)
    {
        Console.Clear();
        Console.WriteLine("\n────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────");
        if (mascotesAdotados.Count == 0)
        {
            Console.WriteLine("Você ainda não adotou nenhum mascote.");
            return false;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Lista dos mascotes adotados...\n");
            for (int i = 0; i < mascotesAdotados.Count; i++)
            {
                Console.WriteLine((i+1) + ". "+ mascotesAdotados[i].Nome);
            }
            Console.WriteLine("\nDeseja interagir com algum dos seus mascotes? (s/n...)");
            string escolha = Console.ReadLine();
            if (escolha == "s")
            {
                return true;
            }
            else return false;
           
        }
    }
    public void ExibirMenuDeInteracao()
    {
        Console.WriteLine("\n ──────────────");
        Console.WriteLine("Menu de Interação!");
        Console.WriteLine("\n1. Saber como seu mascote está ... o.O");
        Console.WriteLine("2. Alimentar ele d_(^.^)_b");
        Console.WriteLine("3. Brincar com o mascote");
        Console.WriteLine("4. Colocar para Ninir Zz.zZ");
        Console.WriteLine("5. Interagir com outro mascote");
        Console.WriteLine("6. Voltar\n");
        Console.WriteLine("Ecolha uma das opções ...");
    }
    public bool EscolhaDeOutroMascoteParaInteracao()
    {
        Console.WriteLine("Deseja interagir com outro mascote da lista? \n(s/n)...");
        string aux = Console.ReadLine();
        if (aux == "s")
        {
            return true;
        }
        else return false;
    }
}
