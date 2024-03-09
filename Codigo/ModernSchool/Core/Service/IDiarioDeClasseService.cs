using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IDiarioDeClasseService
    {
        int CreateDiarioClasse(Diariodeclasse diariodeclasse, DiarioClasseHabilidade listHabilidade);
        void Edit(Diariodeclasse diariodeclasse);
        void Delete(int diariodeclasse);
        Diariodeclasse Get(int diariodeclasse);
        /// <summary>
        /// Pegar o diario/atividades do professor de uma turma com o determinado componente
        /// </summary>
        /// <returns></returns>
        IEnumerable<ObjetodeconhecimentodiariodeclasseDTO> GetAllDiarioTurmaComponete(int IdProfessor, int IdComponente, int idTurma);
        IEnumerable<DiarioClasseHabilidade> GetAllHabilidade();
        public DiarioObjeto GetObjetodeconhecimento(int idObjeto);
        public int DeleteDiarioClasse(int IdDiario, int IdObjeto);
    }
}
