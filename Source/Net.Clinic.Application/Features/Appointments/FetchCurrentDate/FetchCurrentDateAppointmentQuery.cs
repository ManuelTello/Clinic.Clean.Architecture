using MediatR;
using Net.Clinic.Application.ApplicationResult;

namespace Net.Clinic.Application.Features.Appointments.FetchCurrentDate
{
    public record FetchCurrentDateAppointmentQuery(DateTime CurrentDate) : IRequest<ApplicationResult<ICollection<FetchCurrentDateAppointmentQueryResponse>>>;
}