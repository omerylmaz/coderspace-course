using Library.Application.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Application.Features.Books.Errors;

internal static class BookErrors
{
    public static ProblemDetails NotFound(string id) =>
        new ProblemDetails
        {
            Title = "Book Not Found",
            Detail = $"Book with Id {id} not found",
            Status = (int)HttpStatusCode.NotFound
        };

    public static ProblemDetails NotFound() =>
    new ProblemDetails
    {
        Title = "Books Not Found",
        Detail = $"Any Book with not found",
        Status = (int)HttpStatusCode.NotFound
    };

    public static ProblemDetails Conflict(string name) =>
        new ProblemDetails
        {
            Title = "Book Conflict",
            Detail = $"Book with Name {name} already exists",
            Status = (int)HttpStatusCode.Conflict
        };

    public static ProblemDetails CreateFailure =>
        new ProblemDetails
        {
            Title = "Book Creation Failed",
            Detail = "The book could not be created.",
            Status = (int)HttpStatusCode.InternalServerError
        };

    public static ProblemDetails UpdateFailure =>
        new ProblemDetails
        {
            Title = "Book Update Failed",
            Detail = "The book could not be updated.",
            Status = (int)HttpStatusCode.InternalServerError
        };

    public static ProblemDetails DeleteFailure =>
        new ProblemDetails
        {
            Title = "Book Deletion Failed",
            Detail = "The book could not be deleted.",
            Status = (int)HttpStatusCode.InternalServerError
        };
}
