using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.RentalBaseData.IRentalBaseData
{
    public interface IRentalBaseDataRemove
    {
        public Task<RentalBase> Remove(int id);
    }
}
