using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class GovernoProfile : Profile
    {
        public GovernoProfile()
            {
                CreateMap<GovernoViewModel, Governo>().ReverseMap();
            }
        
    }
}
