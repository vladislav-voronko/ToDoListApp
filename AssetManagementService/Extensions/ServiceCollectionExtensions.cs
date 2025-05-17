using Microsoft.EntityFrameworkCore;
using AssetManagementService.Data;

namespace AssetManagementService.Extensions
{
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration){
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(connectionString));
            
            return services;
        }
    }
}