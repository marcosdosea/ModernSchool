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
    public class DiarioDeClasseService : IDiarioDeClasseService
    {
        private readonly ModernSchoolContext _context;
        public DiarioDeClasseService(ModernSchoolContext context)
        {
            _context = context;
        }
        public int Create(Diariodeclasse diarioDeClasse)
        {
            _context.Add(diarioDeClasse);
            _context.SaveChanges();
            return diarioDeClasse.Id;
        }

        public void Delete(int diarioDeClasse)
        {
            var _itemAcervo = _context.Diariodeclasses.Find(diarioDeClasse);
            _context.Remove(_itemAcervo);
            _context.SaveChanges();
        }

        public void Edit(Diariodeclasse diarioDeClasse)
        {
            _context.Update(diarioDeClasse);
            _context.SaveChanges();
        }

        public Diariodeclasse Get(int diarioDeClasse)
        {
            return _context.Diariodeclasses.Find(diarioDeClasse);
        }

        public IEnumerable<Diariodeclasse> GetAll()
        {
            return _context.Diariodeclasses.AsNoTracking();
        }

        public IEnumerable<DiarioDeClasseDTO> GetAllAns(string id)
        {
            var query = from diarioDeClasse in _context.Diariodeclasses
                        orderby diarioDeClasse.IdDiarioDeClasseNavigation.Id descending
                        select new DiarioDeClasseDTO
                        {
                            Id = diarioDeClasse.IdDiarioDeClasseNavigation.Id,
                            IdTurma = diarioDeClasse.IdTurmaNavigation.Id,
                            IdComponente = diarioDeClasse.IdComponenteNavigation.Id,
                            IdProfessor = diarioDeClasse.IdProfessorNavigation.Id
                        };
            return query;
        }
    }
}
