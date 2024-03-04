using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly ModernSchoolContext _context;

        public AvaliacaoService(ModernSchoolContext context)
        {
            _context = context;
        }
        public int Create(Avaliacao avaliacao)
        {
            _context.Add(avaliacao);
            _context.SaveChanges();

            return avaliacao.Id;
            //throw new NotImplementedException();
        }

        public void Delete(int idAvaliacao)
        {
            var _avaliacao = _context.Avaliacaos.Find(idAvaliacao);
            _context.Remove(_avaliacao);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }

        public void Edit(Avaliacao avaliacao)
        {

            _context.Update(avaliacao);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public Avaliacao Get(int idAvaliacao)
        {
            return _context.Avaliacaos.Find(idAvaliacao);
            //throw new NotImplementedException();
        }
        public List<AvaliacaoDTO> GetAllDTO(int idTurma, int IdComponente)
        {
            var query = _context.Avaliacaos
                .Where(g => g.IdTurma == idTurma && g.IdComponente == IdComponente)
                .Select(g => new AvaliacaoDTO
                {
                    DataEntrega = g.DataEntrega,
                    Id = g.Id,
                    Peso = g.Peso, 
                    TipoDeAtividade = g.TipoDeAtividade
                });

            return query.ToList();

            //throw new NotImplementedException();
        }
                public bool SalvarNotas(Alunoavaliacao alunoAvaliacao)
        {
            _context.Add(alunoAvaliacao);
            _context.SaveChanges();
            return true;
        }


        public IEnumerable<Avaliacao> GetAll()
        {

            return _context.Avaliacaos.AsNoTracking();
            //throw new NotImplementedException();
        }

        public List<AlunoAvaliacaoNotaDTO> GetAllAlunos(int idTurma)
        {
            var query = _context.Alunoturmas
                .Where(g => g.IdTurma == idTurma)
                .Select(g => new AlunoAvaliacaoNotaDTO
                {
                    IdAluno = g.IdAluno,
                    NomeAluno = g.IdAlunoNavigation.Nome,
                });

            return query.ToList();
        }

        public List<AlunoAvaliacaoNotaDTO> GetAllAlunosAvaliacao(int idTurma, int idAvaliacao)
        {
            var query = _context.Alunoavaliacaos
                .Where(g => g.IdAvaliacaoNavigation.IdTurmaNavigation.Id == idTurma && g.IdAvaliacao == idAvaliacao)
                .Select(g => new AlunoAvaliacaoNotaDTO
                {
                    IdAluno = g.IdAluno,
                    NomeAluno = g.IdAlunoNavigation.Nome,
                    Notas = g.Nota
                });

            return query.ToList();
        }

    }
}
