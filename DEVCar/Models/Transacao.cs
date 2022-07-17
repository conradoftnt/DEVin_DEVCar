namespace DEVCar.Models;

using DEVCar.Repositories;

public class Transacao
{
    public Veiculo VeiculoTransferido { get; set; }
    public long CompradorCPF { get; set; }
    public float Valor { get; set; }
    public DateTime DataTransacao { get; set; }

    public Transacao(Veiculo veiculoTransferido, long compradorCPF, DateTime dataTransacao)
    {
        VeiculoTransferido = veiculoTransferido;
        Valor = veiculoTransferido.Valor;
        CompradorCPF = compradorCPF;
        DataTransacao = dataTransacao;
    }

    override public string ToString()
    {
        return @$"Veículo infos. : {VeiculoTransferido.ListarInformacoes()}
CPF do comprador: {CompradorCPF}
Data da transação: {DataTransacao}
Valor da transação: {Valor}";
    }

}