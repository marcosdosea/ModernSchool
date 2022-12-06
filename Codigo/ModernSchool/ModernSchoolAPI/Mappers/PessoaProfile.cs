using AutoMapper;
using Core;
using ModernSchoolAPI.Models;

namespace ModernSchoolAPI.Mappers
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaViewModel, Pessoa>().ReverseMap();
        }
    }
}
