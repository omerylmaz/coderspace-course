using Library.Application.DTOs.Role;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
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
        StatusCode = (int)problemDetails.Status;
    }

    public bool IsSuccess { get; }

    public int StatusCode { get; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public ProblemDetails? ProblemDetails { get; }

    public static Result Success() =>
        new();

    public static Result Failure(string title, string detail, HttpStatusCode statusCode) =>
        new(new ProblemDetails
        {
            Detail = !string.IsNullOrWhiteSpace(detail) ? detail : title,
            Title = title,
            Status = (int)statusCode
        });

    public static Result NotFound(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.NotFound);
    }

    public static Result BadRequest(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.BadRequest);
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

    public TValue Value => _value;

    public static Result<TValue> Success(TValue value) =>
        new(value);

    public static new Result<TValue> Failure(string title, string detail, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
            new(new ProblemDetails
            {
                Detail = !string.IsNullOrWhiteSpace(detail) ? detail : title,
                Title = title,
                Status = (int)statusCode
            });

    public static new Result<TValue> NotFound(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.NotFound);
    }

    public static Result<TValue> BadRequest(string title, string detail = null)
    {
        return Failure(title, detail, HttpStatusCode.BadRequest);
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
