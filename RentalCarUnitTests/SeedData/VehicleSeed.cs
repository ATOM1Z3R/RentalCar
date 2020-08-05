using RentalCar.Models;
using System.Collections.Generic;

namespace RentalCarUnitTests.SeedData
{
    public static class VehicleSeed
    {
        public static List<Vehicle> VehiclesList = new List<Vehicle>
        {
            new Vehicle{VehicleId = 1, Manufacturer = "Vehicle1", Model = "Model1", Color = "Color1"},
            new Vehicle{VehicleId = 2, Manufacturer = "Vehicle2", Model = "Model2", Color = "Color2"},
            new Vehicle{VehicleId = 3, Manufacturer = "Vehicle3", Model = "Model3", Color = "Color3"},
        };
    }
}
