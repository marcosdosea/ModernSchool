using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EscolaService : IEscolaService
    {
        private readonly ModernSchoolContext _context;

        public EscolaService(ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar uma Escola no banco de dados
        /// </summary>
        /// <param name="escola">Dados da escola</param>
        /// <returns>Id do escola</returns>
        public int Create(Escola escola)
        {
            _context.Add(escola);
            _context.SaveChanges();
            return escola.Id;
        }
        /// <summary>
        /// Deletar uma escola no banco de dados
        /// </summary>
        /// <param name="Id">Id da escola</param>
        public void Delete(int idEscola)
        {
            var _escola = _context.Escolas.Find(idEscola);
            _context.Remove(_escola);
            _context.SaveChanges();
        }
        /// <summary>
        /// Editar uma escola no banco de dados
        /// </summary>
        /// <param name="escola">Dados da escola</param>
        public void Edit(Escola escola)
        {
            _context.Update(escola);
            _context.SaveChanges();
        }
        /// <summary>
        /// Consultar uma escola no banco
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Dados da escola</returns>
        public Escola Get(int idEscola)
        {
            return _context.Escolas.Find(idEscola);
        }
        /// <summary>
        /// Consultar todos as escolas no banco
        /// </summary>
        /// <returns>Dados de todos as escolas</returns>
        public IEnumerable<Escola> GetAll()
        {
            return _context.Escolas.AsNoTracking();
        }

        public string GetNomeEscola(int idDiretor)
        {
            var query = _context.Escolas.Where(g => g.IdDiretor == idDiretor)
                .Select(g => g.Nome);
            return query.FirstOrDefault();
        }
    }
}
