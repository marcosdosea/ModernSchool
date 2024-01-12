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
            _context.Add(frequenciaaluno);
            _context.SaveChanges();
            return frequenciaaluno.IdAluno;
        }

        public void Delete(Frequenciaaluno frequenciaaluno)
        {
            throw new NotImplementedException();
        }

        public void Edit(Frequenciaaluno frequenciaaluno)
        {
            _context.Update(frequenciaaluno);
            _context.SaveChanges();
        }

        public bool ExistFrequencia(int idDiario)
        {
              var queryFrequencia = _context.Frequenciaalunos
             .Where(g => g.IdDiarioDeClasse == idDiario)
             .Select(g => new FrequenciaAlunoDTO
             {
                 IdAluno = g.IdAluno,
                 NomeAluno = g.IdAlunoNavigation.Nome,
                 Faltas = g.Faltas
             }).ToList();

            if (queryFrequencia.Count() != 0)
            {
                return true;
            }
            return false;

        }

        public Frequenciaaluno Get(int idAluno, int idDiario)
        {
            return _context.Frequenciaalunos.Find(idAluno, idDiario);
        }


        public List<FrequenciaAlunoDTO> GetAllFrequenciaAlunoDTO(int idDiario)
        {
            var queryFrequencia = _context.Frequenciaalunos
                 .Where(g => g.IdDiarioDeClasse == idDiario)
                 .Select(g => new FrequenciaAlunoDTO
                 {
                     IdAluno = g.IdAluno,
                     NomeAluno = g.IdAlunoNavigation.Nome,
                     Faltas = g.Faltas
                 }).ToList();

            if (queryFrequencia.Count() != 0)
            {
                return queryFrequencia;
            }

            var query = _context.Alunoturmas
                .Select(q =>
                    new FrequenciaAlunoDTO
                    {
                        IdAluno = q.IdAluno,
                        NomeAluno = q.IdAlunoNavigation.Nome,
                        Faltas = 0
                    });

            return query.ToList();
        }


    }
}
