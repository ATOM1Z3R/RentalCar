using Microsoft.Extensions.DependencyInjection;
using RentalCar.Data.RentalBaseData;
using RentalCar.Data.RentalBaseData.IRentalBaseData;

namespace RentalCar.Services
{
    public static class RentalBaseRegistry
    {
        public static IServiceCollection AddRentalBaseServices(this IServiceCollection services)
        {
            services.AddScoped<IRentalBaseDataRead, RentalBaseDataRead>();
            services.AddScoped<IRentalBaseDataWrite, RentalBaseDataWrite>();
            services.AddScoped<IRentalBaseDataRemove, RentalBaseDataDelete>();
            return services;
        }
    }
}
