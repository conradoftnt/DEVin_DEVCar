namespace DEVCar.Screens;

using DEVCar.Repositories;
using DEVCar.Models;

public static class Relatorio_VeiculosDisponiveis
{
    public static void Start(VeiculosRepository VeiculosLista)
    {
        Console.WriteLine("Todos os veículos disponíveis");
        Console.WriteLine("-----------------------------------");

        if (VeiculosLista.VeiculosLista.Count == 0)
        {
            Console.WriteLine("Ainda não há veículos no estoque.");
        }
        else
        {
            foreach (Veiculo item in VeiculosLista.VeiculosLista)
            {
                if (item.CPFComprador == 0)
                {
                    Console.Write(Environment.NewLine);
                    Console.WriteLine(item.ListarInformacoes());
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
    }
}