using Core.Service;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.DTO;
using System.Net;

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
        public HttpStatusCode Edit(Pessoa pessoa)
        {
            try
            {
                _context.Update(pessoa);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }
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

        public HttpStatusCode MatricularAlunoTurma(Alunoturma alunoTurma)
        {
            try
            {
                var aluno = _context.Alunoturmas.Find(alunoTurma.IdAluno, alunoTurma.IdTurma);
                if(aluno != null)
                {
                    if (_context.Turmas.Find(alunoTurma.IdTurma).VagasDisponiveis == 0)
                    {
                        return HttpStatusCode.BadRequest;
                    }
                    aluno.Status = "M";
                    _context.Update(aluno);
                    var turma = _context.Turmas.Find(alunoTurma.IdTurma);
                    var quantidade = GetAlunosTurma(alunoTurma.IdTurma);
                    turma.VagasDisponiveis = turma.Vagas - (quantidade.Count() + 1);

                    _context.Update(turma);
                    _context.SaveChanges();
                    return HttpStatusCode.OK;
                }
                if (_context.Turmas.Find(alunoTurma.IdTurma).VagasDisponiveis == 0)
                {
                    return HttpStatusCode.BadRequest;
                }
                _context.Add(alunoTurma);
                var turmaNovoAluno = _context.Turmas.Find(alunoTurma.IdTurma);
                var quantidadeNovoAluno = GetAlunosTurma(alunoTurma.IdTurma);
                turmaNovoAluno.VagasDisponiveis = turmaNovoAluno.Vagas - (quantidadeNovoAluno.Count() + 1);
                _context.Update(turmaNovoAluno);
                _context.SaveChanges();

                return HttpStatusCode.OK;

            }
            catch
            {
                return HttpStatusCode.InternalServerError;
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
            return _context.Alunoturmas.Where(g => g.IdAluno == idAluno && g.Status == "M").FirstOrDefault();
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
                    IdComponente = g.IdComponente
                });

            return query.ToList();
        }

        public List<IndexAlunoTurmaDTO> GetAlunosTurma(int idTurma)
        {
            var query = _context.Alunoturmas.Where(g => g.IdTurma == idTurma && g.Status != "C")
                .Select(g => new IndexAlunoTurmaDTO
                {
                    IdAluno = g.IdAluno,
                    NomeAluno = g.IdAlunoNavigation.Nome
                });
            return query.ToList();

        }

        public bool MatricularNovoAlunoTurma(Pessoa aluno, int idTurma)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int idAluno = Create(aluno);

                    if (idAluno != -1)
                    {
                        if(_context.Turmas.Find(idTurma).VagasDisponiveis == 0)
                        {
                            return false;
                        }
                        Alunoturma alunoTurma = new Alunoturma()
                        {
                            IdAluno = idAluno,
                            IdTurma = idTurma
                        };
                        _context.Add(alunoTurma);
                        var turma = _context.Turmas.Find(alunoTurma.IdTurma);
                        var quantidade = GetAlunosTurma(alunoTurma.IdTurma);
                        turma.VagasDisponiveis = turma.Vagas - (quantidade.Count() + 1);
                        _context.Update(turma);
                        _context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    else
                    {

                        transaction.Rollback();
                        return false;
                    }
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public Pessoa GetAluno(int idEscola, string cpf)
        {
            var query = _context.Alunoturmas.Where(g => g.IdTurmaNavigation.AnoLetivoNavigation.IdEscolaNavigation.Id ==  idEscola 
                    && g.IdAlunoNavigation.Cpf == cpf)
                .Select(g => new Pessoa
                {
                    Id = g.IdAluno,
                    Bairro = g.IdAlunoNavigation.Bairro,
                    Cep = g.IdAlunoNavigation.Cep,
                    Cpf = g.IdAlunoNavigation.Cpf,
                    DataNascimento = g.IdAlunoNavigation.DataNascimento,
                    Email = g.IdAlunoNavigation.Email,
                    Nome = g.IdAlunoNavigation.Nome,
                    Numero = g.IdAlunoNavigation.Numero,
                    Rua = g.IdAlunoNavigation.Rua,
                    Cidade = g.IdAlunoNavigation.Cidade,
                    Telefone1 = g.IdAlunoNavigation.Telefone1,
                    Telefone2 = g.IdAlunoNavigation.Telefone2,
                    Complemento = g.IdAlunoNavigation.Complemento,
                    Uf = g.IdAlunoNavigation.Uf
                });
            return query.FirstOrDefault();
        }
        public void DeleteAlunoTurma(int idAluno, int idTurma)
        {
            var alunoTurma = _context.Alunoturmas.Find(idAluno, idTurma);
            alunoTurma.Status = "C";
            var turma = _context.Turmas.Find(idTurma);
            var quantidade = GetAlunosTurma(idTurma);
            turma.VagasDisponiveis = turma.Vagas - (quantidade.Count() - 1);
            _context.Update(turma);
            _context.Update(alunoTurma);
            _context.SaveChanges();
        }
        public bool AlunoMatriculado(int idAluno)
        {
            var query = _context.Alunoturmas.Where(g => g.IdAluno == idAluno && g.Status == "M");

            return query.Any();

        }
    }
}
