using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.VehicleData.IVehicleData
{
    public interface IVehicleSetAvailability
    {
        public void ChangeAvailability(Vehicle vehicle);
    }
}
