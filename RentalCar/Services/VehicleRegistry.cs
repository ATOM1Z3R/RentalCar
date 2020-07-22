using Microsoft.Extensions.DependencyInjection;
using RentalCar.Data.VehicleData;
using RentalCar.Data.VehicleData.IVehicleData;

namespace RentalCar.Services
{
    public static class VehicleRegistry
    {
        public static IServiceCollection AddVehicleServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicleDataRead, VehicleDataRead>();
            services.AddScoped<IVehicleDataWrite, VehicleDataWrite>();
            services.AddScoped<IVehicleDataRemove, VehicleDataRemove>();
            services.AddScoped<IVehicleSetAvailability, VehicleSetAvailability>();
            return services;
        }
    }
}
