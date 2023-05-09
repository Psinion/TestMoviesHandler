using Mvs.Logic.OperationResults.Base;

namespace Mvs.Logic.OperationResults;

public struct Result : IResult
{
    public bool IsSuccess { get; }
    public string? Reason { get; }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
        Reason = null;
    }

    public Result(string errorReason)
    {
        IsSuccess = false;
        Reason = errorReason;
    }

    public static implicit operator bool(Result result) 
        => result.IsSuccess;
}