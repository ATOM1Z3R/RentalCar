using RentalCar.Models;
using System.Collections.Generic;

namespace RentalCar.Data.ReservationData.IReservationData
{
    public interface IReservationReadUserRecords
    {
        public IEnumerable<Reservation> GetUserRes(string id);
    }
}
