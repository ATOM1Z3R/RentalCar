using RentalCar.Data.VehicleData.IVehicleData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData
{
    public class VehicleDataRemove : IVehicleDataRemove
    {
        private readonly ApplicationDbContext _context;

        public VehicleDataRemove(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Vehicle> Remove(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }
    }
}
