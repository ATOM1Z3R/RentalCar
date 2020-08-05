using RentalCarUnitTests.SeedData;
using System.Collections;
using System.Collections.Generic;

namespace RentalCarUnitTests.ClassData
{
    class ReservationClassData : IEnumerable<object[]>
    {
        static List<object[]> reservations = new List<object[]>
        {
            new object[]
            {
                ReservationSeed.reservationList[0].ReservationId,
                ReservationSeed.reservationList[0].VehicleId,
                ReservationSeed.reservationList[0].NumberOfDays,
            },
            new object[]
            {
                ReservationSeed.reservationList[1].ReservationId,
                ReservationSeed.reservationList[1].VehicleId,
                ReservationSeed.reservationList[1].NumberOfDays,
            },
        };
        public IEnumerator<object[]> GetEnumerator() => reservations.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
