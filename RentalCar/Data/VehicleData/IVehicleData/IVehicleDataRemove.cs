using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData.IVehicleData
{
    public interface IVehicleDataRemove
    {
        public Task<Vehicle> Remove(int id);
    }
}
