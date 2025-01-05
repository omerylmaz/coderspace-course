using CourseApp.Domain.Entities;
using CourseApp.Domain.Enums;

namespace CourseApp.Infrastructure.Data.SeedData;

internal class OrderSeeder
{
    public static List<Order> SeedOrders()
    {
        List<Order> orders =
            [
                new Order { CourseId = Guid.Parse("5e7f2b9c-b3f5-4c42-9f7e-8b32e2f8d8a7"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new Order { CourseId = Guid.Parse("2b9f7e8d-b4f6-4c3d-8c9f-6b23e7d9f3a2"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new Order { CourseId = Guid.Parse("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new Order { CourseId = Guid.Parse("b7e6d3c4-2e4f-4c7a-87e6-7d8f9b32c6a5"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new Order { CourseId = Guid.Parse("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new Order { CourseId = Guid.Parse("b6c8e7d9-2e4b-4c3f-98f7-7e6b9c4a9d8f"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new Order { CourseId = Guid.Parse("f7d6c9b8-3e7f-4c6b-98f7-7e9d8c4f6a9b"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
                new Order { CourseId = Guid.Parse("9c8f7e2d-b4a6-4f9d-8b32-99f7e6f9b3a4"),OrderStatus = OrderStasusses.Completed,UserId = Guid.Parse("9beb751f-f3b8-4e45-a938-622ebc1dd038"),Id = Guid.NewGuid(), CreatedDate = DateTime.Now },
            ];
        return orders;
    }
}
