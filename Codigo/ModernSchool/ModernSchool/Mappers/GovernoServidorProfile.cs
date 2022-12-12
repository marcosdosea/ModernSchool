using AutoMapper;
using ModernSchoolWEB.Models;
using Core;

namespace ModernSchoolWEB.Mappers
{
    public class GovernoServidorProfile : Profile
    {
        public GovernoServidorProfile()
        {
            CreateMap<GovernoServidorModel, Governoservidor>().ReverseMap();
        }
    }
}
