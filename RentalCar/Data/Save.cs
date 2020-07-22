using System.Threading.Tasks;

namespace RentalCar.Data
{
    public class Save : ISave
    {
        private readonly ApplicationDbContext _context;

        public Save(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
