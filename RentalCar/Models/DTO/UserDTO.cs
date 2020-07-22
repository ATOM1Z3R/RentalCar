using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.DTO
{
    public class UserDTO
    {
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
