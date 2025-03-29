namespace Net.Clinic.API.Contracts.Appointments
{
    public record CreateAppoinrtmentContract
    {
        public string PatientName { get; init; } = string.Empty;

        public int Identification { get; init; }

        public DateTime DateSelected { get; init; }

        public CreateAppoinrtmentContract(string patientName, int identification, DateTime dateSelected)
        {
            this.PatientName = patientName;
            this.Identification = identification;
            this.DateSelected = dateSelected;
        }
    }
}