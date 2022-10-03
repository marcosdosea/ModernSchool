using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class FrequenciaalunoProfile : Profile
    {
        public FrequenciaalunoProfile()
        {
            CreateMap<FrequenciaalunoViewModel, Frequenciaaluno>().ReverseMap();
        }
    }
}
