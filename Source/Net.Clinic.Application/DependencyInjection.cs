using Microsoft.Extensions.DependencyInjection;

namespace Net.Clinic.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(options => options.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}