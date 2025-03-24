using Net.Clinic.Domain.AggregateRoots.AppointmentAggregate;

namespace Net.Clinic.Domain.IRepositories
{
    public interface IAppointmentRepository : IDisposable
    {
        public Task<Appointment> CreateAppointmentAsync(Appointment appointment, CancellationToken cancellationToken);

        public Task<ICollection<Appointment>> FetchAppointmentFromCurrentDateAsync(DateTime currentDate, CancellationToken cancellationToken);
        
        public Task<Appointment> FetchAppointmentByIdAsync(int appointmentId, CancellationToken cancellationToken);

        public Task UpdateAppointmentAssistAsync(int appointmentId, CancellationToken cancellationToken);

        public void RemoveAppointment(Appointment appointment);

        public Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}