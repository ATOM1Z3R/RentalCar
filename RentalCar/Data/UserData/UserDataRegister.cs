using Microsoft.AspNetCore.Identity;
using RentalCar.Data.UserData.IUserData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData
{
    public class UserDataRegister : IUserDataRegister
    {
        private readonly UserManager<User> _userManager;

        public UserDataRegister(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> UserRegisterAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
