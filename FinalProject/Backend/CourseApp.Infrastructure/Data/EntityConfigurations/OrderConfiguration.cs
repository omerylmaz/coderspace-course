using CourseApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Final.Infrustructure.Data.EntityConfigurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.OrderDate)
               .IsRequired();
        builder.HasOne(o => o.User)
               .WithMany()
               .HasForeignKey(o => o.UserId);
        builder.HasOne(o => o.Course)
               .WithMany(c => c.Orders)
               .HasForeignKey(o => o.CourseId);
    }
}
