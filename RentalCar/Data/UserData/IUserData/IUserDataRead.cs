using RentalCar.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData.IUserData
{
    public interface IUserDataRead
    {
        public IEnumerable<User> GetAll();
        public Task<User> GetAsync(string id);
    }
}
