namespace DEVCar.Tests;

using DEVCar.Models;

public class CaminhoneteRoxa
{
    [Fact]
    public void CaminhoneteRoxaFail()
    {
        Models.Caminhonete caminhoneteFalha_Azul = new Models.Caminhonete(new Repositories.VeiculosRepository(), new Repositories.TransacoesRepository(), "Caminhonete", DateTime.Now, "placaqualquer", "azul", 12345, 2, 123, "gasolina", 123);
    }

    [Fact]
    public void CaminhoneteRoxaSuccess() 
    {
        Models.Caminhonete caminhoneteSucesso_Roxa = new Models.Caminhonete(new Repositories.VeiculosRepository(), new Repositories.TransacoesRepository(), "Caminhonete", DateTime.Now, "placaqualquer", "roxa", 12345, 2, 123, "gasolina", 123);
    }
}