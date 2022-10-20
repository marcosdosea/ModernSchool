using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IUnidadeTematicaService
    {
        int Create(Unidadetematica unidadetematica);
        void Edit(Unidadetematica unidadetematica);
        void Delete(int id);
        Unidadetematica Get(int id);
        IEnumerable<Unidadetematica> GetAll();
    }
}
