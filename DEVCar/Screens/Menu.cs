using DEVCar.Repositories;

namespace DEVCar.Screens;

public class Menu
{
    public static void Start(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista)
    {
        Console.WriteLine("Bem-Vindo Ao DEV-Car 1.0");
        Console.WriteLine("-------------------------");
        Console.Write(@"1 - Adicionar veículo ao estoque
2 - Vender veículo
3 - Editar veículo
4 - Histórico de transações
5 - Relatórios
0 - Sair

Selecione uma das opções acima: ");
        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                System.Console.Clear();
                AdicionaVeiculo.Start(VeiculosLista, TransacoesLista);
                RetornaMenu(VeiculosLista, TransacoesLista);
                break;
            case "2":
                Console.Clear();
                VendeVeiculo.Start(VeiculosLista, TransacoesLista);
                RetornaMenu(VeiculosLista, TransacoesLista);
                break;
            case "3":
                Console.Clear();
                EditaVeiculo.Start(VeiculosLista, TransacoesLista);
                RetornaMenu(VeiculosLista, TransacoesLista);
                break;
            case "4":
                Console.Clear();
                HistoricoTransacoes.Start(TransacoesLista);
                RetornaMenu(VeiculosLista, TransacoesLista);
                break;
            case "5":
                Console.Clear();
                Relatorios.Start(VeiculosLista, TransacoesLista);
                RetornaMenu(VeiculosLista, TransacoesLista);
                break;
            case "0":
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                Start(VeiculosLista, TransacoesLista);
                break;
        }
    }

    public static void RetornaMenu(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista)
    {
        Console.Write(Environment.NewLine);
        Console.Write("Precione qualquer tecla para retornar ao menu principal.");
        Console.ReadLine();
        Console.Clear();
        Start(VeiculosLista, TransacoesLista);
    }
}
