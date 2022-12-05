using Core;
using AutoMapper;
using ModernSchoolAPI.Models;

namespace ModernSchoolAPI.Mappers
{
    public class AnoLetivoProfile : Profile
    {
        public AnoLetivoProfile()
        {
            CreateMap<AnoLetivoViewModel, Anoletivo>().ReverseMap();
        }
    }
}
