using RentalCar.Data.ReservationData.IReservationData;
using RentalCar.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentalCar.Data.ReservationData
{
    public class ReservationReadUserRecords : IReservationReadUserRecords
    {
        private readonly ApplicationDbContext _context;

        public ReservationReadUserRecords(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Reservation> GetUserRes(string id)
        {
            return  _context.Reservations.Where(w => w.UserId == id);
        }
    }
}
