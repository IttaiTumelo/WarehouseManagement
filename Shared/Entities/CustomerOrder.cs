namespace WarehouseManagement.Shared;

public class CustomerOrder : BaseEntity
{
    public List<Product> Products { get; set; } = new List<Product>();
    public double TotalAmount => Products.Sum(x => x.TotalPrice);
    
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

public class OurOrder : CustomerOrder
{
    
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}