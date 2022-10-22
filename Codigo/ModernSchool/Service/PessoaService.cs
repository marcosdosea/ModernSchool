using Core.Service;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class PessoaService : IPessoaService
    {
        private readonly ModernSchoolContext _context;

        public PessoaService(ModernSchoolContext context)
        {
            _context = context;
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
