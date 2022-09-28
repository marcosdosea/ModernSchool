namespace Core.Service
{
    public interface IPeriodoService
    {
        int Create(Periodo periodo);
        void Edit(Periodo periodo);
        void Delete(int idPeriodo);
        Periodo Get(int idPeriodo);
        IEnumerable<Periodo> GetAll();
    }
}
