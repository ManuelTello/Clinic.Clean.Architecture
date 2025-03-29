using MediatR;
using Net.Clinic.Application.ApplicationResult;
using Net.Clinic.Domain.IRepositories;

namespace Net.Clinic.Application.Features.Appointments.UpdateAssist
{
    public class UpdateAppointmentAssistCommandHandler : IRequestHandler<UpdateAppointmentAssistCommand, ApplicationResult<Unit>>
    {
        private readonly IAppointmentRepository _repository;

        public UpdateAppointmentAssistCommandHandler(IAppointmentRepository repository)
        {
            this._repository = repository;
        }

        public async Task<ApplicationResult<Unit>> Handle(UpdateAppointmentAssistCommand request, CancellationToken cancellationToken)
        {
            var appointment = await this._repository.FetchAppointmentByIdAsync(request.AppointmentId, cancellationToken);
            var errors = new Dictionary<string, ICollection<string>>();

            if (appointment == null)
            {
                errors.Add("AppointmentUpdateAssist", [$"Appointment {request.AppointmentId} not found"]);
                return ApplicationResult<Unit>.Fail(errors);
            }
            else
            {
                await this._repository.UpdateAppointmentAssistAsync(request.AppointmentId, cancellationToken);
                await this._repository.SaveChangesAsync(cancellationToken);
                return ApplicationResult<Unit>.Ok(Unit.Value);
            }
        }
    }
}
