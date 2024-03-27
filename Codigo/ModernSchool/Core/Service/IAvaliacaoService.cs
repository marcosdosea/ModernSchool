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

        List<AlunoAvaliacaoNotaDTO> GetAllAlunos(int idTurma);
        List<AlunoAvaliacaoNotaDTO> GetAllAlunosAvaliacao(int idTurma, int idAvaliacao);
        List<AlunoAtividadeDTO> GetAlunoAtividades(int idTurma, int idAluno);

        decimal GetNotaPeriodo(int idAluno, int idTurma, int idPeriodo, int idComponente);
        
        bool SalvarNotas(Alunoavaliacao alunoAvaliacao);
    }
}
