using DEVCar.Repositories;
using System.Text.RegularExpressions;

namespace DEVCar.Models;

public class Caminhonete : Veiculo
{
    public short TotalPortas { get; set; }
    public short Potencia { get; set; }
    public string Gasolina_Diesel { get; set; }
    public short CapacidadeCacamba { get; set; }

    public Caminhonete(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista, string nome, DateTime dataFabricacao, string placa, string cor, float valor, short totalPortas, short potencia, string gasolina_Diesel, short capacidadeCacamba) : base(VeiculosLista, TransacoesLista, nome, dataFabricacao, placa, cor, valor)
    {
        if (cor.ToLower() == "roxa")
        {
            Cor = cor.ToLower();
        }
        else
        {
            throw new FormatException("A DEVCar só fabrica caminhonetes na cor 'Roxa'.");
        }

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

        if (gasolina_Diesel.ToLower() == "diesel" | gasolina_Diesel.ToLower() == "gasolina")
        {
            Gasolina_Diesel = gasolina_Diesel.ToLower();
        }
        else
        {
            throw new FormatException("Valor para tipo de Ccombustível do carro inválido (flex ou gasolina).");
        }

        if (capacidadeCacamba > 0)
        {
            if (Regex.IsMatch(capacidadeCacamba.ToString(), @"^([0-9]{4}|[0-9]{3})$"))
            {
                CapacidadeCacamba = capacidadeCacamba;
            }
            else
            {
                throw new FormatException("A capacidade da caçamba inserida é inválida.");
            }
        }
        else
        {
            throw new FormatException("A capacidade da caçamba da caminhonete precisa ser positiva.");
        }
    }

    public override string ListarInformacoes()
    {
        return $"Nome: {Nome} | Número do Chassi: {NumeroChassi} | Data de Fabricação: {DataFabricacao} | Placa: {Placa} | Cor: {Cor} | Valor: {Valor} | CPF do Comprador: {CPFComprador} | Potência: {Potencia} cv | Número de Portas: {TotalPortas} | Gasolina ou Diesel: {Gasolina_Diesel} | Capacidade da Caçamba: {CapacidadeCacamba} litros";
    }

    public override void AlterarInformacoes(string cor)
    {
        Console.WriteLine($"Não é permitido alterar as cores das caminhonetes. Só trabalhamos com Roxo!");
    }

    public override void AlterarInformacoes(float valor)
    {
        Console.WriteLine($"Alterando o atributo do veículo {Nome}: Valor ({Valor} -> {valor})");

        Valor = valor;
    }

    public override void AlterarInformacoes(string cor, float valor)
    {
        Console.WriteLine($"Não é permitido alterar as cores das caminhonetes. Só trabalhamos com Roxo!");
    }
}