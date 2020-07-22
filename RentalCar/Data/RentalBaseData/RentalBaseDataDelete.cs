using RentalCar.Data.RentalBaseData.IRentalBaseData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.RentalBaseData
{
    public class RentalBaseDataDelete : IRentalBaseDataRemove
    {
        private readonly ApplicationDbContext _context;

        public RentalBaseDataDelete(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RentalBase> Remove(int id)
        {
            var rentalBase = await _context.RentalBases.FindAsync(id);
            if (rentalBase == null)
            {
                return null;
            }
            _context.RentalBases.Remove(rentalBase);
            await _context.SaveChangesAsync();
            return rentalBase;
        }
    }
}
