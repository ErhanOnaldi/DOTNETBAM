namespace EduPlatform.API.Common;

public class Result
{
    public bool IsSuccess { get; init; }
    public string? Error { get; init; }

    protected Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(string error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Data { get; init; }

    private Result(bool isSuccess, T? data, string? error) : base(isSuccess, error)
    {
        Data = data;
    }

    public static Result<T> Success(T data) => new(true, data, null);
    public new static Result<T> Failure(string error) => new(false, default, error);
}
