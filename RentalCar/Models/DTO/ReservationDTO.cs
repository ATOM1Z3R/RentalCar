using System;
using System.ComponentModel.DataAnnotations;

namespace RentalCar.Models.DTO
{
    public class ReservationDTO
    {
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        
    }
}
