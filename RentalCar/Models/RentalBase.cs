using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models
{
    public class RentalBase
    {
        public RentalBase()
        {
            Vehicles = new HashSet<Vehicle>();
        }
        [Key]
        public int RentalBaseId { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
