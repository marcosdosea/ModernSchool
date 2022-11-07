using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class DiarioDeClasseProfile : Profile
    {
        public DiarioDeClasseProfile()
        {
            CreateMap<DiarioDeClasseViewModel, Diariodeclasse>().ReverseMap();

        }
    }
}
