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
        int Create(Governoservidor governoservidor);
        void Edit(Governoservidor governoservidor);
        void Delete(int id);
        Governoservidor Get(int id);
        GovernoServidorDTO? GetDTO(int id);
        IEnumerable<Governoservidor> GetAll();
        IEnumerable<GovernoServidorDTO> GetAllDTO();
    }
}
