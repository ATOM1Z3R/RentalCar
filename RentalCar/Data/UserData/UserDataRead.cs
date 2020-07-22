using Microsoft.AspNetCore.Identity;
using RentalCar.Data.UserData.IUserData;
using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData
{
    public class UserDataRead : IUserDataRead
    {
        private readonly ApplicationDbContext _context;

        public UserDataRead(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public async Task<User> GetAsync(string id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
