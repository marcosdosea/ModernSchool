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

        public IEnumerable<PessoaProfessorDTO> GetAllAPI()
        {
            var q = _context.Governoservidors
                    .Where(g => g.IdCargoNavigation.Descricao.Equals("professor"))
                    .OrderBy(g => g.IdPessoaNavigation.Nome)
                    .Select(g =>
                        new PessoaProfessorDTO
                        {
                            CargoPessoa = g.IdCargoNavigation.Descricao,
                            IdPessoa = g.IdPessoa,
                            NomePessoa = g.IdPessoaNavigation.Nome,
                            CPF = g.IdPessoaNavigation.Cpf,
                            Bairro = g.IdPessoaNavigation.Bairro,
                            DataNascimento = g.IdPessoaNavigation.DataNascimento,
                            Idade = g.IdPessoaNavigation.Idade,
                            Numero = g.IdPessoaNavigation.Numero,
                            Rua = g.IdPessoaNavigation.Rua,
                        });

            return q;
        }



        public PessoaProfessorDTO? GetProfessorDTO(int id)
        {
            var q = _context.Governoservidors
                    .Where(g => g.IdCargoNavigation.Descricao.Equals("professor") && g.IdPessoa == id)
                    .Select(g =>
                        new PessoaProfessorDTO
                        {
                            CargoPessoa = g.IdCargoNavigation.Descricao,
                            IdPessoa = g.IdPessoa,
                            NomePessoa = g.IdPessoaNavigation.Nome,
                            CPF = g.IdPessoaNavigation.Cpf,
                            Bairro = g.IdPessoaNavigation.Bairro,
                            DataNascimento = g.IdPessoaNavigation.DataNascimento,
                            Idade = g.IdPessoaNavigation.Idade,
                            Numero = g.IdPessoaNavigation.Numero,
                            Rua = g.IdPessoaNavigation.Rua,
                        });

            return q.FirstOrDefault();
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
        int IPessoaService.Create(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return pessoa.Id;
        }

        /// <summary>
        /// Deletar uma pessoa no banco de dados
        /// </summary>
        /// <param name="id"></param>
        void IPessoaService.Delete(int id)
        {
            var _pessoa = _context.Pessoas.Find(id);
            _context.Remove(_pessoa);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar uma pessoa no banco de dados
        /// </summary>
        /// <param name="pessoa">Dados da pessoa</param>
        void IPessoaService.Edit(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consultar uma pessoa no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dados da pessoa</returns>
        Pessoa IPessoaService.Get(int id)
        {
            return _context.Pessoas.Find(id);
        }

        /// <summary>
        /// Consultar todas as pessoas no banco
        /// </summary>
        /// <returns></returns>
        IEnumerable<Pessoa> IPessoaService.GetAll()
        {
            return _context.Pessoas.AsNoTracking();
        }
    }
}
