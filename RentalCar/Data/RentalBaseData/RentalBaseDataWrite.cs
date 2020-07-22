using RentalCar.Data.RentalBaseData.IRentalBaseData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.RentalBaseData
{
    public class RentalBaseDataWrite : IRentalBaseDataWrite
    {
        private readonly ApplicationDbContext _context;

        public RentalBaseDataWrite(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RentalBase> Create(RentalBase rentalBase)
        {
            _context.RentalBases.Add(rentalBase);
            await _context.SaveChangesAsync();
            return rentalBase;
        }
    }
}
