using RentalCar.Data.UserData;
using RentalCarUnitTests.ClassData;
using RentalCarUnitTests.SeedData;
using System.Linq;
using Xunit;

namespace RentalCarUnitTests
{
    public class UserDataTests : TestBase
    {
        [Fact]
        public void Get_ShouldReturnAllRecords()
        {
            var userRead = new UserDataRead(_context);
            var users = userRead.GetAll();

            Assert.Equal(_context.Users.Count(), users.Count());
        }

        [Theory]
        [ClassData(typeof(UserClassData))]
        public async void Get_ShouldReturnCorrectRecord(string id, string username, string firstname, string lastname)
        {
            var userRead = new UserDataRead(_context);
            var userGet = await userRead.GetAsync(id);

            Assert.Equal(id, userGet.Id);
            Assert.Equal(username, userGet.UserName);
            Assert.Equal(firstname, userGet.FirstName);
            Assert.Equal(lastname, userGet.LastName);
        }

        [Fact]
        public async void Remove_ShouldRemoveRecord()
        {
            var userRemove = new UserDataRemove(_context);
            var user = _context.Users.Find(UserSeed.UsersList[0].Id);

            await userRemove.Remove(user.Id);

            Assert.NotSame(user, _context.Users.Find(user.Id));
        }

        [Fact]
        public async void Remove_ShouldReturnRemovedRecord()
        {
            var userRemove = new UserDataRemove(_context);
            var user = _context.Users.Find(UserSeed.UsersList[1].Id);

            var removedRecord = await userRemove.Remove(user.Id);

            Assert.Same(user, removedRecord);
        }
    }
}
