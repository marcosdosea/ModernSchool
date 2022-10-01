using AutoMapper;
using Core;
using ModernSchool.Models;

namespace ModernSchool.Mappers
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<CargoViewModel, Cargo>().ReverseMap();
        }
    }
}
