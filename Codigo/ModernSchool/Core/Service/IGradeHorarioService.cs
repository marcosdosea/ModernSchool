using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Datatables;
using Core.DTO;

namespace Core.Service
{
    public interface IGradeHorarioService
    {
        HttpStatusCode Create(Gradehorario gradehorario);

        HttpStatusCode Edit(Gradehorario gradehorario);

        HttpStatusCode Delete(int idGradehorario);

        Gradehorario Get(int idGradehorario);

        IEnumerable<Gradehorario> GetAll();
        IEnumerable<GradeHorarioDTO> GetAllGradeHorario(int idTurma);
        GradeHorarioDTO? GetAGradeHorario(int id);

        IEnumerable<GradeHorarioProfessor> GetAllGradeProfessor(int idProfessor);
        DatatableResponse<GradeHorarioDTO> GetDataPage(DatatableRequest request, int idTurma);
    }
}