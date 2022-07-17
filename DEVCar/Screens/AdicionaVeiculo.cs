namespace DEVCar.Screens;

using DEVCar.Models;
using DEVCar.Repositories;
using System.Text.RegularExpressions;

public class AdicionaVeiculo
{
    public static void Start(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista)
    {
        Console.WriteLine("Que tipo de veículo deseja adicionar ao estoque?");
        Console.Write(Environment.NewLine);
        Console.Write(@"1 - Moto/Triciclo
2 - Carro
3 - Caminhonete

0 - Voltar ao menu

Opção: ");

        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                RecebeParametros("Moto/Triciclo", VeiculosLista, TransacoesLista);
                break;
            case "2":
                RecebeParametros("Carro", VeiculosLista, TransacoesLista);
                break;
            case "3":
                RecebeParametros("Caminhonete", VeiculosLista, TransacoesLista);
                break;
            case "0":
                Console.Clear();
                Menu.Start(VeiculosLista, TransacoesLista);
                break;
            default:
                Console.Clear();
                Start(VeiculosLista, TransacoesLista);
                break;
        }
    }

    private static void RecebeParametros(string opcao, VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista)
    {
        try
        {
            Console.Clear();

            Console.WriteLine($"Preencha os campos abaixo com as informações do veículo '{opcao}'.");

            Console.Write(Environment.NewLine);

            Console.Write("Nome: ");
            string? nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome))
            {
                throw new FormatException(@"O campo 'Nome' não pode ser vazio.");
            }
            else
            {
                Console.Write("Data de fabricação (dd/mm/aaa): ");
                string? dataFabricacao = Console.ReadLine();

                if (string.IsNullOrEmpty(dataFabricacao))
                {
                    throw new FormatException(@"O campo 'Data de fabricação' não pode ser vazio.");
                }
                else
                {
                    if (!Regex.IsMatch(dataFabricacao, @"^(?:0[1-9]|[12][0-9]|3[01])[-/.](?:0[1-9]|1[012])[-/.](?:19\d{2}|20[01][0-9]|2022)$"))
                    {
                        throw new FormatException(@"O campo 'Data de fabricação' deve conter uma data válida entre '01/01/1900' e '31/12/2022'");
                    }
                    else
                    {
                        string[] listaData = Regex.Split(dataFabricacao, @"\/");

                        int dia = int.Parse(listaData[0]);
                        int mes = int.Parse(listaData[1]);
                        int ano = int.Parse(listaData[2]);

                        DateTime dataFabricacaoVeiculo = new DateTime(ano, mes, dia);

                        Console.Write("Placa: ");
                        string? placa = Console.ReadLine();

                        if (string.IsNullOrEmpty(placa))
                        {
                            throw new FormatException(@"O campo 'Placa' não pode ser vazio.");
                        }
                        else
                        {
                            Console.Write("Cor: ");
                            string? cor = Console.ReadLine();

                            if (string.IsNullOrEmpty(cor))
                            {
                                throw new FormatException(@"O campo 'Cor' não pode ser vazio.");
                            }
                            else
                            {
                                Console.Write("Valor: ");
                                string? valor = Console.ReadLine();

                                if (string.IsNullOrEmpty(valor))
                                {
                                    throw new FormatException(@"O campo 'Valor' não pode ser vazio.");
                                }
                                else
                                {
                                    if (!float.TryParse(valor, out float valorVeiculo))
                                    {
                                        throw new FormatException("O campo 'Valor' precisa ser um número.");
                                    }
                                    else
                                    {
                                        if (valorVeiculo <= 0)
                                        {
                                            throw new FormatException("O campo 'Valor' precisa ser um número positivo.");
                                        }
                                        else
                                        {
                                            Console.Write("Potência: ");
                                            string? potencia = Console.ReadLine();

                                            if (string.IsNullOrEmpty(potencia))
                                            {
                                                throw new FormatException(@"O campo 'Potência' não pode ser vazio.");
                                            }
                                            else
                                            {
                                                if (!short.TryParse(potencia, out short potenciaVeiculo))
                                                {
                                                    throw new FormatException("O campo 'Potência' precisa ser um número.");
                                                }
                                                else
                                                {
                                                    if (opcao == "Moto/Triciclo")
                                                    {
                                                        Console.Write("Total de Rodas: ");
                                                        string? totalRodas = Console.ReadLine();

                                                        if (string.IsNullOrEmpty(totalRodas))
                                                        {
                                                            throw new FormatException(@"O campo 'Total de Rodas' não pode ser vazio.");
                                                        }
                                                        else
                                                        {
                                                            if (!short.TryParse(totalRodas, out short totalRodasVeiculo))
                                                            {
                                                                throw new FormatException("O campo 'Total de Rodas' precisa ser um número.");
                                                            }
                                                            else
                                                            {
                                                                Moto_Triciclo moto_Triciclo = new Moto_Triciclo(VeiculosLista, TransacoesLista, nome, dataFabricacaoVeiculo, placa, cor, valorVeiculo, potenciaVeiculo, totalRodasVeiculo);
                                                                Console.Write(Environment.NewLine);
                                                                Console.WriteLine(moto_Triciclo.ListarInformacoes());
                                                                VeiculosLista.VeiculosLista.Add(moto_Triciclo);
                                                            }
                                                        }
                                                    }
                                                    if (opcao == "Carro")
                                                    {
                                                        Console.Write("Total de Portas: ");
                                                        string? totalPortas = Console.ReadLine();

                                                        if (string.IsNullOrEmpty(totalPortas))
                                                        {
                                                            throw new FormatException(@"O campo 'Total de Portas' não pode ser vazio.");
                                                        }
                                                        else
                                                        {
                                                            if (!short.TryParse(totalPortas, out short totalPortasVeiculo))
                                                            {
                                                                throw new FormatException("O campo 'Total de Portas' precisa ser um número.");
                                                            }
                                                            else
                                                            {
                                                                Console.Write("Tipo de Combustível (flex ou gasolina): ");
                                                                string? flex_gasolina = Console.ReadLine();

                                                                if (string.IsNullOrEmpty(flex_gasolina))
                                                                {
                                                                    throw new FormatException(@"O campo 'Tipo de Combustível' não pode ser vazio.");
                                                                }
                                                                else
                                                                {
                                                                    Carro carro = new Carro(VeiculosLista, TransacoesLista, nome, dataFabricacaoVeiculo, placa, cor, valorVeiculo, totalPortasVeiculo, flex_gasolina, potenciaVeiculo);
                                                                    Console.Write(Environment.NewLine);
                                                                    Console.WriteLine(carro.ListarInformacoes());
                                                                    VeiculosLista.VeiculosLista.Add(carro);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (opcao == "Caminhonete")
                                                    {
                                                        Console.Write("Total de Portas: ");
                                                        string? totalPortas = Console.ReadLine();

                                                        if (string.IsNullOrEmpty(totalPortas))
                                                        {
                                                            throw new FormatException(@"O campo 'Total de Portas' não pode ser vazio.");
                                                        }
                                                        else
                                                        {
                                                            if (!short.TryParse(totalPortas, out short totalPortasVeiculo))
                                                            {
                                                                throw new FormatException("O campo 'Total de Portas' precisa ser um número.");
                                                            }
                                                            else
                                                            {
                                                                Console.Write("Tipo de Combustível (gasolina ou diesel): ");
                                                                string? gasolina_diesel = Console.ReadLine();

                                                                if (string.IsNullOrEmpty(gasolina_diesel))
                                                                {
                                                                    throw new FormatException(@"O campo 'Tipo de Combustível' não pode ser vazio.");
                                                                }
                                                                else
                                                                {
                                                                    Console.Write("Capacidade da Caçamba: ");
                                                                    string? capacidadeCacamba = Console.ReadLine();

                                                                    if (string.IsNullOrEmpty(capacidadeCacamba))
                                                                    {
                                                                        throw new FormatException(@"O campo 'Capacidade da Caçamba' não pode ser vazio.");
                                                                    }
                                                                    else
                                                                    {
                                                                        if (!short.TryParse(capacidadeCacamba, out short capacidadeCacambaVeiculo))
                                                                        {
                                                                            throw new FormatException("O campo 'Capacidade da Caçamba' precisa ser um número.");
                                                                        }
                                                                        else
                                                                        {
                                                                            Caminhonete caminhonete = new Caminhonete(VeiculosLista, TransacoesLista, nome, dataFabricacaoVeiculo, placa, cor, valorVeiculo, totalPortasVeiculo, potenciaVeiculo, gasolina_diesel, capacidadeCacambaVeiculo);
                                                                            Console.Write(Environment.NewLine);
                                                                            Console.WriteLine(caminhonete.ListarInformacoes());
                                                                            VeiculosLista.VeiculosLista.Add(caminhonete);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        catch (FormatException Erro)
        {
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.WriteLine(Erro.Message);
            Console.Write("Pressione qualquer tecla para reiniciar a inserção de dados do veículo.");
            Console.ReadKey();
            Console.Clear();
            RecebeParametros(opcao, VeiculosLista, TransacoesLista);
        }

        catch (ArgumentOutOfRangeException)
        {
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.WriteLine("Ocorreu um erro na inserção de um campo. Por favor, recomece a inserção dos dados. Cuidado para preencher datas e valores válidos!");
            Console.Write("Pressione qualquer tecla para reiniciar a inserção de dados do veículo.");
            Console.ReadKey();
            Console.Clear();
            RecebeParametros(opcao, VeiculosLista, TransacoesLista);
        }

        catch (SystemException)
        {
            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);
            Console.WriteLine("Ocorreu um erro não reconhecido pelo sistema.");
            Console.Write("Pressione qualquer tecla para reiniciar a inserção de dados do veículo.");
            Console.ReadKey();
            Console.Clear();
            RecebeParametros(opcao, VeiculosLista, TransacoesLista);
        }
    }
}