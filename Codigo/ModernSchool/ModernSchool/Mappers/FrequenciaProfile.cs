using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class FrequenciaProfile : Profile
    {
        public FrequenciaProfile()
        {
            CreateMap<FrequenciaViewModel, Frequenciaaluno>().ReverseMap();
        }
    }
}
