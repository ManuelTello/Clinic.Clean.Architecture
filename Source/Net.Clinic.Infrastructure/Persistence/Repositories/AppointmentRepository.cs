using Microsoft.EntityFrameworkCore;
using Net.Clinic.Domain.AggregateRoots.AppointmentAggregate;
using Net.Clinic.Domain.IRepositories;
using Net.Clinic.Infrastructure.Persistence.Context;

namespace Net.Clinic.Infrastructure.Persistence.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationContext _context;

        private bool disposed;

        public AppointmentRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment, CancellationToken cancellationToken)
        {
            var result = await this._context.Appointments.AddAsync(appointment, cancellationToken);
            return result.Entity;
        }

        public async Task<ICollection<Appointment>> FetchAppointmentsFromCurrentDateAsync(DateTime currentDate, CancellationToken cancellationToken)
        {
            ICollection<Appointment> appointments = await this._context.Appointments
            .Where(a => a.DateSelected.Day == currentDate.Day &&
                a.DateSelected.Month == currentDate.Month &&
                a.DateSelected.Year == currentDate.Year).ToListAsync(cancellationToken);

            return appointments;
        }

        public async Task<Appointment?> FetchAppointmentByIdAsync(int appointmentId, CancellationToken cancellationToken)
        {
            Appointment? appointment = await this._context.Appointments.SingleOrDefaultAsync(e => e.Id == appointmentId, cancellationToken);
            return appointment;
        }

        public void RemoveAppointment(Appointment appointment)
        {
            this._context.Appointments.Remove(appointment);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAppointmentAssistAsync(int appointmentId, CancellationToken cancellationToken)
        {
            await this._context.Appointments.ExecuteUpdateAsync(e => e.SetProperty(a => a.DidAssist, true), cancellationToken);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this._context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}