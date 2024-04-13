using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AlunoAvaliacaoService : IAlunoAvaliacaoService
    {
        private readonly ModernSchoolContext _context;

        public AlunoAvaliacaoService(ModernSchoolContext context)
        {
            _context = context;
        }

        public int Create(Alunoavaliacao alunoavaliacao)
        {
            _context.Add(alunoavaliacao);
            _context.SaveChanges();
            return alunoavaliacao.IdAluno;
        }

        public void Delete(int idAluno, int idAvaliacao)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Edit(Alunoavaliacao alunoavaliacao)
        {
            if(alunoavaliacao.Nota > 10) 
            {
                return HttpStatusCode.BadRequest;
            }
            try
            {
                _context.Update(alunoavaliacao);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public Alunoavaliacao Get(int idAluno, int idAvaliacao)
        {
            return _context.Alunoavaliacaos.Find(idAluno, idAvaliacao);
        }

        public IEnumerable<Alunoavaliacao> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AlunoAvaliacaoDTO> GetAllDTO()
        {
            var query = _context.Alunoavaliacaos
                .Where(g => g.IdAvaliacaoNavigation.IdTurma == 1)
                .Select(g =>
                 new AlunoAvaliacaoDTO { 
                     IdAluno = g.IdAluno,
                     IdAvaliacao = g.IdAvaliacao,
                     NomeAluno = g.IdAlunoNavigation.Nome,
                     Nota = g.Nota
                 });
            return query.AsNoTracking();
        }

        public AlunoAvaliacaoDTO? GetDTO(int idAluno, int idAvaliacao)
        {
            throw new NotImplementedException();
        }
    }
}
