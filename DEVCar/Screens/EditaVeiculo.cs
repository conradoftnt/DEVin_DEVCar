namespace DEVCar.Screens;

using DEVCar.Repositories;
using DEVCar.Models;

public class EditaVeiculo
{
    public static void Start(VeiculosRepository VeiculosLista, TransacoesRepository TransacoesLista)
    {
        Console.Clear();

        Console.WriteLine("Qual dos veículos deseja editar?");

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

                            Console.Clear();

                            Console.Write(@"Qual informação do veículo deseja atualizar?

1 - Cor
2 - Valor
3 - Ambas

0 - Sair

Opção: ");
                            string? opcaoInfo = Console.ReadLine();

                            Console.WriteLine("-----------------------------------------");

                            switch (opcaoInfo)
                            {
                                case "1":
                                    Console.Write("Digite a cor que deseja atribuir ao veículo: ");
                                    string? cor = Console.ReadLine();

                                    if (string.IsNullOrEmpty(cor))
                                    {
                                        throw new FormatException("Nenhum dado foi inserido na atualização do atributo.");
                                    }
                                    else
                                    {
                                        Console.Write(Environment.NewLine);
                                        item.AlterarInformacoes(cor);
                                    }

                                    break;

                                case "2":
                                    Console.Write("Digite o valor que deseja atribuir ao veículo: ");
                                    string? valor = Console.ReadLine();

                                    if (string.IsNullOrEmpty(valor))
                                    {
                                        throw new FormatException("Nenhum dado foi inserido na atualização do atributo.");
                                    }
                                    else
                                    {
                                        if (float.TryParse(valor, out float newValor))
                                        {
                                            if (newValor <= 0)
                                            {
                                                throw new FormatException("O dado inserido para o campo 'Valor' precisa ser um número positivo.");
                                            }
                                            else
                                            {
                                                Console.Write(Environment.NewLine);
                                                item.AlterarInformacoes(newValor);
                                            }
                                        }
                                        else
                                        {
                                            throw new FormatException("O dado inserido para o campo 'Valor' não é um número.");
                                        }
                                    }

                                    break;

                                case "3":

                                    Console.Write("Digite a cor que deseja atribuir ao veículo: ");
                                    string? cor3 = Console.ReadLine();

                                    if (string.IsNullOrEmpty(cor3))
                                    {
                                        throw new FormatException("Nenhum dado foi inserido na atualização do atributo.");
                                    }
                                    else
                                    {
                                        Console.Write("Digite o valor que deseja atribuir ao veículo: ");
                                        string? valor3 = Console.ReadLine();

                                        if (string.IsNullOrEmpty(valor3))
                                        {
                                            throw new FormatException("Nenhum dado foi inserido na atualização do atributo.");
                                        }
                                        else
                                        {
                                            if (float.TryParse(valor3, out float newValor))
                                            {
                                                if (newValor <= 0)
                                                {
                                                    throw new FormatException("O dado inserido para o campo 'Valor' precisa ser um número positivo.");
                                                }
                                                else
                                                {
                                                    Console.Write(Environment.NewLine);
                                                    item.AlterarInformacoes(cor3, newValor);
                                                }
                                            }
                                            else
                                            {
                                                throw new FormatException("O dado inserido para o campo 'Valor' não é um número.");
                                            }
                                        }
                                    }

                                    break;

                                case "0":
                                    Console.Clear();
                                    Menu.Start(VeiculosLista, TransacoesLista);
                                    break;

                                default:
                                    throw new ArgumentOutOfRangeException();
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