using Microsoft.EntityFrameworkCore;
using RentalCar.Data.VehicleData.IVehicleData;
using RentalCar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData
{
    public class VehicleDataRead : IVehicleDataRead
    {
        private readonly ApplicationDbContext _context;

        public VehicleDataRead(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);
        }

        public IEnumerable<Vehicle> GetAll()
        {
            return  _context.Vehicles;
        }
    }
}
