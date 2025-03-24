namespace Net.Clinic.Application.ApplicationResult
{
    public record ApplicationResult<T>
    {
        public IDictionary<string, ICollection<string>> Errors { get; init; }

        public T? Data { get; init; }

        public bool IsSuccess { get; init; }

        private ApplicationResult(IDictionary<string, ICollection<string>> errors, T? data, bool isSuccess)
        {
            this.Errors = errors;
            this.Data = data;
            this.IsSuccess = isSuccess;
        }

        public static ApplicationResult<T> Ok(T data)
        {
            return new ApplicationResult<T>(new Dictionary<string, ICollection<string>>(), data, true);
        }

        public static ApplicationResult<T> Fail(IDictionary<string, ICollection<string>> errors)
        {
            return new ApplicationResult<T>(errors, default, false);
        }
    }
}