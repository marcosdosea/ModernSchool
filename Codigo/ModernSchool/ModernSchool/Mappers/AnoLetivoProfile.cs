using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class AnoLetivoProfile : Profile
    {
        public AnoLetivoProfile()
        {
            CreateMap<AnoLetivoViewModel, Anoletivo>().ReverseMap();
        }
    }
}
