namespace Mvs.Logic.OperationResults.Base;

public interface IResult
{
    bool IsSuccess { get; }
    string? Reason { get; }
}