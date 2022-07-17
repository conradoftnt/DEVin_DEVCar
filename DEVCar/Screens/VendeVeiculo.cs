namespace DEVCar.Screens;

using DEVCar.Models;
using DEVCar.Repositories;
using System.Text.RegularExpressions;

public static class VendeVeiculo
{
    public static void Start(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista)
    {
        Console.WriteLine("Qual dos veículos deseja vender?");

        Console.Write(Environment.NewLine);

        IList<Veiculo> ListaDeVeiculos = VeiculosLista.VeiculosLista;

        if (VeiculosLista.VeiculosLista.Count == 0)
        {
            Console.WriteLine("Ainda não há veículos no estoque.");
        }
        else
        {
            for (int i = 0; i < ListaDeVeiculos.Count; i++)
            {
                Console.WriteLine($"{i + 1} : {ListaDeVeiculos[i].ListarInformacoes()}");
                Console.Write(Environment.NewLine);
            }
        }

        Console.Write(Environment.NewLine);

        Console.WriteLine("0 : Sair");

        Console.Write(Environment.NewLine);

        Console.Write("Opção: ");
        string? opcao = Console.ReadLine();

        Console.WriteLine("-----------------------------------------");

        try
        {
            if (string.IsNullOrEmpty(opcao))
            {
                throw new FormatException("Você não escolheu nenhuma opção.");
            }
            else
            {
                if (int.TryParse(opcao, out int opcaoIndex))
                {
                    if (opcaoIndex < 0)
                    {
                        throw new FormatException("A opção digitada não é um número válido.");
                    }
                    else
                    {
                        if (opcaoIndex == 0)
                        {
                            Console.Clear();
                            Menu.Start(VeiculosLista, TransacoesLista);
                        }
                        else
                        {
                            Veiculo item = ListaDeVeiculos[opcaoIndex - 1];

                            Console.Write(Environment.NewLine);

                            Console.Write("Digite o CPF do comprador: ");
                            string? CPFComprador = Console.ReadLine();

                            if (string.IsNullOrEmpty(CPFComprador))
                            {
                                throw new FormatException("Você não digitou um valor para o CPF do comprador.");
                            }
                            else
                            {
                                if (Regex.IsMatch(CPFComprador, @"^([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})$"))
                                {
                                    Regex.Replace(CPFComprador, @"\.|\-|\/", String.Empty);

                                    long CPFCompradorInt = long.Parse(CPFComprador);

                                    Console.Write("Data de transação (dd/mm/aaa): ");
                                    string? dataTransacao = Console.ReadLine();

                                    if (string.IsNullOrEmpty(dataTransacao))
                                    {
                                        throw new FormatException(@"O campo 'Data de transação' não pode ser vazio.");
                                    }
                                    else
                                    {
                                        if (!Regex.IsMatch(dataTransacao, @"^(?:0[1-9]|[12][0-9]|3[01])[-/.](?:0[1-9]|1[012])[-/.](?:19\d{2}|20[01][0-9]|2022)$"))
                                        {
                                            throw new FormatException(@"O campo 'Data de transação' deve conter uma data válida entre '01/01/1900' e '31/12/2000'");
                                        }
                                        else
                                        {
                                            string[] listaData = Regex.Split(dataTransacao, @"\/");

                                            int dia = int.Parse(listaData[0]);
                                            int mes = int.Parse(listaData[1]);
                                            int ano = int.Parse(listaData[2]);

                                            DateTime dataTransacaoVeiculo = new DateTime(ano, mes, dia);

                                            item.VenderVeiculo(TransacoesLista, CPFCompradorInt, dataTransacaoVeiculo);
                                        }
                                    }
                                }
                                else
                                {
                                    throw new FormatException("O CPF inserido não é válido.");
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new FormatException("A opção digitada não é um número.");
                }
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("A opção digitada não corresponde a nenhuma possibilidade entregue.");
        }

        catch (FormatException Erro)
        {
            Console.WriteLine(Erro.Message);
        }

        catch (System.Exception Erro)
        {
            Console.WriteLine($"Ocorreu um erro não identificado pelo sistema: {Erro.Message}");
        }

        finally
        {
            Console.Write(Environment.NewLine);
            Console.Write("Pressione qualquer tecla para voltar a seleção de veículos.");
            Console.ReadKey();
            Console.Clear();
            Start(VeiculosLista, TransacoesLista);
        }
    }
}
