using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data;

namespace ToDoListApp.Extensions
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