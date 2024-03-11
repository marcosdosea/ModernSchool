using Core.Service;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.DTO;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly ModernSchoolContext _context;

        public PessoaService(ModernSchoolContext context)
        {
            _context = context;
        }

        public bool AdicionarCargo(Pessoa pessoa, int idCargo, int idGoverno)
        {

            var pessoaV = Get(pessoa.Id);
            if (pessoaV == null)
            {
                int idPessoa = Create(pessoa);
                if (idPessoa == -1)
                {
                    return false;
                }

                Governoservidor governoServidor = new Governoservidor
                {
                    IdCargo = idCargo,
                    IdPessoa = idPessoa,
                    DataInicio = DateTime.Now,
                    IdGoverno = idGoverno,
                    Status = "A"
                };
                try
                {
                    _context.Add(governoServidor);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                Governoservidor governoservidor = new Governoservidor();
                if (_context.Governoservidors.Find(idGoverno, pessoaV.Id) == null)
                {
                    governoservidor = new Governoservidor
                    {
                        IdCargo = idCargo,
                        IdPessoa = pessoaV.Id,
                        DataInicio = DateTime.Now,
                        IdGoverno = idGoverno,
                        Status = "A"
                    };

                    try
                    {
                        _context.Add(governoservidor);
                        _context.SaveChanges();
                        return true;

                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;

            }
        }

        public IEnumerable<PessoaProfessorDTO> GetAllProfessor()
        {
            var q = _context.Governoservidors
                    .Where(g => g.IdCargoNavigation.Descricao.Equals("professor"))
                    .OrderBy(g => g.IdPessoaNavigation.Nome)
                    .Select(g =>
                        new PessoaProfessorDTO
                        {
                            CargoPessoa = g.IdCargoNavigation.Descricao,
                            IdPessoa = g.IdPessoa,
                            NomePessoa = g.IdPessoaNavigation.Nome
                        });

            return q;
        }

        /// <summary>
        /// Criar uma pessoa no banco de dados
        /// </summary>
        /// <param name="pessoa">Dados da pessoa</param>
        /// <returns>Id da pessoa</returns>
        public int Create(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
                return pessoa.Id;
            }
            catch
            {
                return -1;
            }

        }

        /// <summary>
        /// Deletar uma pessoa no banco de dados
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var _pessoa = _context.Pessoas.Find(id);
            _context.Remove(_pessoa);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar uma pessoa no banco de dados
        /// </summary>
        /// <param name="pessoa">Dados da pessoa</param>
        public void Edit(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consultar uma pessoa no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dados da pessoa</returns>
        public Pessoa Get(int id)
        {
            return _context.Pessoas.Find(id);
        }

        /// <summary>
        /// Consultar todas as pessoas no banco
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return _context.Pessoas.AsNoTracking();
        }

        public int GetById(string cpf)
        {
            var query = _context.Pessoas.Where(g => g.Cpf == cpf)
                .Select(g => g.Id);
            return query.FirstOrDefault();
        }

        public bool MatricularAlunoTurma(Alunoturma alunoTuram)
        {
            try
            {
                _context.Add(alunoTuram);
                _context.SaveChanges();

                return true;

            }
            catch
            {
                return false;
            }
        }


        public async Task<string> GetByCargo(string email)
        {
            var query = _context.Governoservidors
                .Where(g => g.IdPessoaNavigation.Email == email)
                .Select(g => g.IdCargoNavigation.Descricao);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Pessoa> GetByEmail(string email)
        {
            var query = _context.Pessoas.Where(g => g.Email == email)
                .Select(g => new Pessoa
                {
                    Nome = g.Nome,
                    Id = g.Id,
                });
            return await query.FirstOrDefaultAsync();
        }

        public Alunoturma GetAlunoTurma(int idAluno)
        {
            return _context.Alunoturmas.Where(g => g.IdAluno == idAluno && g.Status == "M").First();
        }

        public List<AlunoComponente> GetListasComponente(int idTurma)
        {


            var query = _context.Gradehorarios.Where(g => g.IdTurma == idTurma)
                .Select(g => new AlunoComponente
                {
                    NomeComponente = g.IdComponenteNavigation.Nome,
                    Local = g.IdTurmaNavigation.Sala,
                    DiaSemana = g.DiaSemana,
                    HoraFim = g.HoraFim,
                    HoraInicio = g.HoraInicio,
                });

            return query.ToList();
        }
    }
}
