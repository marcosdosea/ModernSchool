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
    public class DiarioDeClasseService : IDiarioDeClasseService
    {
         private readonly ModernSchoolContext _context;

        public DiarioDeClasseService(ModernSchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar um novo Diário de classe 
        /// </summary>
        /// <param name="diariodeclasse"></param>
        /// <returns> Id de diário de classe </returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(Diariodeclasse diariodeclasse)
        {
            _context.Add(diariodeclasse);
            _context.SaveChanges();
            return diariodeclasse.Id;
        }

        /// <summary>
        /// Deletar um diário de classe 
        /// </summary>
        /// <param name="diariodeclasse"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int diariodeclasse)
        {
            var diarioClasse = _context.Diariodeclasses.Find(diariodeclasse);
            _context.Remove(diarioClasse);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar um Diario de classe
        /// </summary>
        /// <param name="diariodeclasse"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Edit(Diariodeclasse diariodeclasse)
        {
            _context.Update(diariodeclasse);
            _context.SaveChanges();
        }

        /// <summary>
        /// Pegar um diario de classe 
        /// </summary>
        /// <param name="diariodeclasse"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Diariodeclasse Get(int diariodeclasse)
        {
            var diarioClasse = _context.Diariodeclasses.Find(diariodeclasse);
            return diarioClasse;
        }

        public IEnumerable<Diariodeclasse> GetAll()
        {
            return _context.Diariodeclasses.AsNoTracking();
        }

    }
}
