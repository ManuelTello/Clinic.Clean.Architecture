using MediatR;
using Net.Clinic.Application.ApplicationResult;
using Net.Clinic.Domain.IRepositories;

namespace Net.Clinic.Application.Features.Appointments.Delete
{
    public class DeleteAppointmentCommandHandler:IRequestHandler<DeleteAppointmentCommand, ApplicationResult<Unit>>
    {
        private readonly IAppointmentRepository _repository;

        public DeleteAppointmentCommandHandler(IAppointmentRepository repository)
        {
            this._repository = repository;
        }
        
        public async Task<ApplicationResult<Unit>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await this._repository.FetchAppointmentByIdAsync(request.AppointmentId, cancellationToken);
            this._repository.RemoveAppointment(appointment);
            await this._repository.SaveChangesAsync(cancellationToken);
            return ApplicationResult<Unit>.Ok(Unit.Value);
        }
    }
}