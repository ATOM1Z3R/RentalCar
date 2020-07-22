using Microsoft.Extensions.DependencyInjection;
using RentalCar.Data.UserData;
using RentalCar.Data.UserData.IUserData;

namespace RentalCar.Services
{
    public static class UserRegistry
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<IUserDataLogin, UserDataLogin>();
            services.AddScoped<IUserDataRegister, UserDataRegister>();
            services.AddScoped<IUserDataRead, UserDataRead>();
            services.AddScoped<IUserDataRemove, UserDataRemove>();
            return services;
        }
    }
}
