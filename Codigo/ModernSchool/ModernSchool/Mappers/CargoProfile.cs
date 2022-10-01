using AutoMapper;
using Core;
using ModernSchoolWEB.Models;

namespace ModernSchoolWEB.Mappers
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<CargoViewModel, Cargo>().ReverseMap();
        }
    }
}
