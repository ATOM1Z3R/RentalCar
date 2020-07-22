using RentalCar.Data.VehicleData.IVehicleData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData
{
    public class VehicleSetAvailability : IVehicleSetAvailability
    {
        private readonly ApplicationDbContext _context;

        public VehicleSetAvailability(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ChangeAvailability(Vehicle vehicle)
        {
            if (vehicle.Availability == true)
                vehicle.Availability = false;
            else
                vehicle.Availability = true;
        }
    }
}
