using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.ReservationData.IReservationData
{
    public interface IReservationDataWrite
    {
        Task MakeReservationAsync(Reservation reservation);
    }
}
