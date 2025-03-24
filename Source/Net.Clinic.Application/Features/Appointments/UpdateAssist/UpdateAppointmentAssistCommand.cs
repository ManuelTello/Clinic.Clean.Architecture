using MediatR;
using Net.Clinic.Application.ApplicationResult;

namespace Net.Clinic.Application.Features.Appointments.UpdateAssist
{
    public record UpdateAppointmentAssistCommand(int AppointmentId) : IRequest<ApplicationResult<Unit>>;
}