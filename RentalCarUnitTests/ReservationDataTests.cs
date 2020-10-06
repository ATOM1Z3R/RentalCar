using RentalCar.Data.ReservationData;
using RentalCar.Models;
using RentalCarUnitTests.ClassData;
using RentalCarUnitTests.SeedData;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RentalCarUnitTests
{
    public class ReservationDataTests : TestBase
    {
        [Fact]
        public void GetAll_ShouldReturnAllElements()
        {
            var reservationDataRead = new ReservationDataRead(_context);

            var reservations = reservationDataRead.GetAll();

            Assert.Equal(_context.Reservations.Count(), reservations.Count());
        }

        [Theory]
        [ClassData(typeof(ReservationClassData))]
        public async Task Get_ShouldReturnCorrectRecord(int id, int vehicleId, int numberOfDays)
        {
            var reservationDataRead = new ReservationDataRead(_context);

            var reservation = await reservationDataRead.GetAsync(id);

            Assert.Equal(id, reservation.ReservationId);
            Assert.Equal(vehicleId, reservation.VehicleId);
            Assert.Equal(numberOfDays, reservation.NumberOfDays);
        }

        [Fact]
        public void Get_ShouldReturnOneUserRecord()
        {
            var reservationDataRead = new ReservationReadUserRecords(_context);

            var reservation = reservationDataRead.GetUserRes("2");

            Assert.Equal(2, reservation.Count());
        }

        [Fact]
        public async Task Write_ShouldCreateRecord()
        {
            var reservation = new Reservation
            {
                ReservationId = 3,
                VehicleId = 3,
                UserId = "5",
                NumberOfDays = 10,
            };
            var reservationWrite = new ReservationDataWrite(_context);

            await reservationWrite.MakeReservationAsync(reservation);

            Assert.Same(reservation, _context.Reservations.Find(reservation.ReservationId));
        }

        [Fact]
        public async Task Remove_ShouldRemoveRecord()
        {
            var reservationRemove = new ReservationDataRemove(_context);
            var reservation = _context.Reservations.Find(ReservationSeed.reservationList[0].ReservationId);

            await reservationRemove.Remove(reservation.ReservationId);

            Assert.NotSame(reservation, _context.Reservations.Find(reservation.ReservationId));
        }

        [Fact]
        public async Task Remove_ShouldReturnRemovedRecord()
        {
            var reservationRemove = new ReservationDataRemove(_context);
            var reservation = _context.Reservations.Find(ReservationSeed.reservationList[0].ReservationId);

            var removedRecord = await reservationRemove.Remove(reservation.ReservationId);

            Assert.Same(reservation, removedRecord);
        }
    }
}
