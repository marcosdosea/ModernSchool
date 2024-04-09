using Core;
using Core.Datatables;
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
            var _alunoAvaliacao = _context.Alunoavaliacaos.Where(a => a.IdAvaliacao == idAvaliacao);
            foreach (var alunoAvaliacao in _alunoAvaliacao)
            {
                _context.Alunoavaliacaos.Remove(alunoAvaliacao);
            }
            _context.SaveChanges();
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
                    TipoAvaliacao = g.TipoAvaliacao
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

        public List<AlunoAtividadeDTO> GetAlunoAtividades(int idTurma, int idAluno)
        {
            var query = _context.Alunoavaliacaos.Where(g => g.IdAvaliacaoNavigation.IdTurma == idTurma && g.IdAluno == idAluno)
                .Select(g => new AlunoAtividadeDTO
                {
                    Componente = g.IdAvaliacaoNavigation.IdComponenteNavigation.Nome,
                    Data = g.DataEntrega,
                    Descricao = g.IdAvaliacaoNavigation.Descricao
                });

            return query.ToList();
        }

        public decimal GetNotaPeriodo(int idAluno, int idTurma, int idPeriodo, int idComponente)
        {
            var query = _context.Alunoavaliacaos.Where(g => g.IdAluno == idAluno &&
                g.IdAvaliacaoNavigation.IdTurma == idTurma
                && g.IdAvaliacaoNavigation.IdPeriodo == idPeriodo
                && g.IdAvaliacaoNavigation.IdComponente == idComponente
                        )
                .Select(g => g.Nota).ToList();
            if (query.Any())
            {
                return query.Sum();
            }
            return -1;
        }

        public DatatableResponse<AlunoAtividadeDTO> GetDataPage(DatatableRequest request, int idAluno, int idTurma)
        {
            var AlunoAtividades = GetAlunoAtividades(idTurma, idAluno);

            var totalRecords = GetAlunoAtividades(idTurma, idAluno).Count();

            if (request.Search != null && request.Search.GetValueOrDefault("value") != null)
            {
                AlunoAtividades = AlunoAtividades.Where(g => g.Componente.ToLower().ToString().Contains(request.Search.GetValueOrDefault("value"))
                                             || g.Data.ToString().Contains(request.Search.GetValueOrDefault("value").ToLower())).ToList();
            }

            if (request.Order != null && request.Order[0].GetValueOrDefault("column").Equals("0"))
            {
                if (request.Order[0].GetValueOrDefault("dir").Equals("asc"))
                    AlunoAtividades = AlunoAtividades.OrderBy(g => g.Data).ToList();
                else
                    AlunoAtividades = AlunoAtividades.OrderByDescending(g => g.Data).ToList();
            }
            else if (request.Order != null && request.Order[0].GetValueOrDefault("column").Equals("1"))
            {
                if (request.Order[0].GetValueOrDefault("dir").Equals("asc"))
                    AlunoAtividades = AlunoAtividades.OrderBy(g => g.Componente).ToList();
                else
                    AlunoAtividades = AlunoAtividades.OrderByDescending(g => g.Componente).ToList();
            }

            int countRecordsFiltered = AlunoAtividades.Count();

            if (request.Length == -1)
            {
                request.Start = 0;
                request.Length = totalRecords;
            }
            else
            {
                AlunoAtividades = AlunoAtividades.Skip(request.Start).Take(request.Length).ToList();
            }

            AlunoAtividades = AlunoAtividades.Skip(request.Start).Take(request.Length).ToList();

            return new DatatableResponse<AlunoAtividadeDTO>
            {
                Data = AlunoAtividades.ToList(),
                Draw = request.Draw,
                RecordsFiltered = countRecordsFiltered,
                RecordsTotal = totalRecords
            };


        }
    }
}
