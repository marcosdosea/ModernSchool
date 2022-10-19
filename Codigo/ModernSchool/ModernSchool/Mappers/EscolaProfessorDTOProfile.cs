using AutoMapper;
using Core.DTO;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class EscolaProfessorDTOProfile : Profile
    {
        public EscolaProfessorDTOProfile()
        {
            CreateMap<EscolaProfessorDTOViewModel, EscolaProfessorDTO>().ReverseMap();
        }
    }
}
