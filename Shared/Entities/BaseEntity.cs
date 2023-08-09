namespace WarehouseManagement.Shared;

public class BaseEntity : ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual object Clone()
    {
        return this.MemberwiseClone();
    }
}