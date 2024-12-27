using CourseApp.Application.Abstractions.Repositories;
using CourseApp.Domain.Entities;
using Final.Application.Abstractions.Repositories;
using Final.Infrastructure.Repositories;

namespace CourseApp.Infrastructure.Data.Repositories;

internal class OrderRepository(AppDbContext context) : GenericRepository<Order>(context), IOrderRepository;