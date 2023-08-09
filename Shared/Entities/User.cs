namespace WarehouseManagement.Shared;

public class User : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public object Clone()
    {
        return this.MemberwiseClone();
    }
}