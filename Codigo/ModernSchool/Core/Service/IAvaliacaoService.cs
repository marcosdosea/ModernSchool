namespace Core.Service
{
    public interface IAvaliacaoService
    {
        int Create(Avaliacao avaliacao);
        void Edit(Avaliacao avaliacao);
        void Delete(int idAvaliacao);
        Avaliacao Get(int idAvaliacao);
        IEnumerable<Avaliacao> GetAll();


    }
}
