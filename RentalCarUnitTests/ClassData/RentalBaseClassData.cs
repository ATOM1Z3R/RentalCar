using RentalCarUnitTests.SeedData;
using System.Collections;
using System.Collections.Generic;

namespace RentalCarUnitTests.ClassData
{
    public class RentalBaseClassData : IEnumerable<object[]>
    {
        static List<object[]> rentalBases = new List<object[]>
        {
            new object[]
            {
                RentalBaseSeed.rentalBasesList[0].RentalBaseId,
                RentalBaseSeed.rentalBasesList[0].City, 
                RentalBaseSeed.rentalBasesList[0].Street,
                RentalBaseSeed.rentalBasesList[0].Number
            },
            new object[]
            {
                RentalBaseSeed.rentalBasesList[1].RentalBaseId,
                RentalBaseSeed.rentalBasesList[1].City,
                RentalBaseSeed.rentalBasesList[1].Street,
                RentalBaseSeed.rentalBasesList[1].Number
            },
            new object[]
            {
                RentalBaseSeed.rentalBasesList[2].RentalBaseId,
                RentalBaseSeed.rentalBasesList[2].City,
                RentalBaseSeed.rentalBasesList[2].Street,
                RentalBaseSeed.rentalBasesList[2].Number
            },
        };
        public IEnumerator<object[]> GetEnumerator() => rentalBases.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
