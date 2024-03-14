using Core.DTO;
using System.ComponentModel.DataAnnotations;

namespace ModernSchoolWEB.Models
{
    public class GradeHorarioDTOModel
    {
        public List<GradeHorarioDTO> GradeHorarioDTOs { get; set; }
        public int IdTurma { get; set; }
    }

}
