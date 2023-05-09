using Mvs.Logic.OperationResults.Base;

namespace Mvs.Logic.OperationResults;

public struct Result<T> : IResult
{
    public T? Value { get; }
    public bool IsSuccess { get; }
    public string? Reason { get; }

    public Result(T value)
    {
        Value = value;
        IsSuccess = true;
        Reason = null;
    }

    public Result(string errorReason)
    {
        Value = default;
        IsSuccess = false;
        Reason = errorReason;
    }

    public static implicit operator Result<T>(T value)
        => new(value);

    public static implicit operator bool(Result<T> result)
        => result.IsSuccess;
}