namespace Net.Clinic.Application.Features.Appointments.FetchCurrentDate
{
    public class FetchCurrentDateAppointmentQueryResponse
    {
        public int Id { get; init; }

        public string PatientName { get; init; } = string.Empty;

        public int Identification { get; init; }

        public DateTime DateSelected { get; init; }

        public bool DidAssit { get; init; }

        public FetchCurrentDateAppointmentQueryResponse(int id, string patientName, int identification, DateTime dateSelected, bool didAssist)
        {
            this.Id = id;
            this.PatientName = patientName;
            this.Identification = identification;
            this.DateSelected = dateSelected;
            this.DidAssit = didAssist;
        }
    }
}