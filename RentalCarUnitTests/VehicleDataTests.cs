using RentalCar.Data.VehicleData;
using RentalCar.Models;
using RentalCarUnitTests.ClassData;
using RentalCarUnitTests.SeedData;
using System.Linq;
using Xunit;

namespace RentalCarUnitTests
{
    public class VehicleDataTests : TestBase
    {
        [Fact]
        public void GetAll_ShouldReturnAllElements()
        {
            var vehicleDataRead = new VehicleDataRead(_context);

            var vehicles = vehicleDataRead.GetAll();

            Assert.Equal(_context.Vehicles.Count(),vehicles.Count());
        }

        [Theory]
        [ClassData(typeof(VehicleClassData))]
        public async void Get_ShouldReturnCorrectRecord(int id, string manufacturer, string model, string color)
        {
            var vehicleDataRead = new VehicleDataRead(_context);

            var vehicle = await vehicleDataRead.GetAsync(id);

            Assert.Equal(id, vehicle.VehicleId);
            Assert.Equal(manufacturer, vehicle.Manufacturer);
            Assert.Equal(model, vehicle.Model);
            Assert.Equal(color, vehicle.Color);
        }

        [Fact]
        public async void Write_ShouldCreateNewRecord()
        {
            var vehicle = new Vehicle
            {
                VehicleId = 4,
                Manufacturer = "Manufacturer4",
                Model = "Model4",
                Color = "Color4"
            };
            var vehicleWrite = new VehicleDataWrite(_context);
            await vehicleWrite.Create(vehicle);

            Assert.Equal(4, _context.Vehicles.Count());
            Assert.Same(vehicle, _context.Vehicles.Find(vehicle.VehicleId));
        }

        [Fact]
        public async void Remove_ShouldRemoveRecord()
        {
            var vehicleRemove = new VehicleDataRemove(_context);
            var vehicle = _context.Vehicles.Find(VehicleSeed.VehiclesList[1].VehicleId);

            await vehicleRemove.Remove(vehicle.VehicleId);

            Assert.NotSame(vehicle, _context.Vehicles.Find(vehicle.VehicleId));
        }

        [Fact]
        public async void Remove_ShouldReturnRemovedRecord()
        {
            var vehicleRemove = new VehicleDataRemove(_context);
            var vehicle = _context.Vehicles.Find(VehicleSeed.VehiclesList[0].VehicleId);

            var removedRecord = await vehicleRemove.Remove(vehicle.VehicleId);

            Assert.Same(vehicle, removedRecord);
        }
    }
}
