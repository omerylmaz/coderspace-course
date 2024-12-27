using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

namespace CourseApp.Application.ResultDto;

public record Result
{
    protected Result()
    {
        IsSuccess = true;
        ProblemDetails = default;
        StatusCode = 200;  //TODO burayı daha sonra ayarla
    }

    protected Result(ProblemDetails problemDetails)
    {
        IsSuccess = false;
        ProblemDetails = problemDetails;
        StatusCode = (int)problemDetails.Status;
    }

    public bool IsSuccess { get; }

    public int StatusCode { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ProblemDetails? ProblemDetails { get; }

    public static Result Success() =>
        new();

    public static Result Failure(string title, string detail, HttpStatusCode statusCode, List<string>? errors = null) =>
        new(new ProblemDetails
        {
            Detail = !string.IsNullOrWhiteSpace(detail) ? detail : title,
            Title = title,
            Status = (int)statusCode,
            Extensions =
            {
                { "errors", errors ?? new List<string>() }
            }
        });

    public static Result NotFound(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.NotFound);
    }

    public static Result BadRequest(string title, string detail = null, List<string>? errors = null)
    {
        return Failure(title, detail, HttpStatusCode.BadRequest, errors);
    }

    public static Result Unauthorized(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.Unauthorized);
    }

    public static Result Conflict(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.Conflict);
    }
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

    public TValue Data => _value;

    public static Result<TValue> Success(TValue value) =>
        new(value);

    public static new Result<TValue> Failure(string title, string detail, HttpStatusCode statusCode = HttpStatusCode.BadRequest, List<string>? errors = null) =>
            new(new ProblemDetails
            {
                Detail = !string.IsNullOrWhiteSpace(detail) ? detail : title,
                Title = title,
                Status = (int)statusCode,
                Extensions =
                {
                    { "errors", errors ?? new List<string>() }
                }
            });

    public static new Result<TValue> NotFound(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.NotFound);
    }

    public static Result<TValue> BadRequest(string title, string detail = null, List<string>? errors = null)
    {
        return Failure(title, detail, HttpStatusCode.BadRequest, errors);
    }

    public static Result<TValue> Unauthorized(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.Unauthorized);
    }

    public static Result<TValue> Conflict(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.Conflict);
    }
}
