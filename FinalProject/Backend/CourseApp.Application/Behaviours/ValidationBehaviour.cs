//using FluentValidation;
//using Library.Application.Result;
//using MediatR;

//namespace Final.Application.Behaviours;

//public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//    where TRequest : IRequest<TResponse>
//    where TResponse : Result
//{
//    private readonly IEnumerable<IValidator<TRequest>> _validators;

//    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
//    {
//        _validators = validators;
//    }

//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//    {
//        var context = new ValidationContext<TRequest>(request);

//        var failures = _validators
//            .Select(v => v.Validate(context))
//            .SelectMany(result => result.Errors)
//            .Where(error => error != null)
//            .ToList();

//        if (failures.Any())
//        {
//            List<string> errors = failures
//                .Select(x => $"{x.PropertyName}: {x.ErrorMessage}")
//                .ToList();

//            var validationResult = Result<TResponse>.BadRequest(
//                title: "Validation Error",
//                detail: "One or more validation errors occurred.",
//                errors: errors
//            );

//            return validationResult as TResponse;
//        }

//        return await next();
//    }
//}
