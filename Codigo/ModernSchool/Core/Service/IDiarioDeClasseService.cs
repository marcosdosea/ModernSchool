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
        int Create(Diariodeclasse diarioDeClasse);
        void Edit(Diariodeclasse diarioDeClasse);
        void Delete(int idDiarioDeClasse);
        Diariodeclasse Get(int idDiarioDeClasse);
        IEnumerable<Diariodeclasse> GetAll();

        IEnumerable<DiarioDeClasseDTO> GetAllAns(string id ); 
    }
}
