namespace NorthWind.EFCore.Repositories.DataContexts;

public class NorthWindSalesContext : DbContext
{
    public NorthWindSalesContext(DbContextOptions<NorthWindSalesContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}