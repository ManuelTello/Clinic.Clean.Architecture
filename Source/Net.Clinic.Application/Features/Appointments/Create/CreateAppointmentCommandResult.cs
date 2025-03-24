namespace Net.Clinic.Application.Features.Appointments.Create
{
    public class CreateAppointmentCommandResult
    {
        public int Id { get; init; }

        public string PatientName { get; init; } = string.Empty;

        public int Identification { get; init; }

        public DateTime DateSelected { get; init; }

        public bool DidAssit { get; init; }

        public CreateAppointmentCommandResult(int id, string patientName, int identification, DateTime dateSelected, bool didAssist)
        {
            this.Id = id;
            this.PatientName = patientName;
            this.Identification = identification;
            this.DateSelected = dateSelected;
            this.DidAssit = didAssist;
        }
    }
}