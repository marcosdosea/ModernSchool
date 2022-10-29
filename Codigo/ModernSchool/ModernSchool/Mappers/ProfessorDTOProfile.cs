using AutoMapper;
using Core.DTO;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class ProfessorDTOProfile : Profile
    {
       public ProfessorDTOProfile()
        {
            CreateMap<ProfessorDTOModel, PessoaProfessorDTO>().ReverseMap();
        }
    }
}
