using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Library.Application.Result;

public record Result
{
    protected Result()
    {
        IsSuccess = true;
        ProblemDetails = default;
    }

    protected Result(ProblemDetails problemDetails)
    {
        IsSuccess = false;
        ProblemDetails = problemDetails;
    }

    public bool IsSuccess { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ProblemDetails? ProblemDetails { get; }

    public static Result Success() =>
        new();

    public static Result Failure(ProblemDetails problemDetails) =>
        new(problemDetails);
}


public record Result<TValue> : Result
{
    private readonly TValue? _value;

    private Result(
        TValue value
    ) : base()
    {
        _value = value;
    }

    private Result(
        ProblemDetails problemDetails
    ) : base(problemDetails)
    {
        _value = default;
    }

    public TValue Value => _value;

    public static Result<TValue> Success(TValue value) =>
        new(value);

    public static new Result<TValue> Failure(ProblemDetails problemDetails) =>
        new(problemDetails);

}
