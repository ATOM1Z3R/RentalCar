using RentalCar.Data.ReservationData.IReservationData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.ReservationData
{
    public class ReservationDataRemove : IReservationDataRemove
    {
        private readonly ApplicationDbContext _context;

        public ReservationDataRemove(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Reservation> Remove(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }
    }
}
