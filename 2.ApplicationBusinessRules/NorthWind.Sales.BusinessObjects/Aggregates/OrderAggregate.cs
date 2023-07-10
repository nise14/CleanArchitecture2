namespace NorthWind.Sales.BusinessObjects.Aggregates;

public class OrderAggregate : Order
{
    readonly List<OrderDetail> OrderDetailsField = new();

    public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

    public void AddDetail(OrderDetail orderDetail)
    {
        var existingOrderDetail = OrderDetailsField.FirstOrDefault(o => o.ProductId == orderDetail.ProductId);

        if (existingOrderDetail != default)
        {
            var newOrderDetail = existingOrderDetail with
            {
                Quantity = (short)(orderDetail.Quantity + existingOrderDetail.Quantity)
            };

            OrderDetailsField.Add(newOrderDetail);

            OrderDetailsField.Remove(existingOrderDetail);
        }
        else
        {
            OrderDetailsField.Add(orderDetail);
        }
    }

    public void AddDetail(int productId, decimal unitPrice, short Quantity) =>
        AddDetail(new OrderDetail(productId, unitPrice, Quantity));

    public static OrderAggregate From(CreateOrderDTO orderDTO)
    {
        OrderAggregate order = new OrderAggregate
        {
            CustomerId = orderDTO.CustomerId,
            ShipAddress = orderDTO.ShipAddress,
            ShipCity = orderDTO.ShipCity,
            ShipCountry = orderDTO.ShipCountry,
            ShipPostalCode = orderDTO.ShipPostalCode
        };

        foreach (var item in orderDTO.OrderDetails)
        {
            order.AddDetail(item.ProductId, item.UnitPrice, item.Quantity);
        }

        return order;
    }
}