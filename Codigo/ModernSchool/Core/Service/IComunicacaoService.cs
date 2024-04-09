using Core.Datatables;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IComunicacaoService
    {
        int Create(Comunicacao comunicacao);
        void Edit(Comunicacao comunicacao);
        void Delete(int idComunicacao);
        Comunicacao Get(int idComunicacao);
        IEnumerable<Comunicacao> GetAll();
        bool SalvarComunicacao(Comunicacao comunicacao, List<IndexAlunoTurmaDTO> alunos);

        List<AlunoComunicacaoDTO> ComunicacaoAluno(int idAluno, int idTurma);
        DatatableResponse<AlunoComunicacaoDTO> GetDataPage(DatatableRequest request, int idAluno, int idTurma);


    }
}
