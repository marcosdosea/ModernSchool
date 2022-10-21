using AutoMapper;
using Core;

using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class EscolaProfile:Profile
    {
        public EscolaProfile()
        {
            CreateMap<EscolaViewModel, Escola>().ReverseMap();
        }
    }
}
