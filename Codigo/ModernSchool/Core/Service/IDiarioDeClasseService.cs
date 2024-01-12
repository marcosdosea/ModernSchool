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
        int CreateDiarioClasse(Diariodeclasse diariodeclasse,DiarioClasseHabilidade listHabilidade);
        void Edit(Diariodeclasse diariodeclasse);
        void Delete(int diariodeclasse);
        Diariodeclasse Get(int diariodeclasse);
        IEnumerable<ObjetodeconhecimentodiariodeclasseDTO> GetAll();
        IEnumerable<DiarioClasseHabilidade> GetAllHabilidade();
    }
}
