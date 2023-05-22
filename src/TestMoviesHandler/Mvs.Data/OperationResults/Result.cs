namespace Mvs.Data.OperationResults;

public readonly struct Result<TValue>
{
    private readonly TValue? _value;
    private readonly Exception? _error;
    public bool IsSuccess { get; }

    public Result(TValue value)
    {
        _value = value;
        _error = default;
        IsSuccess = true;
    }

    public Result(Exception error)
    {
        _error = error;
        _value = default;
        IsSuccess = false;
    }

    public static implicit operator Result<TValue>(TValue value)
        => new(value);

    public static implicit operator Result<TValue>(Exception error)
        => new(error);

    public static implicit operator bool(Result<TValue> result)
        => result.IsSuccess;

    public TResult Match<TResult>(
        Func<TValue, TResult> success,
        Func<Exception, TResult> failure) =>
        IsSuccess ? success(_value!) : failure(_error!);
}