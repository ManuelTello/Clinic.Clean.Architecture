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
            await this._repository.UpdateAppointmentAssistAsync(request.AppointmentId, cancellationToken);
            await this._repository.SaveChangesAsync(cancellationToken);
            return ApplicationResult<Unit>.Ok(Unit.Value);
        }
    }
}
