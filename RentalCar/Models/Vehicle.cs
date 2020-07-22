using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    public class Vehicle 
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }
        [Required]
        [StringLength(100)]
        public string Model { get; set; }
        [Required]
        [StringLength(20)]
        public string Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        [Required]
        public int Power { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        [Required]
        public int ManufactureYear { get; set; }
        public bool Availability { get; set; } = true;
        [Required]
        public int PriceMultipler { get; set; }
        [Required]
        public int RentalBaseId { get; set; }

        public virtual RentalBase RentalBase { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
