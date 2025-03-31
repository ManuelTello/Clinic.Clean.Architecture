using System.Formats.Asn1;
using System.Text.RegularExpressions;
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
            ICollection<string> errors = new List<string>();

            if (string.IsNullOrEmpty(value))
            {
                errors.Add("Required field");
            }
            else if (!Validate().Match(value).Success)
            {
                errors.Add("Must be a valid name");
            }
            else
            {
                return DomainResult<PatientName>.Ok(new PatientName(value));
            }

            return DomainResult<PatientName>.Fail(errors);
        }

        [GeneratedRegex($"")]
        public static partial Regex Validate();
    }
}