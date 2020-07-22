using AutoMapper;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, ReservationReadDTO>();
            CreateMap<ReservationUpsertDTO, Reservation>();
            CreateMap<Reservation, ReservationUpsertDTO>();
        }
    }
}
