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
    public class FrequenciaalunoService : IFrequenciaalunoService
    {
        private readonly ModernSchoolContext _context;

        public FrequenciaalunoService(ModernSchoolContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Criar uma frequencia no banco de dados
        /// </summary>
        /// <param name="frequencia">Dados do frequencia</param>
        /// <returns>Id do frequencia</returns>
        public int Create(Frequenciaaluno frequencia)
        {
            _context.Add(frequencia);
            _context.SaveChanges();
            return frequencia.IdPessoa;
        }

        /// <summary>
        /// Editar uma frequencia  no banco de dados
        /// </summary>
        /// <param name="frequencia">Dados das frequencias</param>
        public void Edit(Frequenciaaluno frequencia)
        {
            _context.Update(frequencia);
            _context.SaveChanges();
        }
        /// <summary>
        /// Consultar uma frequencia no banco
        /// </summary>
        /// <param name="idFrequencia"></param>
        /// <returns>Dados do frequencia</returns>
        public Frequenciaaluno Get(int idFrequencia)
        {
            return _context.Frequenciaalunos.Find(idFrequencia);
        }
        /// <summary>
        /// Consultar todos as frequencias no banco
        /// </summary>
        /// <returns>Dados de todos as frequencias</returns>
        public IEnumerable<Frequenciaaluno> GetAll()
        {
            return (IEnumerable<Frequenciaaluno>)_context.Periodos.AsNoTracking();
            // aqui foi alterado
        }
    }
}
