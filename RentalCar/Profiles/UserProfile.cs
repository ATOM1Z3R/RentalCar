using AutoMapper;
using RentalCar.Models;
using RentalCar.Models.DTO;

namespace RentalCar.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();
        }
    }
}
