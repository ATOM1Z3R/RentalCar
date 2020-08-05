using RentalCar.Models;
using System.Collections.Generic;

namespace RentalCarUnitTests.SeedData
{
    public static class ReservationSeed
    {
        public static List<Reservation> reservationList { get; } = new List<Reservation>
        {
            new Reservation{ReservationId = 1, VehicleId = 1, UserId = "2", NumberOfDays = 5},
            new Reservation{ReservationId = 2, VehicleId = 2, UserId = "2", NumberOfDays = 10},
        };
    }
}
