using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAlunoAvaliacaoService
    {
        int Create(Alunoavaliacao alunoavaliacao);
        HttpStatusCode Edit(Alunoavaliacao alunoavaliacao);
        void Delete(int idAluno, int idAvaliacao);
        Alunoavaliacao Get(int idAluno, int idAvaliacao);
        AlunoAvaliacaoDTO? GetDTO(int idAluno, int idAvaliacao);
        IEnumerable<Alunoavaliacao> GetAll();
        IEnumerable<AlunoAvaliacaoDTO> GetAllDTO();
    }
}
