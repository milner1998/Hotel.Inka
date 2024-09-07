using Microsoft.EntityFrameworkCore;
using HOTELINKA.REPOSITORY.Context;

namespace HOTELINKA.API.Configuration
{
    public static class DBConnection
    {
        public static void SetDBConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelInkaContext>(options => options.UseSqlServer(configuration.GetConnectionString("HotelInkaConnection")));

        }
    }
}
