using RentalCar.Data.VehicleData.IVehicleData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData
{
    public class VehicleDataWrite : IVehicleDataWrite
    {
        private readonly ApplicationDbContext _context;

        public VehicleDataWrite(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }
    }
}
