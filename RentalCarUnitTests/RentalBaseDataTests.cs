using RentalCar.Data.RentalBaseData;
using RentalCar.Models;
using RentalCarUnitTests.ClassData;
using RentalCarUnitTests.SeedData;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RentalCarUnitTests
{
    public class RentalBaseDataTests : TestBase
    {

        [Fact]
        public void GetAll_ShouldReturnThreeElements()
        {
            var rentalBaseRead = new RentalBaseDataRead(_context);

            var rentalBases = rentalBaseRead.GetAll();
            Assert.Equal(_context.RentalBases.Count(), rentalBases.Count());
        }

        [Theory]
        [ClassData(typeof(RentalBaseClassData))]
        public async Task Get_ShouldReturnCorrectRecord(int id, string city, string street, int number)
        {
            var rentalBaseDataRead = new RentalBaseDataRead(_context);
            var rentalBaseGet = await rentalBaseDataRead.GetAsync(id);

            Assert.Equal(id, rentalBaseGet.RentalBaseId);
            Assert.Equal(city, rentalBaseGet.City);
            Assert.Equal(street, rentalBaseGet.Street);
            Assert.Equal(number, rentalBaseGet.Number);
        }

        [Fact]
        public async Task Write_ShouldCreateNewRecord()
        {
            var rentalBase = new RentalBase
            {
                RentalBaseId = 4,
                City = "City4",
                Street = "Street4",
                Number = 4
            };
            var rentalBaseWrite = new RentalBaseDataWrite(_context);
            await rentalBaseWrite.Create(rentalBase);

            Assert.Equal(4, _context.RentalBases.Count());
            Assert.Same(rentalBase, _context.RentalBases.Find(rentalBase.RentalBaseId));
        }

        [Fact]
        public async Task Remove_ShouldRemoveRecord()
        {
            var rentalBaseRemove = new RentalBaseDataDelete(_context);
            var rentalBase = _context.RentalBases.Find(RentalBaseSeed.rentalBasesList[0].RentalBaseId);

            await rentalBaseRemove.Remove(rentalBase.RentalBaseId);

            Assert.NotSame(rentalBase, _context.RentalBases.Find(rentalBase.RentalBaseId));
        }

        [Fact]
        public async Task Remove_ShouldReturnRemovedRecord()
        {
            var rentalBaseRemove = new RentalBaseDataDelete(_context);
            var rentalBase = _context.RentalBases.Find(RentalBaseSeed.rentalBasesList[1].RentalBaseId);

            var removedRecord = await rentalBaseRemove.Remove(rentalBase.RentalBaseId);

            Assert.Same(rentalBase, removedRecord);
        }
    }
}
