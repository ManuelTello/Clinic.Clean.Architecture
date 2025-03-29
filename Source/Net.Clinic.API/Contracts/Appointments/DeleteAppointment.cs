namespace Net.Clinic.API.Contracts.Appointments
{
    public record DeleteAppointmentContract
    {
        public int AppointmentId { get; init; }

        public DeleteAppointmentContract(int appointmentId)
        {
            this.AppointmentId = appointmentId;
        }
    }
}