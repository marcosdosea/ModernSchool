using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchool.Mappers
{
    public class GradeHorarioProfile : Profile
    {
        public GradeHorarioProfile(){
            CreateMap<GradehorarioViewModel,Gradehorario>().ReverseMap();
        }
    }
}