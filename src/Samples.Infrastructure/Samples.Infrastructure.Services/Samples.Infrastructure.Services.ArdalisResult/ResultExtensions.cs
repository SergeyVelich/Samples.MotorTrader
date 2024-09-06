using Ardalis.Result;

namespace Samples.Infrastructure.Services.ArdalisResult;

public static class ResultExtensions
{
    public static Result ToResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Result.Success();
        }

        return result.Status switch
        {
            ResultStatus.Ok => Result.Success(),
            ResultStatus.Created => Result.Success(),
            ResultStatus.NoContent => Result.Success(),
            ResultStatus.Conflict => Result.Conflict(result.Errors.ToArray()),
            ResultStatus.Error => Result.Error(new ErrorList(result.Errors, result.CorrelationId)),
            ResultStatus.Forbidden => Result.Forbidden(),
            ResultStatus.Invalid => Result.Invalid(result.ValidationErrors),
            ResultStatus.Unauthorized => Result.Unauthorized(),
            ResultStatus.Unavailable => Result.Unavailable(result.Errors.ToArray()),
            ResultStatus.CriticalError => Result.CriticalError(result.Errors.ToArray()),
            ResultStatus.NotFound => Result.NotFound(result.Errors.ToArray()),
            _ => throw new ArgumentException($"Unexpected result status type {result.Status}")
        };
    }
}