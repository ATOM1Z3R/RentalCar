using AutoMapper;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleReadDTO>();
            CreateMap<VehicleUpsertDTO, Vehicle>();
            CreateMap<Vehicle, VehicleUpsertDTO>();
        }
    }
}
