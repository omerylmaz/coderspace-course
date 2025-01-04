using AutoMapper;
using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Application.Abstractions.Services;
using CourseApp.Application.DTOs.Payment;
using CourseApp.Application.ResultDto;
using CourseApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace CourseApp.Application.Features.Payments.Commands.CreatePayment;

internal class CreatePaymentCommandHandler
    (ICourseRepository courseRepository, 
    UserManager<AppUser> userManager, 
    IPaymentService paymentService,
    IPaymentRepository paymentRepository,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork,
    ILogger<CreatePaymentCommandHandler> logger,
    IMapper mapper

    ) : IRequestHandler<CreatePaymentCommand, Result<CreatePaymentResponse>>
{
    public async Task<Result<CreatePaymentResponse>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetDetailByIdWithCategoryNameAsync(request.CourseId, cancellationToken);
        if (course == null)
        {
            logger.LogWarning("Course with Id {Id} not found", request.CourseId);
            Result.NotFound("Selected course not found");
        }

        var user = await userManager.FindByIdAsync(request.UserID.ToString());
        if (user == null)
        {
            logger.LogWarning("User with Id {Id} not found", request.UserID);
            return Result<CreatePaymentResponse>.NotFound($"User with id {request.UserID} not found");
        }

        var externalPaymentResponse = new GetExternalPaymentResponseDto();

        var order = await orderRepository.GetWhereAsync(x => x.UserId == request.UserID && x.CourseId == request.CourseId, cancellationToken);

        var existsPayment = await paymentRepository.GetWhereAsync(x => x.OrderId == order.Id, cancellationToken);
        if (existsPayment is null)
        {
            var paymentId = Guid.NewGuid();  // Normalde entityler içeride savechanges denildiği zaman otomatik generate ediliyor fakat burada payment callback olduğu zaman takibi olsun diye dışarıdan guid generate ediyorum
            await paymentRepository.AddAsync(new Payment() { Id = paymentId, OrderId = order.Id, Price = course.Price, PaymentDate = DateTime.Now, ThreeDSStatus = false }, cancellationToken);
            externalPaymentResponse = await GetThreeDSFromExternalPayment(paymentId, request, user, course, cancellationToken);
        }
        else if (existsPayment.ThreeDSStatus == true)
        {
            logger.LogWarning("Course with Id {Id} already paid", request.CourseId);
            return Result<CreatePaymentResponse>.Conflict($"This course has already paid");
        }
        else 
        {
            externalPaymentResponse = await GetThreeDSFromExternalPayment(existsPayment.Id, request, user, course, cancellationToken);
        }


        if (string.IsNullOrEmpty(externalPaymentResponse.HtmlContent))
        {
            logger.LogWarning("User tried to pay but process failed with {Id}", request.UserID);
            return Result<CreatePaymentResponse>.BadRequest($"There happened a problem during payment, please check your informations"); //TODO: burada daha sonra refactor çek
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var createPaymentResponse = mapper.Map<CreatePaymentResponse>(externalPaymentResponse);

        return Result<CreatePaymentResponse>.Success(createPaymentResponse);
    }

    private async Task<GetExternalPaymentResponseDto> GetThreeDSFromExternalPayment(Guid paymentId, CreatePaymentCommand command, AppUser user, Course course, CancellationToken cancellationToken)
    {
        CreatePaymentDto paymentDto = new CreatePaymentDto(paymentId, command.CardHolderName, command.CardNumber, command.ExpireMonth,
        command.ExpireYear, command.Cvc, command.UserID.ToString(),
        user.FullName, user.FullName, user.PhoneNumber, user.Email,
        course.Id.ToString(), course.Name, course.Category.Name, course.Price);

        var paymentResponse = await paymentService.Pay(paymentDto, cancellationToken);

        return paymentResponse;
    }
}
