using Net.Clinic.Domain.DomainResult;

namespace Net.Clinic.Domain.ObjectValues
{
    public partial record Identification
    {
        public int Value { get; init; }

        private Identification(int value)
        {
            this.Value = value;
        }

        public static DomainResult<Identification> Create(int value)
        {
            return DomainResult<Identification>.Ok(new Identification(value));
        }
    }
}