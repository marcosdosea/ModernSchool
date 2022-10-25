using Core;
using AutoMapper;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class ObjetoDeConhecimentoProfile : Profile
    {
        public ObjetoDeConhecimentoProfile()
        {
            CreateMap<ObjetoDeConhecimentoViewModel, Objetodeconhecimento>().ReverseMap();
        }
    }
}
