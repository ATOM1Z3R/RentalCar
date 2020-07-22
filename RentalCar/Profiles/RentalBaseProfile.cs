using AutoMapper;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Profiles
{
    public class RentalBaseProfile : Profile
    {
        public RentalBaseProfile()
        {
            CreateMap<RentalBase, RentalBaseReadDTO>();
            CreateMap<RentalBaseUpsertDTO, RentalBase>();
            CreateMap<RentalBase, RentalBaseUpsertDTO>();
            
        }
    }
}
