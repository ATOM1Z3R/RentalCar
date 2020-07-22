using RentalCar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCar.Data.ReservationData.IReservationData
{
    public interface IReservationDataRead
    {
        public IEnumerable<Reservation> GetAll();
        public Task<Reservation> GetAsync(int id);
    }
}
