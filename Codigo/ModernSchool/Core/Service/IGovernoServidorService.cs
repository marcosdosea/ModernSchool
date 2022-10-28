using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IGovernoServidorService
    {
        int Create(Governoservidor governoservidor);
        void Edit(Governoservidor governoservidor);
        void Delete(int id);
        Governoservidor Get(int id);
        IEnumerable<Governoservidor> GetAll();
    }
}
