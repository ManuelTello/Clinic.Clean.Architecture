namespace Net.Clinic.API.Contracts.Appointments
{
    public record FetchAppointmentByCurrentDateContract
    {
        public DateTime CurrentDate { get; init; }

        public FetchAppointmentByCurrentDateContract(DateTime currentDate)
        {
            this.CurrentDate = currentDate;
        }
    }
}