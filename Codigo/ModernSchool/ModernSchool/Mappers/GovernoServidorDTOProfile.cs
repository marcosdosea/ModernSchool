using AutoMapper;
using Core.DTO;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class GovernoServidorDTOProfile : Profile
    {
        public GovernoServidorDTOProfile()
        {
            CreateMap<GovernoServidorDTOModel, GovernoServidorDTO>().ReverseMap();
        }
    }
}
