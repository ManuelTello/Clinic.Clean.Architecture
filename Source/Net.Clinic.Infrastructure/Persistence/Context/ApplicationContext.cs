using Microsoft.EntityFrameworkCore;
using Net.Clinic.Domain.AggregateRoots.AppointmentAggregate;

namespace Net.Clinic.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; init; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ApplicationContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}