using Microsoft.AspNetCore.Identity;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData.IUserData
{
    public interface IUserDataRegister
    {
        public Task<IdentityResult> UserRegisterAsync(User user, string password);
    }
}
