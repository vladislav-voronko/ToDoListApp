using Microsoft.EntityFrameworkCore;
using AssetManagementService.Data;
using AssetManagementService.Interfaces;

namespace AssetManagementService.Extensions
{
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration){
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(connectionString));

            services.AddScoped<IAssetService, AssetService>();
            
            return services;
        }
    }
}