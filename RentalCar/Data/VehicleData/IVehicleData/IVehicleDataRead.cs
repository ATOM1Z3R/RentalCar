using RentalCar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData.IVehicleData
{
    public interface IVehicleDataRead
    {
        public IEnumerable<Vehicle> GetAll();
        public Task<Vehicle> GetAsync(int id);
    }
}
