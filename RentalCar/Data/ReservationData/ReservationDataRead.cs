using Microsoft.EntityFrameworkCore;
using RentalCar.Data.ReservationData.IReservationData;
using RentalCar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCar.Data.ReservationData
{
    public class ReservationDataRead : IReservationDataRead
    {
        private readonly ApplicationDbContext _context;

        public ReservationDataRead(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> GetAsync(int id)
        {
            return await _context.Reservations.Include(x => x.Vehicle).FirstOrDefaultAsync(x => x.ReservationId == id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.Include(x => x.Vehicle);
        }
    }
}
