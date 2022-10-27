using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class GradeHorarioService : IGradeHorarioService
    {
        private readonly ModernSchoolContext _context;


        public GradeHorarioService(ModernSchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar uma Grade Horaria no banco de dados
        /// </summary>
        /// <param name="gradehoraria">Dados do periodo</param>
        /// <returns>Id do Gradehoraria</returns>

        public int Create(Gradehorario gradehorario)
        {
            _context.Add(gradehorario);
            _context.SaveChanges();
            return gradehorario.Id;

        }
        /// <summary>
        /// Deletar uma Grade Horaria do banco de dados 
        /// </summary>
        /// <param name="idGradeHoraria"></param>


        public void Delete(int idGradehorario)
        {
            var _governo = _context.Gradehorarios.Find(idGradehorario);
            _context.Remove(_governo);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar uma Grade Horaria no banco de dados
        /// </summary>
        /// <param name="gradehoraria">Dados da grade horaria</param>
        public void Edit(Gradehorario gradehorario)
        {
            _context.Update(gradehorario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consultar uma Grade Horaria no banco
        /// </summary>
        /// <param name="idGradehorario"></param>
        /// <returns>Dados da Grade Horaria</returns>
        public Gradehorario Get(int idGradehorario)
        {
            return _context.Gradehorarios.Find(idGradehorario);
        }
        /// <summary>
        /// Consultar todas as grades horarias no banco
        /// </summary>
        /// <returns>Dados de todas as grades de horario</returns>
        public IEnumerable<Gradehorario> GetAll()
        {   
            return _context.Gradehorarios.AsNoTracking();
        }

        public IEnumerable<GradeHorarioDTO> GetAllGradeHorario()
        {
            var query = from grade in _context.Gradehorarios
                        join componente in _context.Componentes
                        on grade.IdComponente equals componente.Id
                        join pessoa in _context.Pessoas on grade.IdProfessor equals pessoa.Id
                        join governo in _context.Governoservidors on pessoa.Id equals governo.IdPessoa
                        join cargo in _context.Cargos on governo.IdCargo equals cargo.IdCargo
                        where cargo.Descricao.Equals("professor")
                        select new GradeHorarioDTO
                        {
                            Id = grade.Id,
                            Componente = componente.Nome,
                            Dia = grade.DiaSemana,
                            HoraFim = grade.HoraFim,
                            HoraInicio = grade.HoraInicio,
                            Professor = pessoa.Nome
                        };
            return query;
                
                        
        }

        public GradeHorarioDTO? GetAGradeHorario(int id)
        {
            /*var q = _context.Gradehorarios
                .Where(g => g.Id == id)
                .Select(g => 
                    new GradeHorarioDTO
                    {
                        Id = id,
                        Componente = g.IdComponenteNavigation.Nome,
                        Dia = g.DiaSemana,
                        HoraFim = g.HoraFim,
                        HoraInicio = g.HoraInicio,
                        Professor = g.IdProfessorNavigation.Nome
                    })
                .FirstOrDefault();*/

            var query = from grade in _context.Gradehorarios
                        join componente in _context.Componentes
                        on grade.IdComponente equals componente.Id
                        join pessoa in _context.Pessoas on grade.IdProfessor equals pessoa.Id
                        join governo in _context.Governoservidors on pessoa.Id equals governo.IdPessoa
                        join cargo in _context.Cargos on governo.IdCargo equals cargo.IdCargo
                        where grade.Id == id
                        select new GradeHorarioDTO
                        {
                            Id = grade.Id,
                            Componente = componente.Nome,
                            Dia = grade.DiaSemana,
                            HoraFim = grade.HoraFim,
                            HoraInicio = grade.HoraInicio,
                            Professor = pessoa.Nome
                        };
            return query.FirstOrDefault(); ;
        }
    }
}