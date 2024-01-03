using AutoMapper;
using System.Threading.Channels;
using Tamagotchi.Service;
using tamagotchiProject.Model;
using tamagotchiProject.Service;
using tamagotchiProject.View;

namespace tamagotchiProject.Controller;

internal class TamagotchiContoller
{
    private TamagotchiView tamagotchiView { get; set; }
    private PokemonApiService pokemonApiService { get; set; }
    private List<PokemonResult> especiesDisponiveis { get; set; }

    private List<TamagotchiDto> mascotesAdotados { get; set; }
    IMapper mapper { get; set; }
    public TamagotchiContoller()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        mapper = config.CreateMapper();
        tamagotchiView = new TamagotchiView();
        pokemonApiService = new PokemonApiService();
        especiesDisponiveis = pokemonApiService.ObterEspeciesDisponiveis();
        mascotesAdotados = new List<TamagotchiDto>();
    }
    public void Jogar()
    {
        int numMenuPrincipal = 3;
        int mumMenuAdocao = 4;
        string nomeDoJogador = tamagotchiView.ExibirMensagemDeBoasVindas();


        while (true)
        {
            tamagotchiView.ExibirMenuPrincipal();
            //escolha do primeiro menu ...
            int escolha = tamagotchiView.ObterEscolhaDoJogador(numMenuPrincipal);

            switch (escolha)
            {
                case 1:
                    while (true)
                    {
                        //exibição do menu de escolha de adoção
                        tamagotchiView.ExibirMenuDeAdocao();
                        escolha = tamagotchiView.ObterEscolhaDoJogador(mumMenuAdocao);
                        //passado o paramatro para limitar as opções do menu de adoção ...

                        switch (escolha)
                        {
                            //Switch do Segundo menu ...

                            case 1://Ver espécies disponíveis...
                                tamagotchiView.ExibirEspeciesDisponiveis(especiesDisponiveis);
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case 2://Ver detalhes de uma espécie ...
                                tamagotchiView.ExibirEspeciesDisponiveis(especiesDisponiveis);
                                int indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
                                PokemonDetailsResult detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                tamagotchiView.ExibirDetalhesDaEspecie(detalhes);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 3://Adotar um mascote ...
                                tamagotchiView.ExibirEspeciesDisponiveis(especiesDisponiveis);
                                indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
                                detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                tamagotchiView.ExibirDetalhesDaEspecie(detalhes);
                                if (tamagotchiView.ConfirmarAdocao())
                                {
                                    TamagotchiDto tamagotchi = mapper.Map<TamagotchiDto>(detalhes);
                                    mascotesAdotados.Add(tamagotchi);
                                    Console.WriteLine($"Parabéns {nomeDoJogador}! Você adotou um {detalhes.Name}!");
                                    Console.WriteLine("──────────────");
                                    Console.WriteLine("────▄████▄────");
                                    Console.WriteLine("──▄████████▄──");
                                    Console.WriteLine("──██████████──");
                                    Console.WriteLine("──▀████████▀──");
                                    Console.WriteLine("─────▀██▀─────");
                                    Console.WriteLine("──────────────");

                                }
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case 4://Voltar ao menu principal ...
                                break;
                        }
                        if (escolha == 4)
                        {
                            break;
                        }//Segundo break para forçar a saida do segundo Switch e entrando no loop do While(true)
                    }
                    break;

                case 2: //Ver seus mascotes ...

                    bool aux = tamagotchiView.ExibirMascotesAdotados(mascotesAdotados); //vai exibir a lista se houver
                    while(aux)
                    {
                        Console.WriteLine("Selecione com qual deles você deseja interagir ...");
                        int indiceMascote = tamagotchiView.ObterEscolhaDoJogador(mascotesAdotados.Count) - 1;
                        TamagotchiDto mascoteEscolhido = mascotesAdotados[indiceMascote];
                        while (true)
                        {
                            tamagotchiView.ExibirMenuDeInteracao();
                            escolha = tamagotchiView.ObterEscolhaDoJogador(6);
                            switch (escolha)
                            {
                                case 1:
                                    mascoteEscolhido.MostrarStatus();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 2:
                                    mascoteEscolhido.Alimentar();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 3:
                                    mascoteEscolhido.Brincar();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 4:
                                    mascoteEscolhido.Descansar();
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case 5: if (tamagotchiView.EscolhaDeOutroMascoteParaInteracao() == true)
                                    {
                                        tamagotchiView.ExibirMascotesAdotados(mascotesAdotados); //vai exibir a lista se houver
                                        Console.WriteLine("Selecione com qual deles você deseja interagir ...");
                                        indiceMascote = tamagotchiView.ObterEscolhaDoJogador(mascotesAdotados.Count) - 1;
                                        mascoteEscolhido = mascotesAdotados[indiceMascote];
                                    }
                                    break;
                                case 6:
                                    aux = false;
                                    break;
                            }
                            if (escolha == 6)
                            {
                                break;
                            }  
                        }
                    }
                    Console.Clear();
                    break;
                case 3://sair do jogo
                    Console.WriteLine("Obrigado por jogar! Até a próxima ... ");
                    break;
            }
            if (escolha == 3)
            {
                break;
            }
        }
    }
}
