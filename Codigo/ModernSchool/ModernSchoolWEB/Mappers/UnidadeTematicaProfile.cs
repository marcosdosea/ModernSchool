using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class UnidadeTematicaProfile : Profile
    {
        public UnidadeTematicaProfile()
        {
            CreateMap<UnidadeTematicaViewModel, Unidadetematica>().ReverseMap();
        }
    }
}