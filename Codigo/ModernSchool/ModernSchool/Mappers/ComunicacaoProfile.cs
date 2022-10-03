using Core;
using ModernSchoolWEB.Models;
using AutoMapper;

namespace ModernSchoolWEB.Mappers
{
    public class ComunicacaoProfile : Profile
    {
        public ComunicacaoProfile()
        {
            CreateMap<ComunicacaoViewModel, Comunicacao>().ReverseMap();
        }
    }
}
