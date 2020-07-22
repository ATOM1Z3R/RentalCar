using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
