using System;

namespace RentalCar.Models.DTO
{
    public class ReservationReadDTO : ReservationDTO
    {
        public DateTime? ExpectingRetriveDate { get; set; }
        public DateTime? ActualRetriveDate { get; set; }
        public int ReservationId { get; set; }
        public int VehicleId { get; set; }
        public VehicleReadDTO Vehicle { get; set; }
    }
}
