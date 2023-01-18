using AutoMapper;
using Core.DTO;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class AlunoAvaliacaoDTOProfile : Profile
    {
        public AlunoAvaliacaoDTOProfile()
        {
            CreateMap<AlunoAvaliacaoDTOModel, AlunoAvaliacaoDTO>().ReverseMap();
        }
    }
}
