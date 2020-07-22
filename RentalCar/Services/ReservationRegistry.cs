using Microsoft.Extensions.DependencyInjection;
using RentalCar.Data.ReservationData;
using RentalCar.Data.ReservationData.IReservationData;

namespace RentalCar.Services
{
    public static class ReservationRegistry
    {
        public static IServiceCollection AddReservationServices(this IServiceCollection services)
        {
            services.AddScoped<IReservationDataRead, ReservationDataRead>();
            services.AddScoped<IReservationDataWrite, ReservationDataWrite>();
            services.AddScoped<IReservationDataRemove, ReservationDataRemove>();
            services.AddScoped<IReservationReadUserRecords, ReservationReadUserRecords>();
            return services;
        }
    }
}
