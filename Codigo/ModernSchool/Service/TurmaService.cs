using Core;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.DTO;

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
        /// <param name="turma"></param>
        /// <returns>Id da turma</returns>
        int ITurmaService.Create(Turma turma)
        {
            turma.VagasDisponiveis = turma.Vagas;
            turma.Status = "A";
            _context.Add(turma);
            _context.SaveChanges();
            return turma.Id;
        }

        /// <summary>
        /// Deletar uma turma no banco de dados
        /// </summary>
        /// <param name="id"></param>
        void ITurmaService.Delete(int id)
        {
            var _turma = _context.Turmas.Find(id);
            _context.Remove(_turma);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar uma turma no banco de dados
        /// </summary>
        /// <param name="turma"></param>
        void ITurmaService.Edit(Turma turma)
        {
            _context.Update(turma);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consultar uma turma no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dados da turma</returns>
        Turma ITurmaService.Get(int id)
        {
            return _context.Turmas.Find(id);
        }

        /// <summary>
        /// Consultar todos as turmas no banco
        /// </summary>
        /// <returns>Dados de todos as turmas</returns>
        IEnumerable<Turma> ITurmaService.GetAll()
        {
            return _context.Turmas.AsNoTracking();
        }

        /// <summary>
        /// Consultar as junções de escola professor e componente banco
        /// </summary>
        /// <returns>Dados de todos as junções de escola professor e componente</returns>
        IEnumerable<EscolaProfessorDTO> ITurmaService.EscolaVinculadaProfessor()
        {
            var query = from Turma in _context.Turmas
                        join Gradehorario in _context.Gradehorarios
                        on Turma.Id equals Gradehorario.IdTurma
                        orderby Turma.AnoLetivoNavigation.IdEscolaNavigation.Nome
                        select new EscolaProfessorDTO
                        {
                            IdTurma = Turma.Id,
                            NomeEscola = Turma.AnoLetivoNavigation.IdEscolaNavigation.Nome,
                            NomeComponente = Gradehorario.IdComponenteNavigation.Nome,
                            NomeTurma = Turma.Turma1
                        };
            return query;
        }
    }
}
