using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Repositories.OrderTimes;
public class OrderTimeConfiguration : IEntityTypeConfiguration<OrderTime>
{
    public void Configure(EntityTypeBuilder<OrderTime> builder)
    {
        builder.ToTable("OrderTime");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn(1, 1);
    }
}
