using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.ReservationData.IReservationData
{
    public interface IReservationDataRemove
    {
        public Task<Reservation> Remove(int id);
    }
}
