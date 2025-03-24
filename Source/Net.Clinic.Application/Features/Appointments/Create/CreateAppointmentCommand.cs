using MediatR;
using Net.Clinic.Application.ApplicationResult;

namespace Net.Clinic.Application.Features.Appointments.Create
{
    public record CreateAppointmentCommand(string PatientName, int Identification, DateTime DateSelected) : IRequest<ApplicationResult<CreateAppointmentCommandResult>>;
}