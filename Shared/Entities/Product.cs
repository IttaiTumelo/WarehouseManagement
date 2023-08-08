namespace WarehouseManagement.Shared;

public class Product : BaseEntity
{
    public string Barcode { get; set; } = String.Empty;
    public int Quantity { get; set; } = 0;
    public string Location { get; set; } = String.Empty;
    public double UnitPrice { get; set; } = 0;
    public double TotalPrice => Quantity * UnitPrice;
    public override string ToString() => $"Product Name: {Name}, Barcode: {Barcode}, Quantity: {Quantity}, Location: {Location}";
}