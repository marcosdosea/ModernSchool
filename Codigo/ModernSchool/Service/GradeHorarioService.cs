using Core;
using Core.Datatables;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        public HttpStatusCode Create(Gradehorario gradehorario)
        {


            try
            {
                // verificar se uma turma tem aula no mesmo dia e hora  
                var turma = _context.Gradehorarios.Where(g => g.IdTurma == gradehorario.IdTurma
                   && g.DiaSemana == gradehorario.DiaSemana &&
                   gradehorario.HoraInicio == g.HoraInicio);

                if (turma.Any())
                {
                    return HttpStatusCode.BadRequest;
                }

                // verificar se professor tem horario em alguma grade no mesmo dia de aula
                var professor = _context.Gradehorarios.Where(g => g.IdProfessor == gradehorario.IdProfessor && g.DiaSemana == gradehorario.DiaSemana &&
                   gradehorario.HoraInicio == g.HoraInicio);
                if(professor.Any())
                {
                    return HttpStatusCode.BadRequest;
                }
                _context.Add(gradehorario);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch 
            {
                return HttpStatusCode.InternalServerError;
            }


        }
        /// <summary>
        /// Deletar uma Grade Horaria do banco de dados 
        /// </summary>
        /// <param name="idGradeHoraria"></param>


        public HttpStatusCode Delete(int idGradehorario)
        {

            try
            {
                var _governo = _context.Gradehorarios.Find(idGradehorario);
                _context.Remove(_governo);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch 
            {
                return HttpStatusCode.InternalServerError;
            }

        }

        /// <summary>
        /// Editar uma Grade Horaria no banco de dados
        /// </summary>
        /// <param name="gradehoraria">Dados da grade horaria</param>
        public HttpStatusCode Edit(Gradehorario gradehorario)
        {
            try
            {
                _context.Update(gradehorario);
                _context.SaveChanges();
                return HttpStatusCode.OK;
            }
            catch
            {
                return HttpStatusCode.InternalServerError;
            }

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

        public IEnumerable<GradeHorarioDTO> GetAllGradeHorario(int idTurma)
        {

            var q = _context.Gradehorarios.Where(g => g.IdTurma == idTurma)
                .OrderBy(g => g.IdComponenteNavigation.Nome)
                .Select(g => 
                    new GradeHorarioDTO
                    {
                        Id = g.Id,
                        Componente = g.IdComponenteNavigation.Nome,
                        Dia = g.DiaSemana,
                        HoraFim = g.HoraFim,
                        HoraInicio = g.HoraInicio,
                        Professor = g.IdProfessorNavigation.Nome
                    });
            return q;
                
                        
        }




        public GradeHorarioDTO? GetAGradeHorario(int id)
        {
            var q = _context.Gradehorarios
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
                .FirstOrDefault();

            return q;
        }

        public IEnumerable<GradeHorarioProfessor> GetAllGradeProfessor(int idProfessor)
        {
            var query = _context.Gradehorarios
               .Where(g => g.IdProfessor == idProfessor)
               .Select(g => new GradeHorarioProfessor
               {
                   Id = g.Id,
                   Escola = g.IdTurmaNavigation.AnoLetivoNavigation.IdEscolaNavigation.Nome,
                   Turma = g.IdTurmaNavigation.Turma1,
                   Componente = g.IdComponenteNavigation.Nome,
                   IdComponente = g.IdComponente,
                   IdTurma = g.IdTurma
                   
               });
            return query.AsNoTracking().ToList();

        }
        public DatatableResponse<GradeHorarioDTO> GetDataPage(DatatableRequest request, int idTurma)
        {
            var gradeHorarios = GetAllGradeHorario(idTurma);

            var totalRecords = GetAllGradeHorario(idTurma).Count();

            if (request.Search != null && request.Search.GetValueOrDefault("value") != null)
            {
                gradeHorarios = gradeHorarios.Where(g => g.Professor.ToLower().ToString().Contains(request.Search.GetValueOrDefault("value"))
                                             || g.Componente.ToString().ToLower().Contains(request.Search.GetValueOrDefault("value").ToLower())).ToList();
            }

            if (request.Order != null && request.Order[0].GetValueOrDefault("column").Equals("0"))
            {
                if (request.Order[0].GetValueOrDefault("dir").Equals("asc"))
                    gradeHorarios = gradeHorarios.OrderBy(g => g.Componente).ToList();
                else
                    gradeHorarios = gradeHorarios.OrderByDescending(g => g.Componente).ToList();
            }
            else if (request.Order != null && request.Order[0].GetValueOrDefault("column").Equals("1"))
            {
                if (request.Order[0].GetValueOrDefault("dir").Equals("asc"))
                    gradeHorarios = gradeHorarios.OrderBy(g => g.Dia).ToList();
                else
                    gradeHorarios = gradeHorarios.OrderByDescending(g => g.Componente).ToList();
            }
            else if (request.Order != null && request.Order[0].GetValueOrDefault("column").Equals("4"))
            {
                if (request.Order[0].GetValueOrDefault("dir").Equals("asc"))
                    gradeHorarios = gradeHorarios.OrderBy(g => g.Professor).ToList();
                else
                    gradeHorarios = gradeHorarios.OrderByDescending(g => g.Professor).ToList();
            }

            int countRecordsFiltered = gradeHorarios.Count();

            gradeHorarios = gradeHorarios.Skip(request.Start).Take(request.Length).ToList();

            return new DatatableResponse<GradeHorarioDTO>
            {
                Data = gradeHorarios.ToList(),
                Draw = request.Draw,
                RecordsFiltered = countRecordsFiltered,
                RecordsTotal = totalRecords
            };


        }
    }
}