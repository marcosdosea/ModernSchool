using System.Net;

namespace Core.Service
{
    public interface IPeriodoService
    {
        HttpStatusCode Create(Periodo periodo);
        HttpStatusCode Edit(Periodo periodo);
        HttpStatusCode Delete(int idPeriodo);
        Periodo Get(int idPeriodo);
        IEnumerable<Periodo> GetAll();
    }
}
