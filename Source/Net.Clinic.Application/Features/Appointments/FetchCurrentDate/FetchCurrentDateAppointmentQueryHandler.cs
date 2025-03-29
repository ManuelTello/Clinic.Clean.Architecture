using MediatR;
using Net.Clinic.Application.ApplicationResult;
using Net.Clinic.Domain.AggregateRoots.AppointmentAggregate;
using Net.Clinic.Domain.IRepositories;

namespace Net.Clinic.Application.Features.Appointments.FetchCurrentDate
{
    public class FetchCurrentDateAppointmentQueryHandler : IRequestHandler<FetchCurrentDateAppointmentQuery, ApplicationResult<ICollection<FetchCurrentDateAppointmentQueryResponse>>>
    {
        private readonly IAppointmentRepository _repository;

        public FetchCurrentDateAppointmentQueryHandler(IAppointmentRepository repository)
        {
            this._repository = repository;
        }

        public async Task<ApplicationResult<ICollection<FetchCurrentDateAppointmentQueryResponse>>> Handle(FetchCurrentDateAppointmentQuery request, CancellationToken cancellationToken)
        {
            var repoOut = await this._repository.FetchAppointmentsFromCurrentDateAsync(request.CurrentDate, cancellationToken);
            var appointments = new List<FetchCurrentDateAppointmentQueryResponse>();

            foreach (Appointment appointment in repoOut)
            {
                appointments.Add(new FetchCurrentDateAppointmentQueryResponse(appointment.Id, appointment.PatientName.Value, appointment.Identification.Value, appointment.DateSelected, appointment.DidAssist));
            }

            return ApplicationResult<ICollection<FetchCurrentDateAppointmentQueryResponse>>.Ok(appointments);
        }
    }
}