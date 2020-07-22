using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.DTO
{
    public class UserUpdateDTO : UserDTO
    {
        public string Password { get; set; }
    }
}
