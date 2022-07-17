namespace DEVCar.Screens;

using DEVCar.Repositories;
using DEVCar.Models;

public static class Relatorio_VeiculoVendidoMenorPreco
{
    public static void Start(TransacoesRepository TransacoesLista)
    {
        Console.WriteLine("Veículo vendido com o menor preço");
        Console.WriteLine("-----------------------------------");

        if (TransacoesLista.TransacoesLista.Count == 0)
        {
            Console.WriteLine("Nenhum veículo foi vendido ainda.");
        }
        else
        {
            float valor = TransacoesLista.TransacoesLista[0].Valor;
            Veiculo veiculoMaisBarato = TransacoesLista.TransacoesLista[0].VeiculoTransferido;

            foreach (Transacao item in TransacoesLista.TransacoesLista)
            {
                if (item.Valor < valor)
                {
                    valor = item.Valor;
                    veiculoMaisBarato = item.VeiculoTransferido;
                }
            }

            Console.Write(Environment.NewLine);
            Console.WriteLine(veiculoMaisBarato.ListarInformacoes());
            Console.Write(Environment.NewLine);
            Console.WriteLine("-----------------------------------");
        }
    }
}