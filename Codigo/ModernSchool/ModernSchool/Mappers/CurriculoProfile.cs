using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class CurriculoProfile : Profile
    {
        public CurriculoProfile()
        {
            CreateMap<CurriculoViewModel, Curriculo>().ReverseMap();
        }
    }
}
