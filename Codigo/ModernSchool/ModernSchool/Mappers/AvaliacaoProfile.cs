using ModernSchoolWEB.Models;
using AutoMapper;
using Core;
using ModernSchool.Models;

namespace ModernSchool.Mappers
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<AvaliacaoViewModel, Avaliacao>().ReverseMap();
        }
    }
}
