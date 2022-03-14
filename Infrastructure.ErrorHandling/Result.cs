namespace Infrastructure.ErrorHandling;

public class Result
{
    public bool Success { get; private set; }
    public string? Error { get; private set; }

    public bool Failure => !Success;

    protected Result(bool success, string? error = null)
    {
        Success = success;
        Error = error;
    }

    public static Result GetSuccess() => new (true);

    public static Result GetFailure(string message) => new(false, message);
}

public class Result<T> : Result
    where T : class
{
    public T? Value { get; }

    protected Result(T? value, bool success, string? error = null)
        : base(success, error)
    {
        Value = value;
    }
    
    public static Result<T> GetSuccess(T value) => new (value, true);

    public new static Result<T> GetFailure(string message) => new (null, false, message);
}