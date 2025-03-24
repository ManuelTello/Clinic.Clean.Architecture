using MediatR;
using Net.Clinic.Application.ApplicationResult;
using Net.Clinic.Domain.AggregateRoots.AppointmentAggregate;
using Net.Clinic.Domain.IRepositories;
using Net.Clinic.Domain.ObjectValues;

namespace Net.Clinic.Application.Features.Appointments.Create
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, ApplicationResult<CreateAppointmentCommandResult>>
    {
        private readonly IAppointmentRepository _repository;

        public CreateAppointmentCommandHandler(IAppointmentRepository repository)
        {
            this._repository = repository;
        }

        public async Task<ApplicationResult<CreateAppointmentCommandResult>> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            IDictionary<string, ICollection<string>> errors = new Dictionary<string, ICollection<string>>();
            var patientName = PatientName.Create(request.PatientName);
            var identification = Identification.Create(request.Identification);

            if (!patientName.IsSuccess)
                errors.Add("PatientName", patientName.Errors);

            if (!identification.IsSuccess)
                errors.Add("Identification", identification.Errors);

            if (errors.Count == 0)
            {
                var appointment = new Appointment(0, request.DateSelected, false, patientName.Data!, identification.Data!);
                var repoOut = await this._repository.CreateAppointmentAsync(appointment, cancellationToken);
                await this._repository.SaveChangesAsync(cancellationToken);
                CreateAppointmentCommandResult result = new CreateAppointmentCommandResult(repoOut.Id, repoOut.PatientName.Value, repoOut.Identification.Value, repoOut.DateSelected, repoOut.DidAssist);
                return ApplicationResult<CreateAppointmentCommandResult>.Ok(result);
            }
            else
            {
                return ApplicationResult<CreateAppointmentCommandResult>.Fail(errors);
            }
        }
    }
}