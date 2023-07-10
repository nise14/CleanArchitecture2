namespace NorthWind.EFCore.Repositories.Configurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(d => new { d.OrderId, d.ProductId });

        builder.Property(d => d.UnitPrice)
            .HasPrecision(8, 2);
    }
}