namespace DEVCar.Screens;

using DEVCar.Repositories;
using DEVCar.Models;

public static class Relatorio_VeiculoVendidoMaiorPreco
{
    public static void Start(TransacoesRepository TransacoesLista)
    {
        Console.WriteLine("Veículo vendido com o maior preço");
        Console.WriteLine("-----------------------------------");

        if (TransacoesLista.TransacoesLista.Count == 0)
        {
            Console.WriteLine("Nenhum veículo foi vendido ainda.");
        }
        else
        {
            float valor = TransacoesLista.TransacoesLista[0].Valor;
            Veiculo veiculoMaisCaro = TransacoesLista.TransacoesLista[0].VeiculoTransferido;

            foreach (Transacao item in TransacoesLista.TransacoesLista)
            {
                if (item.Valor > valor)
                {
                    valor = item.Valor;
                    veiculoMaisCaro = item.VeiculoTransferido;
                }
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine(veiculoMaisCaro.ListarInformacoes());
            Console.Write(Environment.NewLine);
            Console.WriteLine("-----------------------------------");
        }
    }
}