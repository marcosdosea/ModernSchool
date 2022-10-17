using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IUnidadeTematica
    {
        int Create(Unidadetematica unidadetematica);
        void Edit(Unidadetematica unidadetematica);
        void Delete(int id);
        Turma Get(int id);
        IEnumerable<Unidadetematica> GetAll();
    }
}
