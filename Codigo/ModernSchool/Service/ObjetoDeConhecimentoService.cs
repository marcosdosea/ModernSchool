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
    public class ObjetoDeConhecimentoService : IObjetoDeConhecimentoService
    {

        private readonly ModernSchoolContext _context;

        public ObjetoDeConhecimentoService(ModernSchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar um ObjetoDeConhecimento no banco de dados
        /// </summary>
        /// <param name="objetodeconhecimento"></param>
        /// <returns>ID de ObjetoDeConhecimento</returns>
        int IObjetoDeConhecimentoService.Create(Objetodeconhecimento objetodeconhecimento)
        {
            _context.Add(objetodeconhecimento);
            _context.SaveChanges();
            return objetodeconhecimento.Id;
        }

        /// <summary>
        /// Deletar um ObjetoDeConhecimento no banco de dados
        /// </summary>
        /// <param name="id"></param>
        void IObjetoDeConhecimentoService.Delete(int id)
        {
            var _objetoDeConhecimento = _context.Objetodeconhecimentos.Find(id);
            _context.Remove(_objetoDeConhecimento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar um ObjetoDeConhecimento no banco de dados
        /// </summary>
        /// <param name="objetodeconhecimento"></param>
        void IObjetoDeConhecimentoService.Edit(Objetodeconhecimento objetodeconhecimento)
        {
            _context.Update(objetodeconhecimento);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consultar um ObjetoDeConhecimento no banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dados do ObjetoDeConhecimento</returns>
        Objetodeconhecimento IObjetoDeConhecimentoService.Get(int id)
        {
            return _context.Objetodeconhecimentos.Find(id);
        }

        /// <summary>
        /// Consultar todos os ObjetoDeConhecimento no banco
        /// </summary>
        /// <returns>Dados de todos os ObjetoDeConhecimento</returns>
        IEnumerable<Objetodeconhecimento> IObjetoDeConhecimentoService.GetAll()
        {
            return _context.Objetodeconhecimentos.AsNoTracking();
        }

    }
}
