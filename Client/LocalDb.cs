using System.Security.Cryptography.X509Certificates;

namespace WarehouseManagement.Client;

public  class LocalDb
{
    
    public static List<Order> Orders { get; set; }= new  List<Order>();
    public static List<OrderItem> OrderItems { get; set; }= new List<OrderItem>();
    public static List<CustomerOrder> CurrentCustomerOrder { get; set; } = new();

    public static List<OurOrder> OurOrders { get; set; } = new();
    
    public static List<Shipment> CurrentShipments = new List<Shipment>();
    
    public static List<Product> AvailableProducts { get; set; } = new List<Product>()
    {
        new Product()
        {
            Id = 1,
            Name = "Fridge",
            Barcode = "123456789",
            Quantity = 100,
            Location = "A1",
            UnitPrice = 1299
        },
        new Product()
        {
            Id = 2,
            Name = "Washing Machine",
            Barcode = "123456790",
            Quantity = 100,
            Location = "A2",
            UnitPrice = 899
        },
        

        new Product()
        {
            Id = 3,
            Name = "TV",
            Barcode = "123456791",
            Quantity = 100,
            Location = "A3",
            UnitPrice = 799
        },
        new Product()
        {
            Id = 4,
            Name = "Microwave",
            Barcode = "123456792",
            Quantity = 100,
            Location = "A4",
            UnitPrice = 299
        },
        new Product()
        {
            Id = 5,
            Name = "Dishwasher",
            Barcode = "123456793",
            Quantity = 100,
            Location = "A5",
            UnitPrice = 499
        },
        new Product()
        {
            Id = 6,
            Name = "Oven",
            Barcode = "123456794",
            Quantity = 100,
            Location = "A6",
            UnitPrice = 399
        },
        new Product()
        {
            Id = 7,
            Name = "Dryer",
            Barcode = "123456795",
            Quantity = 100,
            Location = "A7",
            UnitPrice = 499
        },
    };

    public static List<OurOrder> ReceivedOrders { get; set; } = new List<OurOrder>();
    
    public static List<OurOrder> RejectedOrders { get; set; } = new List<OurOrder>();

}