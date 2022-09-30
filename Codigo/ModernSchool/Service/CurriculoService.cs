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
    public class CurriculoService : ICurriculoService
    {
        private readonly ModernSchoolContext _context;
        public CurriculoService(ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar um curriculo no banco de dados
        /// </summary>
        /// <param name="curriculo">Dados do curriculo</param>
        /// <returns>Id do curriculo</returns>
        public int Create(Curriculo curriculo)
        {
            _context.Add(curriculo);
            _context.SaveChanges();
            return curriculo.Id;
        }
        /// <summary>
        /// Deletar um curriculo no banco de dados
        /// </summary>
        /// <param name="idCurriculo">Id do curriculo</param>
        public void Delete(int idCurriculo)
        {
            var _curriculo = _context.Curriculos.Find(idCurriculo);
            _context.Remove(_curriculo);
            _context.SaveChanges();
        }
        /// <summary>
        /// Editar um curriculo no banco de dados
        /// </summary>
        /// <param name="curriculo">Dados do curriculo</param>
        public void Edit(Curriculo curriculo)
        {
            _context.Update(curriculo);
            _context.SaveChanges();
        }
        /// <summary>
        /// Consultar um curriculo no banco
        /// </summary>
        /// <param name="idCurriculo"></param>
        /// <returns>Dados do curriculo</returns>
        public Curriculo Get(int idCurriculo)
        {
            return _context.Curriculos.Find(idCurriculo);
        }
        /// <summary>
        /// Consultar todos os curriculos no banco
        /// </summary>
        /// <returns>Dados de todos os curriculos</returns>
        public IEnumerable<Curriculo> GetAll()
        {
            return _context.Curriculos.AsNoTracking();
        }
    }
}
