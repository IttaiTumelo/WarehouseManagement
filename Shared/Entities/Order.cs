namespace WarehouseManagement.Shared;

public class Order : BaseEntity
{   public Direction Direction { get; set; } = Direction.Out;
    public string OrderNumber { get; set; } = String.Empty;
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public string VendorName { get; set; } = String.Empty;
    public List<OrderItem> OrderItemsList { get; set; } = new List<OrderItem>();
    public Status Status { get; set; } = Status.Pending;
    public double TotalAmount => OrderItemsList.Sum(x => x.Total);
    public override string ToString() =>  $"Order Number: {OrderNumber}, Order Date: {OrderDate}, Vendor Name: {VendorName}, Order Total: {TotalAmount}";
}

public class OrderItem : BaseEntity
{
    public int OrderId { get; set; } 
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 0;
    public double Price { get; set; } = 0;
    public double Total => Quantity * Price;
    
    public override string ToString() => $"Product Name: {Name}, Quantity: {Quantity}, Price: {Price}, Total: {Total}";
}

public enum Status
{
    Pending,
    Approved,
    Rejected
}

public enum Direction
{
    In,
    Out
}
