using AutoMapper;
using Core;
using ModernSchool.Models;
using ModernSchoolWEB.Models;

namespace ModernSchool.Mappers
{
    public class AnoLetivoProfile : Profile
    {
        public AnoLetivoProfile()
        {
            CreateMap<AnoLetivoViewModel, Anoletivo>().ReverseMap();
        }
    }
}
