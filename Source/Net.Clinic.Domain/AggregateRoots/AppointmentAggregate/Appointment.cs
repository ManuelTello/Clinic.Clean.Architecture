using Net.Clinic.Domain.ObjectValues;

namespace Net.Clinic.Domain.AggregateRoots.AppointmentAggregate
{
    public sealed class Appointment
    {
        public int Id { get; private set; }

        public DateTime DateSelected { get; private set; }

        public bool DidAssist { get; private set; }

        public PatientName PatientName { get; private set; }

        public Identification Identification { get; private set; }

        public Appointment(int id, DateTime dateSelected, bool didAssist, PatientName patientName, Identification identification)
        {
            this.Id = id;
            this.DateSelected = dateSelected;
            this.DidAssist = didAssist;
            this.PatientName = patientName;
            this.Identification = identification;
        }

        private Appointment() { }
    }
}