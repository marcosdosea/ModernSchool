using AutoMapper;
using Core;
using ModernSchool.Models;

namespace ModernSchool.Mappers
{
    public class CurriculoProfile : Profile
    {
        public CurriculoProfile()
        {
            CreateMap<CurriculoViewModel, Periodo>().ReverseMap();
        }
    }
}
