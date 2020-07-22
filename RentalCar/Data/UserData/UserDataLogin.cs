using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using RentalCar.Data.UserData.IUserData;
using RentalCar.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Data.UserData
{
    public class UserDataLogin : IUserDataLogin
    {
        private readonly UserManager<User> _userManager;
        private readonly Jwt _jwt;

        public UserDataLogin(UserManager<User> userManager, Jwt jwt)
        {
            _userManager = userManager;
            _jwt = jwt;
        }
        public async Task<SecurityToken> LoginAsync(UserLogin userLogin)
        {
            var user = await _userManager.FindByNameAsync(userLogin.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                var role = await _userManager.GetRolesAsync(user);
                var identityOptions = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim(identityOptions.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddHours(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)),
                                                                                         SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                return securityToken;
            }
            else
            {
                return null;
            }
        }
    }
}
