using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using CourseApp.Infrastructure.Repositories;

namespace CourseApp.Infrastructure.Data.Repositories;

internal class PaymentRepository(AppDbContext context) : GenericRepository<Payment>(context), IPaymentRepository;