using RentalCar.Data.ReservationData.IReservationData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.ReservationData
{
    public class ReservationDataWrite : IReservationDataWrite
    {
        private readonly ApplicationDbContext _context;

        public ReservationDataWrite(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task MakeReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
