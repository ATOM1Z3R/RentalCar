using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCar.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RentDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ExpectingRetriveDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ActualRetriveDate { get; set; }

        [Required]
        public int NumberOfDays { get; set; }

        [Required]
        public int VehicleId { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual User User { get; set; }
    }
}
