namespace PoliceAbsenceService.Application.DTOs;

public class Result
{
    protected Result(bool isSuccess, string? error=null, string? errorCode = null)
    {
        IsSuccess = isSuccess;
        Error = error;
        ErrorCode = errorCode;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string? Error { get; }
    public string? ErrorCode { get; }

    public static Result Success() => new(true, null);
    public static Result Failure(string error, string errorCode = null)
        => new(false, error, errorCode);
}

public class Result<T>: Result where T : class
{
    protected Result(bool isSuccess, T? value, string? error = null, string? errorCode = null) : base(isSuccess, error, errorCode)
    {
        Value = value ;
    }

    public T? Value { get; }

    public static Result<T> Success(T value) => new(true, value);
    public static Result<T> Failure(T value, string error, string? errorCode = null) => new(false, value, error, errorCode);
    public static new Result<T> Failure(string error, string? errorCode = null) => new(false, null, error, errorCode);
}
