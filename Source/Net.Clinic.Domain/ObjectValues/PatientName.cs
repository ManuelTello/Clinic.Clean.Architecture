using Net.Clinic.Domain.DomainResult;

namespace Net.Clinic.Domain.ObjectValues
{
    public partial record PatientName
    {
        public string Value { get; init; } = string.Empty;

        private PatientName(string value)
        {
            this.Value = value;
        }

        public static DomainResult<PatientName> Create(string value)
        {
            return DomainResult<PatientName>.Ok(new PatientName(value));
        }
    }
}