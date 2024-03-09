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

        /// <summary>
        /// Criar um novo Diário de classe 
        /// </summary>
        /// <param name="diariodeclasse"></param>
        /// <returns> Id de diário de classe </returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CreateDiarioClasse(Diariodeclasse diariodeclasse, DiarioClasseHabilidade listHabilidade)
        {


            _context.Add(diariodeclasse);
            _context.SaveChanges();

            Objetodeconhecimentodiariodeclasse newObject = new Objetodeconhecimentodiariodeclasse
            {
                IdDiarioDeClasse = diariodeclasse.Id,
                IdObjetoDeConhecimento = listHabilidade.IdObjeto
            };


            _context.Add(newObject );
            _context.SaveChanges(); 


            return 1;
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

        public IEnumerable<ObjetodeconhecimentodiariodeclasseDTO> GetAllDiarioTurmaComponete(int IdProfessor, int IdComponente, int idTurma)
        {
            var query = _context.Objetodeconhecimentodiariodeclasses
                .Where(g => g.IdDiarioDeClasseNavigation.IdTurma == idTurma &&
                    g.IdDiarioDeClasseNavigation.IdComponente == IdComponente
                    && g.IdDiarioDeClasseNavigation.IdProfessor == IdProfessor
                ).OrderBy(g => g.IdDiarioDeClasseNavigation.Data)
                .Select(g => new ObjetodeconhecimentodiariodeclasseDTO
                {
                    UnidadeTematica = g.IdObjetoDeConhecimentoNavigation.IdUnidadeTematicaNavigation.Descricao,
                    IdDiarioClasse = g.IdDiarioDeClasse,
                    IdObjeto = g.IdObjetoDeConhecimento,
                    Data = g.IdDiarioDeClasseNavigation.Data.ToString("dd/MM/yyyy"),

                });
            return query.ToList();
        }

        public IEnumerable<DiarioDeClasseDTO> GetAllDTOs()
        {

            var query = _context.Diariodeclasses
                .Where(g => g.IdProfessor == 3)
                .Select(g => new DiarioDeClasseDTO
                {
                    Id = g.Id,
                    Escola = g.IdTurmaNavigation.AnoLetivoNavigation.IdEscolaNavigation.Nome,
                    Turma = g.IdTurmaNavigation.Turma1,
                    Componente = g.IdComponenteNavigation.Nome
                });
            return query.AsNoTracking().ToList();

        }

        public IEnumerable<DiarioClasseHabilidade> GetAllHabilidade()
        {
            var query = _context.Habilidades
                .Select(g => new DiarioClasseHabilidade
                {
                    Data = "20/05/2024",
                    Habilidade = g.Descricao,
                    ObjetoConhecimento = g.IdObjetoDeConhecimentoNavigation.Descricao,
                    UnidadeTematica = g.IdObjetoDeConhecimentoNavigation.IdUnidadeTematicaNavigation.Descricao,
                    IdObjeto = g.IdObjetoDeConhecimentoNavigation.Id
                });
            return query.AsNoTracking().ToList();
        }

        public DiarioObjeto GetObjetodeconhecimento(int idObjeto)
        {
            var query = _context.Habilidades.Where(g => g.IdObjetoDeConhecimentoNavigation.Id == idObjeto)
                .Select(g => new DiarioObjeto
                {
                    Habilidade = g.Descricao,
                    UnidadeTematica = g.IdObjetoDeConhecimentoNavigation.IdUnidadeTematicaNavigation.Descricao,
                    IdObjeto = idObjeto,
                    ObjetoConhecimento = g.IdObjetoDeConhecimentoNavigation.Descricao
                });
            return query.First();
        }
        public int DeleteDiarioClasse(int IdDiario, int IdObjeto)
        {
            var objetoDiario = _context.Objetodeconhecimentodiariodeclasses.Find(IdObjeto, IdDiario);
            _context.Remove(objetoDiario);
            _context.SaveChanges();
            Delete(IdDiario);
            return 1;
        }
    }
}
