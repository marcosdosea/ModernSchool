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
    public class PeriodoService : IPeriodoService
    {
        private readonly ModernSchoolContext _context;

        public PeriodoService(ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar um periodo no banco de dados
        /// </summary>
        /// <param name="periodo">Dados do periodo</param>
        /// <returns>Id do periodo</returns>
        public int Create(Periodo periodo)
        {
            _context.Add(periodo);
            _context.SaveChanges();
            return periodo.Id;
        }
        /// <summary>
        /// Deletar um periodo no banco de dados
        /// </summary>
        /// <param name="idPeriodo">Id do periodo</param>
        public void Delete(int idPeriodo)
        {
            try
            {
                var _periodo = _context.Periodos.Find(idPeriodo);
                _context.Remove(_periodo);
                _context.SaveChanges();
            }
            catch
            {

            }
        }
        /// <summary>
        /// Editar um periodo no banco de dados
        /// </summary>
        /// <param name="periodo">Dados do periodo</param>
        public void Edit(Periodo periodo)
        {
            _context.Update(periodo);
            _context.SaveChanges();
        }
        /// <summary>
        /// Consultar um periodo no banco
        /// </summary>
        /// <param name="idPeriodo"></param>
        /// <returns>Dados do periodo</returns>
        public Periodo Get(int idPeriodo)
        {
            return _context.Periodos.Find(idPeriodo);
        }
        /// <summary>
        /// Consultar todos os periodos no banco
        /// </summary>
        /// <returns>Dados de todos os periodos</returns>
        public IEnumerable<Periodo> GetAll()
        {
            return _context.Periodos.AsNoTracking();
        }
    }
}
