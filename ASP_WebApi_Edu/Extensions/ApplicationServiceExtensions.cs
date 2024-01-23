using ASP_WebApi_Edu.Data;
using ASP_WebApi_Edu.Interfaces;
using ASP_WebApi_Edu.Services;
using Microsoft.EntityFrameworkCore;

namespace ASP_WebApi_Edu.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
             {
                 opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
             });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
