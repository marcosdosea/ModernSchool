using AutoMapper;
using Core;
using ModernSchool.Models;

namespace ModernSchool.Mappers
{
    public class ComponenteProfile : Profile
    {
        public ComponenteProfile()
        {
            CreateMap<ComponenteViewModel, Componente>().ReverseMap();
        }
    }
}
