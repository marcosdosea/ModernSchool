using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class ComponenteProfile : Profile
    {
        public ComponenteProfile()
        {
            CreateMap<ComponenteViewModel, Componente>().ReverseMap();
        }
    }
}
