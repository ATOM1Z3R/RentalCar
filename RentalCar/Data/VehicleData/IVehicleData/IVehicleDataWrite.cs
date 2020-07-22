using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData.IVehicleData
{
    public interface IVehicleDataWrite
    {
        public Task<Vehicle> Create(Vehicle vehicle);
    }
}
