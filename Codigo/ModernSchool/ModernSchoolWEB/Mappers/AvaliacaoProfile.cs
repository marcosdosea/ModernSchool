using ModernSchoolWEB.Models;
using AutoMapper;
using Core;

namespace ModernSchoolWEB.Mappers
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<AvaliacaoViewModel, Avaliacao>().ReverseMap();
        }
    }
}
