using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData.IUserData
{
    public interface IUserDataRemove
    {
        public Task<User> Remove(string id);
    }
}
