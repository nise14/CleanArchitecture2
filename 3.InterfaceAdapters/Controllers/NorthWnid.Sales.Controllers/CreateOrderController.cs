namespace NorthWind.Sales.Controllers;

public class CreateOrderController : ICreateOrderController
{
    readonly ICreateOrderInputPort _inputPort;
    readonly ICreateOrderPresenter _presenter;

    public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderPresenter presenter)
    {
        _inputPort = inputPort;
        _presenter = presenter;
    }

    public async ValueTask<int> CreateOrder(CreateOrderDTO order)
    {
        await _inputPort.Handle(order);
        return _presenter.OrderId;
    }
}