namespace Net.Clinic.Domain.DomainResult
{
    public record DomainResult<T>
    {
        public ICollection<string> Errors { get; init; }

        public T? Data { get; init; }

        public bool IsSuccess { get; init; }

        private DomainResult(ICollection<string> errors, T? data, bool isSuccess)
        {
            this.Errors = errors;
            this.Data = data;
            this.IsSuccess = isSuccess;
        }

        public static DomainResult<T> Ok(T data)
        {
            return new DomainResult<T>(new List<string>(), data, true);
        }

        public static DomainResult<T> Fail(ICollection<string> errors)
        {
            return new DomainResult<T>(errors, default, false);
        }
    }
}