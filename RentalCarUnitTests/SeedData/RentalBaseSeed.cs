using RentalCar.Models;
using System.Collections.Generic;

namespace RentalCarUnitTests.SeedData
{
    public static class RentalBaseSeed
    {
        public static List<RentalBase> rentalBasesList { get; } = new List<RentalBase>
        {
            new RentalBase{RentalBaseId = 1, City = "City1", Street="Street1", Number=1},
            new RentalBase{RentalBaseId = 2, City = "City2", Street="Street2", Number=2},
            new RentalBase{RentalBaseId = 3, City = "City3", Street="Street3", Number=3},
        };
    }
}
