using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentalCar.Data;
using RentalCar.Models;
using RentalCarUnitTests.SeedData;
using System;

namespace RentalCarUnitTests
{
    public class TestBase : IDisposable
    {
        protected readonly ApplicationDbContext _context;

        public TestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);

            _context.Database.EnsureCreated();

            _context.AddRange(RentalBaseSeed.rentalBasesList);
            _context.AddRange(VehicleSeed.VehiclesList);
            _context.AddRange(ReservationSeed.reservationList);
            _context.AddRange(UserSeed.UsersList);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
