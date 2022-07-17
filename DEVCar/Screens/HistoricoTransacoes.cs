namespace DEVCar.Screens;

using DEVCar.Models;
using DEVCar.Repositories;
public static class HistoricoTransacoes
{
    public static void Start(TransacoesRepository TransacoesLista)
    {
        Console.WriteLine("Histórico de Transações");
        Console.WriteLine("-----------------------------------------");
        Console.Write(Environment.NewLine);

        if (TransacoesLista.TransacoesLista.Count == 0)
        {
            Console.WriteLine("Por enquanto nenhuma transação foi realizada.");
        }
        else
        {
            foreach (Transacao item in TransacoesLista.TransacoesLista)
            {
                Console.WriteLine(item.ToString());
                Console.Write(Environment.NewLine);
                Console.WriteLine("-----------------------------------------");
                Console.Write(Environment.NewLine);
            }
        }
    }
}