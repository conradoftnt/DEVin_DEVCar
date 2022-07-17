namespace DEVCar.Repositories;

using DEVCar.Models;
public class VeiculosRepository
{
    public IList<Veiculo> VeiculosLista { get; set; }

    public VeiculosRepository()
    {
        VeiculosLista = new List<Veiculo>();
    }
}