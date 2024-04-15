using Core;
using Core.Datatables;
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

        public HttpStatusCode Delete(int idAvaliacao)
        {
            try
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
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }

        }

        public HttpStatusCode Edit(Avaliacao avaliacao)
        {

            try
            {
                _context.Update(avaliacao);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
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
            var query = (from aV in  _context.Alunoavaliacaos join aT in _context.Alunoturmas
                        on aV.IdAluno equals aT.IdAluno
                        where aV.IdAvaliacao == idAvaliacao && aV.IdAvaliacaoNavigation.IdTurma == idTurma && aT.Status == "M"
                        select new AlunoAvaliacaoNotaDTO
                        {
                            IdAluno = aV.IdAluno,
                            NomeAluno = aV.IdAlunoNavigation.Nome,
                            Notas =aV.Nota
                        }).ToList();

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

            //AlunoAtividades = AlunoAtividades.Skip(request.Start).Take(request.Length).ToList();

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
