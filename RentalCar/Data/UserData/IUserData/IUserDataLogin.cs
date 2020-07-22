using Microsoft.IdentityModel.Tokens;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData.IUserData
{
    public interface IUserDataLogin
    {
        public Task<SecurityToken> LoginAsync(UserLogin userLogin);
    }
}
