using Core;
using AutoMapper;
using ModernSchoolAPI.Models;

namespace ModernSchoolAPI.Mappers
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<AvaliacaoViewModel, Avaliacao>().ReverseMap();
        }
            
    }
}
