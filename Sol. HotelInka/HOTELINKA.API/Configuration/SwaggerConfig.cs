using Microsoft.OpenApi.Models;

namespace HOTELINKA.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void SetSwaggerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API HOTEL INKA", Version = "v1", Description = "APIS utilizados en el sistema HOTEL INKA" });
                c.EnableAnnotations();
             
            });
        }
    }
}
