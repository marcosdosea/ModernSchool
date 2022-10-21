using Core;
using AutoMapper;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class TurmaProfile : Profile
    {
        public TurmaProfile()
        {
            CreateMap<TurmaViewModel, Turma>().ReverseMap();
        }
    }
}
