using AutoMapper;
using Core.DTO;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class GradeHorarioDTOProfile:Profile
    {
        public GradeHorarioDTOProfile()
        {
            CreateMap<GradeHorarioDTOModel, GradeHorarioDTO>().ReverseMap();
        }
    }
}
