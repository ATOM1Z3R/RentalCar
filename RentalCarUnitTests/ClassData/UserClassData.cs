using RentalCarUnitTests.SeedData;
using System.Collections;
using System.Collections.Generic;

namespace RentalCarUnitTests.ClassData
{
    public class UserClassData : IEnumerable<object[]>
    {
        static List<object[]> users = new List<object[]>
        {
            new object[]
            {
                UserSeed.UsersList[0].Id,
                UserSeed.UsersList[0].UserName,
                UserSeed.UsersList[0].FirstName,
                UserSeed.UsersList[0].LastName
            },
            new object[]
            {
                UserSeed.UsersList[1].Id,
                UserSeed.UsersList[1].UserName,
                UserSeed.UsersList[1].FirstName,
                UserSeed.UsersList[1].LastName
            },
            new object[]
            {
                UserSeed.UsersList[2].Id,
                UserSeed.UsersList[2].UserName,
                UserSeed.UsersList[2].FirstName,
                UserSeed.UsersList[2].LastName
            },
        };
        public IEnumerator<object[]> GetEnumerator() => users.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
