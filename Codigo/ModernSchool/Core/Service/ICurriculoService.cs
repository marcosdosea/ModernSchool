using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICurriculoService
    {
        int Create(Curriculo curriculo);
        void Edit(Curriculo curriculo);
        void Delete(int idCurriculo);
        Curriculo Get(int idCurriculo);
        IEnumerable<Curriculo> GetAll();
    }
}
