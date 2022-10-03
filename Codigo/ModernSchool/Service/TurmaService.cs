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
    public class TurmaService : ITurmaService
    {
        private readonly ModernSchoolContext _context;

        public TurmaService(ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar uma turma no banco de dados
        /// </summary>
        /// <param name="turma">Dados da turma</param>
        /// <returns>Id da turma</returns>
        public int Create(Turma turma)
        {
            _context.Add(turma);
            _context.SaveChanges();
            return turma.Id;
        }
        /// <summary>
        /// Deletar uma turma no banco de dados
        /// </summary>
        /// <param name="idPeriodo">Id da turma</param>
        public void Delete(int idTurma)
        {
            var _turma = _context.Turmas.Find(idTurma);
            _context.Remove(_turma);
            _context.SaveChanges();
        }
        /// <summary>
        /// Editar uma turma no banco de dados
        /// </summary>
        /// <param name="turma">Dados da turma</param>
        public void Edit(Turma turma)
        {
            _context.Update(turma);
            _context.SaveChanges();
        }
        /// <summary>
        /// Consultar uma turma no banco
        /// </summary>
        /// <param name="idTurma"></param>
        /// <returns>Dados da turma</returns>
        public Turma Get(int idTurma)
        {
            return _context.Turmas.Find(idTurma);
        }
        /// <summary>
        /// Consultar todos as turmas no banco
        /// </summary>
        /// <returns>Dados de todos as turmas</returns>
        public IEnumerable<Turma> GetAll()
        {
            return _context.Turmas.AsNoTracking();
        }
    }
}
