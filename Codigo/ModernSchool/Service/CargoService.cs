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
    public class CargoService : ICargoService
    {
        private readonly ModernSchoolContext _context;
        public CargoService(ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar um cargo no banco de dados
        /// </summary>
        /// <param name="cargo">Dados do cargo</param>
        /// <returns>Id do cargo</returns>
        public int Create(Cargo cargo)
        {
            _context.Add(cargo);
            _context.SaveChanges();
            return cargo.IdCargo;
        }

        /// <summary>
        /// Deletar um cargo no banco de dados
        /// </summary>
        /// <param name="idCargo">Id do cargo</param>
        public void Delete(int idCargo)
        {
            var _cargo = _context.Cargos.Find(idCargo);
            _context.Remove(_cargo);
            _context.SaveChanges();
        }
        /// <summary>
        /// Editar um cargo no banco de dados
        /// </summary>
        /// <param name="cargo">Dados do cargo</param>
        public void Edit(Cargo cargo)
        {
            _context.Update(cargo);
            _context.SaveChanges();
        }


        /// <summary>
        /// Consultar um cargo no banco
        /// </summary>
        /// <param name="idCargo"></param>
        /// <returns>Dados do cargo</returns>
        public Cargo Get(int idCargo)
        {
            return _context.Cargos.Find(idCargo);
        }
        /// <summary>
        /// Consultar todos os cargo no banco
        /// </summary>
        /// <returns>Dados de todos os cargos</returns>
        public IEnumerable<Cargo> GetAll()
        {
            return _context.Cargos.AsNoTracking();
        }
    }
}
