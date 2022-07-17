namespace DEVCar.Screens;

using DEVCar.Repositories;

public static class Relatorios
{
    public static void Start(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista)
    {
        Console.Clear();

        Console.WriteLine("Relatórios DEVCar");
        Console.WriteLine("------------------------------");
        Console.Write(@"
1 - Listar todos os veículos
2 - Listar todas as Motos/Triciclos
3 - Listar todos os Carros
4 - Listar todas as Caminhonetes
5 - Listar veículos disponíveis
6 - Listar veículos vendidos
7 - Listar veículo vendido com maior preço
8 - Listar veículo vendido com menor preço

0 - Sair

Opção: ");
        string? opcao = Console.ReadLine();

        try
        {
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Relatorio_TodosVeiculos.Start(VeiculosLista);
                    break;
                case "2":
                    Console.Clear();
                    Relatorio_TodosMotosTriciclos.Start(VeiculosLista);
                    break;
                case "3":
                    Console.Clear();
                    Relatorio_TodosCarros.Start(VeiculosLista);
                    break;
                case "4":
                    Console.Clear();
                    Relatorio_TodasCaminhonetes.Start(VeiculosLista);
                    break;
                case "5":
                    Console.Clear();
                    Relatorio_VeiculosDisponiveis.Start(VeiculosLista);
                    break;
                case "6":
                    Console.Clear();
                    Relatorio_VeiculosVendidos.Start(TransacoesLista);
                    break;
                case "7":
                    Console.Clear();
                    Relatorio_VeiculoVendidoMaiorPreco.Start(TransacoesLista);
                    break;
                case "8":
                    Console.Clear();
                    Relatorio_VeiculoVendidoMenorPreco.Start(TransacoesLista);
                    break;
                case "0":
                    Console.Clear();
                    Menu.Start(VeiculosLista, TransacoesLista);
                    break;
                default:
                    Console.Clear();
                    Start(VeiculosLista, TransacoesLista);
                    break;
            }
        }
        catch (FormatException Erro)
        {
            Console.WriteLine(Erro.Message);
        }

        catch (System.Exception Erro)
        {
            Console.WriteLine($"Ocorreu um erro não identificado pelo sistema: {Erro.Message}");
        }

        finally
        {
            Console.Write(Environment.NewLine);
            Console.Write("Pressione qualquer tecla para voltar a seleção de relatórios.");
            Console.ReadKey();
            Console.Clear();
            Start(VeiculosLista, TransacoesLista);
        }
    }
}