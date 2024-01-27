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

                Governoservidor governo = new Governoservidor
                {
                    IdCargo = idCargo,
                    IdPessoa = pessoaV.Id,
                    DataInicio = DateTime.Now,
                    IdGoverno = idGoverno,
                    Status = "A"
                };

                try
                {
                    _context.Add(governo);
                    _context.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
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
    }
}
