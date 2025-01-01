using CourseApp.Application.ResultDto;
using FluentValidation;
using MediatR;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        var validationFailures = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .ToList();

        if (validationFailures.Any())
        {
            var errorMessages = validationFailures
                .GroupBy(failure => failure.PropertyName)
                .Select(group => new
                {
                    Property = group.Key,
                    Errors = group.Select(failure => failure.ErrorMessage).ToList()
                }).ToList();

            var errorsList = errorMessages
                .SelectMany(group => group.Errors)
                .ToList();

            if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
            {
                var failureResult = typeof(Result<>)
                    .MakeGenericType(typeof(TResponse).GetGenericArguments())
                    .GetMethod("BadRequest", new[] { typeof(string), typeof(string), typeof(List<string>) })
                    ?.Invoke(null,
                    [
                        "Validation Failed",
                        "One or more validation errors occurred.",
                        errorsList
                    ]);

                return (TResponse)failureResult!;
            }

            if (typeof(TResponse) == typeof(Result))
            {
                var failureResult = Result.BadRequest(
                    "Validation Failed",
                    "One or more validation errors occurred.",
                    errors: errorsList);

                return (TResponse)(object)failureResult;
            }
        }

        return await next();
    }
}
