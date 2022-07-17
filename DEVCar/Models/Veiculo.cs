using DEVCar.Repositories;
using System.Text.RegularExpressions;

namespace DEVCar.Models;

public class Veiculo
{
    public string NumeroChassi { get; set; }
    public DateTime DataFabricacao { get; set; }
    public string Nome { get; set; }
    public string Placa { get; set; }
    public float Valor { get; set; }
    public long CPFComprador { get; set; }
    public string Cor { get; set; }

    public Veiculo(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista, string nome, DateTime dataFabricacao, string placa, string cor, float valor)
    {
        NumeroChassi = GeraChassi(VeiculosLista);

        Nome = nome;
        DataFabricacao = dataFabricacao;
        Valor = valor;
        CPFComprador = 0;
        Cor = cor;

        if (PlacaUsada(VeiculosLista, placa))
        {
            throw new FormatException("A placa inserida já está sendo utilizada.");
        }
        else
        {
            Placa = placa;
        }
    }

    public void VenderVeiculo(TransacoesRepository TransacoesLista, long CompradorCPF, DateTime DataTransacao)
    {
        Transacao transacao = new Transacao(this, CompradorCPF, DataTransacao);

        CPFComprador = CompradorCPF;

        TransacoesLista.TransacoesLista.Add(transacao);
    }
    public virtual string ListarInformacoes()
    {
        return $"Nome: {Nome} | Número do Chassi: {NumeroChassi} | Data de Fabricação: {DataFabricacao} | Placa: {Placa} | Cor: {Cor} | Valor: {Valor} | CPF do Comprador: {CPFComprador}";
    }

    public virtual void AlterarInformacoes(string cor)
    {
        Console.WriteLine($"Alterando o atributo do veículo {Nome}: Cor ({Cor} -> {cor})");

        Cor = cor;
    }

    public virtual void AlterarInformacoes(float valor)
    {
        Console.WriteLine($"Alterando o atributo do veículo {Nome}: Valor ({Valor} -> {valor})");

        Valor = valor;
    }

    public virtual void AlterarInformacoes(string cor, float valor)
    {
        Console.WriteLine($"Alterando os atributos do veículo {Nome}: Cor ({Cor} -> {cor}) e Valor ({Valor} -> {valor})");

        Cor = cor;
        Valor = valor;
    }
    private string GeraChassi(VeiculosRepository VeiculosLista)
    {
        string chassi = Guid.NewGuid().ToString("N").Substring(15);

        if (Regex.IsMatch(chassi, @"^(?!.*(\w)\1).+$"))
        {
            foreach (Veiculo item in VeiculosLista.VeiculosLista)
            {
                if (item.NumeroChassi == chassi)
                {
                    return GeraChassi(VeiculosLista);
                }
            }

            return chassi;
        }

        return GeraChassi(VeiculosLista);
    }

    private bool PlacaUsada(VeiculosRepository VeiculosLista, string placa)
    {
        foreach (Veiculo item in VeiculosLista.VeiculosLista)
        {
            if (item.Placa == placa)
            {
                return true;
            }
        }

        return false;
    }
}