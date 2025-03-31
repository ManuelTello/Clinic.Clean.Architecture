using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Clinic.Domain.IRepositories;
using Net.Clinic.Infrastructure.Persistence.Context;
using Net.Clinic.Infrastructure.Persistence.Repositories;

namespace Net.Clinic.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddPersistence(services, configuration);
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresConnection") ?? throw new ArgumentException();

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
            services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}