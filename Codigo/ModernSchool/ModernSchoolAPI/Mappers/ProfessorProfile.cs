using AutoMapper;
using ModernSchoolAPI.Models;
using Core.DTO;


namespace ModernSchoolAPI.Mappers
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<ProfessorViewModel, PessoaProfessorDTO>().ReverseMap();
        }
    }
}
