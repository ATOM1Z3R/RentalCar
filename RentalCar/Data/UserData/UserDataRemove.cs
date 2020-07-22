using RentalCar.Data.UserData.IUserData;
using RentalCar.Models;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData
{
    public class UserDataRemove : IUserDataRemove
    {
        private readonly ApplicationDbContext _context;

        public UserDataRemove(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Remove(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
