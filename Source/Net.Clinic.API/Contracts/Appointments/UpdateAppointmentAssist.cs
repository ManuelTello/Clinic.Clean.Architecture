namespace Net.Clinic.API.Contracts.Appointments
{
    public record UpdateAppointmentAssistContract
    {
        public int AppointmentId { get; init; }

        public UpdateAppointmentAssistContract(int appointmentId)
        {
            this.AppointmentId = appointmentId;
        }
    }
}