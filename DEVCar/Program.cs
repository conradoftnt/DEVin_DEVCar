namespace DEVCar;

using DEVCar.Models;
using DEVCar.Screens;
using DEVCar.Repositories;
using System.Text.RegularExpressions;

public class Program
{
    private static void Main(string[] args)
    {
        VeiculosRepository VeiculosLista = new VeiculosRepository();
        TransacoesRepository TransacoesLista = new TransacoesRepository();

        Menu.Start(VeiculosLista, TransacoesLista);
    }
}