using Core.DTO;

namespace Core.Service
{
    public interface IAvaliacaoService
    {
        int Create(Avaliacao avaliacao);
        void Edit(Avaliacao avaliacao);
        void Delete(int idAvaliacao);
        Avaliacao Get(int idAvaliacao);
        List<AvaliacaoDTO> GetAllDTO(int idTurma, int IdComponente);
        IEnumerable<Avaliacao> GetAll();


    }
}
