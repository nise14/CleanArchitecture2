namespace NorthWind.Sales.Presenters;

public class CreateOrderPresenter : ICreateOrderPresenter
{
    public int OrderId { get; set; }

    public ValueTask Handle(int orderId)
    {
        OrderId = orderId;
        return ValueTask.CompletedTask;
    }
}