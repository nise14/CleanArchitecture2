namespace NorthWind.Sales.BusinessObjects.DTOs.CreateOrder;

public class CreateOrderDTO
{
    public string CustomerId { get; set; } = null!;
    public string ShipAddress { get; set; } = null!;
    public string ShipCity { get; set; } = null!;
    public string ShipCountry { get; set; } = null!;
    public string ShipPostalCode { get; set; } = null!;
    public List<CreateOrderDetailDTO> OrderDetails { get; set; } = new();
}