using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IGradeHorarioService
    {
        int Create(Gradehorario gradehorario);

        void Edit(Gradehorario gradehorario);

        void Delete(int idGradehorario);

        Gradehorario Get(int idGradehorario);

        IEnumerable<Gradehorario>GetAll();
    }
}