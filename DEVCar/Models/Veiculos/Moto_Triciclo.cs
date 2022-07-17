using DEVCar.Repositories;

namespace DEVCar.Models;
using System.Text.RegularExpressions;

public class Moto_Triciclo : Veiculo
{
    public short Potencia { get; set; }
    public short TotalRodas { get; set; }

    public Moto_Triciclo(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista, string nome, DateTime dataFabricacao, string placa, string cor, float valor, short potencia, short totalRodas) : base(VeiculosLista, TransacoesLista, nome, dataFabricacao, placa, cor, valor)
    {

        if (potencia > 0)
        {
            if (Regex.IsMatch(potencia.ToString(), @"^[0-9]{3}$"))
            {
                Potencia = potencia;
            }
            else
            {
                throw new FormatException("A potência inserida é inválida.");
            }
        }
        else
        {
            throw new FormatException("A potência do veículo precisa ser positiva.");
        }

        if (Regex.IsMatch(totalRodas.ToString(), @"^[23]$"))
        {
            TotalRodas = totalRodas;
        }
        else
        {
            throw new FormatException("O número de rodas é inválido.");
        }
    }

    public override string ListarInformacoes()
    {
        return $"Nome: {Nome} | Número do Chassi: {NumeroChassi} | Data de Fabricação: {DataFabricacao} | Placa: {Placa} | Cor: {Cor} | Valor: {Valor} | CPF do Comprador: {CPFComprador} | Potência: {Potencia} cv | Número de Rodas: {TotalRodas}";
    }

}