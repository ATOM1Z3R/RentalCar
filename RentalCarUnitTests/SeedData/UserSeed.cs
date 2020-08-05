using RentalCar.Models;
using System.Collections.Generic;

namespace RentalCarUnitTests.SeedData
{
    public static class UserSeed
    {
        public static List<User> UsersList { get; } = new List<User>
        {
            new User
            {
                Id = "101",
                UserName = "User1",
                FirstName = "First1",
                LastName = "Last1",
            },
            new User
            {
                Id = "102",
                UserName = "User2",
                FirstName = "First2",
                LastName = "Last2",
            },
            new User
            {
                Id = "103",
                UserName = "User3",
                FirstName = "First3",
                LastName = "Last3",
            },

        };
    }
}
