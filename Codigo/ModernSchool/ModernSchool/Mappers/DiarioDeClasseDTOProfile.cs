using AutoMapper;
using Core;
using Core.DTO;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class DiarioDeClasseDTOProfile : Profile
    {
        public DiarioDeClasseDTOProfile()
        {
            CreateMap<DiarioDeClasseDTOViewModel, DiarioDeClasseDTO>().ReverseMap();

        }
        
    }
}
