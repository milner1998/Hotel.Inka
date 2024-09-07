using FluentValidation;
using HOTELINKA.APPLICATION;
using HOTELINKA.DOMAIN.Interface;
using HOTELINKA.REPOSITORY.Repository;
using HOTELINKA.REPOSITORY.UnitOfWork;

namespace HOTELINKA.API.Configuration
{
    public static class DependencyInjection
    {
        public static void SetInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<IRservaService, ReservaService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
