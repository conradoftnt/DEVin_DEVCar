namespace DEVCar.Repositories;

using DEVCar.Models;
public class TransacoesRepository
{
    public IList<Transacao> TransacoesLista { get; set; }

    public TransacoesRepository()
    {
        TransacoesLista = new List<Transacao>();
    }
}