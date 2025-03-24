using MediatR;
using Net.Clinic.Application.ApplicationResult;

namespace Net.Clinic.Application.Features.Appointments.Delete
{
    public record DeleteAppointmentCommand(int AppointmentId):IRequest<ApplicationResult<Unit>>;
}