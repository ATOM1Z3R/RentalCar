using RentalCarUnitTests.SeedData;
using System.Collections;
using System.Collections.Generic;

namespace RentalCarUnitTests.ClassData
{
    public class VehicleClassData : IEnumerable<object[]>
    {
        static List<object[]> vehicles = new List<object[]>
        {
            new object[]
            {
                VehicleSeed.VehiclesList[0].VehicleId,
                VehicleSeed.VehiclesList[0].Manufacturer,
                VehicleSeed.VehiclesList[0].Model,
                VehicleSeed.VehiclesList[0].Color,
            },
            new object[]
            {
                VehicleSeed.VehiclesList[1].VehicleId,
                VehicleSeed.VehiclesList[1].Manufacturer,
                VehicleSeed.VehiclesList[1].Model,
                VehicleSeed.VehiclesList[1].Color,
            },
            new object[]
            {
                VehicleSeed.VehiclesList[2].VehicleId,
                VehicleSeed.VehiclesList[2].Manufacturer,
                VehicleSeed.VehiclesList[2].Model,
                VehicleSeed.VehiclesList[2].Color,
            },
        };
        public IEnumerator<object[]> GetEnumerator() => vehicles.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

