using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class GovernoServidorService : IGovernoServidorService
    {
        private readonly ModernSchoolContext _context;

        public GovernoServidorService(ModernSchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar um novo Governo Servidor
        /// </summary>
        /// <param name="governoservidor"></param>
        /// <returns>Id Governo</returns>
        public int Create(int idPessoa, int idGoverno, Governoservidor governoservidor)
        {
            Governoservidor _governo = new()
            {
                IdGoverno = idGoverno,
                IdPessoa = idPessoa,
                DataFim = governoservidor.DataFim,
                DataInicio = governoservidor.DataInicio,
                IdCargo = governoservidor.IdCargo,
                Status = governoservidor.Status,
                
            };
           
            _context.Add(governoservidor);
            _context.SaveChanges();
            return idPessoa;
        }

        /// <summary>
        /// Deleta um Governo Servidor
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int idPessoa, int idGoverno)
        {
            var governoservidor = _context.Governoservidors.Find(idGoverno, idPessoa);
            _context.Remove(governoservidor);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edita um Governo Servidor
        /// </summary>
        /// <param name="governoservidor"></param>
        public void Edit(Governoservidor governoservidor)
        {
            _context.Update(governoservidor);
            _context.SaveChanges();
        }

        /// <summary>
        /// Busca um Governo Servidor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um Governo Servidor</returns>
        public Governoservidor Get(int idPessoa, int idGoverno)
        {
            return _context.Governoservidors.Find(idGoverno,idPessoa);
        }

        /// <summary>
        /// Busca uma lista de Governo Servidor
        /// </summary>
        /// <returns>Uma lisda de Governo Servidor</returns>
        public IEnumerable<Governoservidor> GetAll()
        {
            return _context.Governoservidors.AsNoTracking();
        }

        public IEnumerable<GovernoServidorDTO> GetAllDTO()
        {
            var q = _context.Governoservidors
                    .Select(g =>
                    new GovernoServidorDTO
                    {
                        IdPessoa = g.IdPessoa,
                        IdGoverno = g.IdGoverno,
                        NomeCargo = g.IdCargoNavigation.Descricao,
                        NomeGoverno = g.IdGovernoNavigation.Municipio,
                        NomePessoa = g.IdPessoaNavigation.Nome,
                        Status = g.Status
                    });
            return q.AsNoTracking();
        }

        public GovernoServidorDTO? GetDTO(int idPessoa,int idGoverno)
        {
            var q = _context.Governoservidors
                    .Where(g => g.IdPessoa == idPessoa && g.IdGoverno == idGoverno)
                    .Select(g =>
                    new GovernoServidorDTO
                    {
                        IdPessoa = g.IdPessoa,
                        NomeCargo = g.IdCargoNavigation.Descricao,
                        NomeGoverno = g.IdGovernoNavigation.Municipio,
                        NomePessoa = g.IdPessoaNavigation.Nome,
                        DataFim = g.DataFim,
                        DataInicio = g.DataInicio,
                        Status = g.Status
                    });
            return q.FirstOrDefault();
        }

    }
}
