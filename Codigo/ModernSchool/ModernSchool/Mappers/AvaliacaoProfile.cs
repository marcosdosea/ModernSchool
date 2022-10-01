using ModernSchoolWEB.Models;
using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

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
