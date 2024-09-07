using HOTELINKA.EXTENSIONS.Mapper;

namespace HOTELINKA.API.Configuration
{
    public static class MapperConfig
    {
        public static void SetAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapperExtensions));
        }
    }
}
