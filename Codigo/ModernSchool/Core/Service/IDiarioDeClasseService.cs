using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IDiarioDeClasseService
    {
        HttpStatusCode CreateDiarioClasse(Diariodeclasse diariodeclasse, DiarioClasseHabilidade listHabilidade);
        HttpStatusCode Edit(Diariodeclasse diariodeclasse);
        void Delete(int diariodeclasse);
        Diariodeclasse Get(int diariodeclasse);
        /// <summary>
        /// Pegar o diario/atividades do professor de uma turma com o determinado componente
        /// </summary>
        /// <returns></returns>
        IEnumerable<ObjetodeconhecimentodiariodeclasseDTO> GetAllDiarioTurmaComponete(int IdProfessor, int IdComponente, int idTurma);
        IEnumerable<DiarioClasseHabilidade> GetAllHabilidade(int idComponente, string anoFaixa);
        public DiarioObjeto GetObjetodeconhecimento(int idObjeto);
        public HttpStatusCode DeleteDiarioClasse(int IdDiario, int IdObjeto);

        public List<DiarioAluno> GetDiarioAlunos(int idTurma, int idComponente);
        public int GetFaltaAluno(int idAluno, int idDiario);
    }
}
