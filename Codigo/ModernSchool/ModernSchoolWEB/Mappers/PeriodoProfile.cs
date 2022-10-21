using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class PeriodoProfile : Profile
    {
        public PeriodoProfile()
        {
            CreateMap<PeriodoViewModel, Periodo>().ReverseMap();
        }
    }
}
