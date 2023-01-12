using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class AlunoTurmaProfile : Profile
    {
        public AlunoTurmaProfile()
        {
            CreateMap<AlunoTurmaViewModel,Alunoturma>().ReverseMap();
        }
    }
}
