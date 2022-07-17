namespace DEVCar.Screens;

using DEVCar.Repositories;
using DEVCar.Models;

public static class Relatorio_VeiculosVendidos
{
    public static void Start(TransacoesRepository TransacoesLista)
    {
        Console.WriteLine("Todos os veículos vendidos");
        Console.WriteLine("-----------------------------------");

        if (TransacoesLista.TransacoesLista.Count == 0)
        {
            Console.WriteLine("Por enquanto nenhuma transação foi realizada.");
        }
        else
        {
            foreach (Transacao item in TransacoesLista.TransacoesLista)
            {
                Console.Write(Environment.NewLine);
                Console.WriteLine(item.VeiculoTransferido.ListarInformacoes());
                Console.Write(Environment.NewLine);
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}