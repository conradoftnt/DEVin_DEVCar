using DEVCar.Repositories;
using System.Text.RegularExpressions;

namespace DEVCar.Models;

public class Carro : Veiculo
{
    public short TotalPortas { get; set; }
    public string Flex_Gasolina { get; set; }
    public short Potencia { get; set; }

    public Carro(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista, string nome, DateTime dataFabricacao, string placa, string cor, float valor, short totalPortas, string flex_gasolina, short potencia) : base(VeiculosLista, TransacoesLista, nome, dataFabricacao, placa, cor, valor)
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

        if (Regex.IsMatch(totalPortas.ToString(), @"^[0-4]$"))
        {
            TotalPortas = totalPortas;
        }
        else
        {
            throw new FormatException("O número de portas é inválido.");
        }

        if (flex_gasolina == "flex" | flex_gasolina == "gasolina")
        {
            Flex_Gasolina = flex_gasolina;
        }
        else
        {
            throw new FormatException("Valor para tipo de Ccombustível do carro inválido (flex ou gasolina).");
        }
    }

    public override string ListarInformacoes()
    {
        return $"Nome: {Nome} | Número do Chassi: {NumeroChassi} | Data de Fabricação: {DataFabricacao} | Placa: {Placa} | Cor: {Cor} | Valor: {Valor} | CPF do Comprador: {CPFComprador} | Potência: {Potencia} cv | Número de Portas: {TotalPortas} | Flex ou Gasolina: {Flex_Gasolina}";
    }
}