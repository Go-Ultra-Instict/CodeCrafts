using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DemoDbContext>(options => options.UseSqlServer(
    connectionString));

            services.AddScoped<IDemoDbContext>(provider => provider.GetRequiredService<DemoDbContext>());

            //Todo  Learn the differnce between these two 
            //services.AddScoped<IDemoDbContext, DemoDbContext>();
            
            return services;
        }
    }
}