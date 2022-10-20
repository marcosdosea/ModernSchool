using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class FrequenciaAlunoProfile : Profile
    {
        public FrequenciaAlunoProfile()
        {
            CreateMap<FrequenciaAlunoViewModel, Frequenciaaluno>().ReverseMap();
        }
    }
}
