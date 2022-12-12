using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.Service
{
    public interface IGovernoServidorService
    {
        int Create(int idPessoa,int idGoverno,Governoservidor governoservidor);
        void Edit(Governoservidor governoservidor);
        void Delete(int idPessoa, int idGoverno);
        Governoservidor Get(int idPessoa, int idGoverno);
        GovernoServidorDTO? GetDTO(int idPessoa, int idGoverno);
        IEnumerable<Governoservidor> GetAll();
        IEnumerable<GovernoServidorDTO> GetAllDTO();
    }
}
