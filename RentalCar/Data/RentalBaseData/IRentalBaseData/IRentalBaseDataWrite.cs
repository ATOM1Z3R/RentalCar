using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.RentalBaseData.IRentalBaseData
{
    public interface IRentalBaseDataWrite
    {
        public Task<RentalBase> Create(RentalBase vehicle);
    }
}
