using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FrequenciaAlunoService : IFrequenciaAlunoService
    {
        private readonly ModernSchoolContext _context;
        public FrequenciaAlunoService(ModernSchoolContext context)
        {
            _context = context;
        }

        public int Create(Frequenciaaluno frequenciaaluno)
        {
            throw new NotImplementedException();
        }

        public void Delete(Frequenciaaluno frequenciaaluno)
        {
            throw new NotImplementedException();
        }

        public void Edit(Frequenciaaluno frequenciaaluno)
        {
            if (frequenciaaluno == Get(frequenciaaluno.IdAluno, frequenciaaluno.IdDiarioDeClasse))
            {
                frequenciaaluno.Faltas++;
                _context.Update(frequenciaaluno);
            }
            _context.SaveChanges();
        }

        public Frequenciaaluno Get(int idAluno, int idDiario)
        {
            return _context.Frequenciaalunos.Find(idAluno, idDiario);
        }


        public IEnumerable<FrequenciaAlunoDTO> GetAllFrequenciaAlunoDTO()
        {
            var query = _context.Frequenciaalunos
                .Select(q =>
                    new FrequenciaAlunoDTO
                    {
                        idAluno = q.IdAluno,
                        idDiarioDeClasse = q.IdDiarioDeClasse,
                        faltas = q.Faltas,
                        nomeAluno = q.IdAlunoNavigation.Nome,
                        turma = q.IdDiarioDeClasseNavigation.IdTurmaNavigation.Turma1,
                        componente = q.IdDiarioDeClasseNavigation.IdComponenteNavigation.Nome,
                    });

            return query.AsNoTracking();
        }
    }
}
