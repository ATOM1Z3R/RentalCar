using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.DTO
{
    public class RentalBaseDTO
    {
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
