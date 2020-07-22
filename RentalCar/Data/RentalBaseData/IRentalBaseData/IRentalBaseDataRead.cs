using RentalCar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCar.Data.RentalBaseData.IRentalBaseData
{
    public interface IRentalBaseDataRead
    {
        public IEnumerable<RentalBase> GetAll();
        public Task<RentalBase> GetAsync(int id);
    }
}
