namespace DEVCar.Screens;

using DEVCar.Repositories;
using DEVCar.Models;

public static class Relatorio_TodasCaminhonetes
{
    public static void Start(VeiculosRepository VeiculosLista)
    {
        Console.WriteLine("Todas as Caminhonetes");
        Console.WriteLine("-----------------------------------");

        if (VeiculosLista.VeiculosLista.Count == 0)
        {
            Console.WriteLine("Ainda não há veículos no estoque.");
        }
        else
        {
            foreach (Veiculo item in VeiculosLista.VeiculosLista)
            {
                if (item is Caminhonete)
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