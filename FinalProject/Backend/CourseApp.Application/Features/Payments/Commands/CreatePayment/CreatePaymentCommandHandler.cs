using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CourseApp.Application.Features.Payments.Commands.CreatePayment;

internal class CreatePaymentCommandHandler(ICourseRepository courseRepository, UserManager<AppUser> userManager, IPaymentService paymentService) : IRequestHandler<CreatePaymentCommand, Result<CreatePaymentResponse>>
{
    public async Task<Result<CreatePaymentResponse>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdWithCategoryNameAsync(request.CourseId, cancellationToken);
        if (course == null)
            Result.NotFound("Selected course not found");

        var user = await userManager.FindByIdAsync(request.UserID.ToString());
        if (user == null)
        {
            Result.NotFound($"User with id {request.UserID} not found");
        }
        CreatePaymentDto paymentDto = new CreatePaymentDto(request.CardHolderName, request.CardNumber, request.ExpireMonth, 
            request.ExpireYear, request.Cvc, request.UserID.ToString(), 
            user.FullName, user.FullName, user.PhoneNumber, user.Email, 
            course.Id.ToString(), course.Name, course.Category.Name, course.Price);

        var response = await paymentService.Pay(paymentDto, cancellationToken);

        return Result<CreatePaymentResponse>.Success(new CreatePaymentResponse(response));
    }
}
