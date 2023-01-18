using AutoMapper;
using Core.DTO;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class FrequenciaAlunoDTOProfile : Profile
    {
        public FrequenciaAlunoDTOProfile()
        {
            CreateMap<FrequenciaAlunoDTOViewModel, FrequenciaAlunoDTO>().ReverseMap();
        }
    }
}
