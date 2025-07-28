namespace WebFileExplorer.SharedKernel.Api
{
    public class Result<T>
    {
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; private set; }

        private Result(T value, bool isSuccess, string error)
        {
            Value = value;
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result<T> Success(T value) => new(value, true, string.Empty);
        public static Result<T> Failure(string error) => new(default, false, error);
    }
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; private set; }

        private Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, string.Empty);
        public static Result Failure(string error) => new(false, error);
    }
}
