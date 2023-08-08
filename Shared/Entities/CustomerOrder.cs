namespace WarehouseManagement.Shared;

public class CustomerOrder : BaseEntity
{
    public List<Product> Products { get; set; } = new List<Product>();
    public double TotalAmount => Products.Sum(x => x.TotalPrice);
}

public class OurOrder : CustomerOrder
{
}