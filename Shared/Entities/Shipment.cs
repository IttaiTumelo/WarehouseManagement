namespace WarehouseManagement.Shared;
// properties should include:  order number, customer name, items list, total amount, status, and shipper.
public class Shipment : BaseEntity
{
    public string OrderNumber { get; set; } = String.Empty;
    public string CustomerName { get; set; } = String.Empty;
    public List<Product> ShipmentItemsList { get; set; } = new List<Product>();
    public double TotalAmount => ShipmentItemsList.Sum(x => x.TotalPrice);
    public Status Status { get; set; } = Status.Pending;
    public Shipper Shipper { get; set; } = Shipper.None;
    public override string ToString() =>  $"Order Number: {OrderNumber}, Customer Name: {CustomerName}, Order Total: {TotalAmount}, Status: {Status}, Shipper: {Shipper}";
    
    public object Clone()
    {
        return this.MemberwiseClone();
    }

}

public class ShipmentItem : BaseEntity
{
    public int ShipmentId { get; set; } 
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double Total => Quantity * Price;
    
    public override string ToString() => $"Product Name: {Name}, Quantity: {Quantity}, Price: {Price}, Total: {Total}";
    
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class Shipper : BaseEntity
{ 
    public static Shipper None = new Shipper("None");
    public static Shipper FedEx = new Shipper("FedEx");
    public static Shipper UPS = new Shipper("UPS");
    public static Shipper DHL = new Shipper("DHL");
    public static Shipper USPS = new Shipper("USPS");
    public static Shipper[] Shippers = new Shipper[] { None, FedEx, UPS, DHL, USPS };
    public Shipper(string name) => Name = name;
    public override string ToString() => Name;
    
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}