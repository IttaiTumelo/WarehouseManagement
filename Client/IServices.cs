
namespace WarehouseManagement.Client;

public interface IBaseService<T> where T : BaseEntity
{
    List<T> Objects { get; set; }
    T Object { get; set; }
    // Task<List<T>> Get(bool forceRefresh = false, int id = 0, Degree degree = Degree.Unset );
    Task<List<T>> Get(bool forceRefresh = false, int id = 0, string name = "");
    Task<T> Create(T dto);
    Task<T> Update(T t);
    Task<T> Delete(int id);
}

public interface IUserService : IBaseService<User> { }
public interface IOrderService : IBaseService<Order> { }
public interface IProductService : IBaseService<Product> { }
public interface IOrderItemService : IBaseService<OrderItem> { }
public interface IShipmentService : IBaseService<Shipment> { }
public interface IShipmentItemService : IBaseService<ShipmentItem> { }
public interface IShipperService : IBaseService<Shipper> { }


public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
{
    private readonly HttpClient _httpClient;
    public List<T> Objects { get; set; }
    public T Object { get; set; }

    protected BaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Objects = new List<T>();
        Object = new T();
    }

    public virtual async Task<List<T>> Get(bool forceRefresh = false, int id = 0, string name = "")
    {
        if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (Objects.Count == 0 || forceRefresh)
        {
            var request = await _httpClient.GetAsync($"api/{typeof(T).Name}");
            if (!request.IsSuccessStatusCode) throw new Exception(request.ReasonPhrase);
            var objects = await request.Content.ReadFromJsonAsync<List<T>>();
            Objects = objects ?? throw new Exception("No objects were found");
        }

        if (id != 0)
            return new List<T>()
            {
                Objects.FirstOrDefault(obj => obj.Id == id) ??
                throw new InvalidOperationException($"No {typeof(T).Name} with id {id} is found")
            };
        return !string.IsNullOrEmpty(name)
            ? new List<T>()
            {
                Objects.FirstOrDefault(obj => obj.Name.Equals(name)) ??
                throw new InvalidOperationException($"No {typeof(T).Name} with name {name} is found")
            }
            : Objects;
    }

    public virtual async Task<T> Create(T dto)
    {
        var request = await _httpClient.PostAsJsonAsync($"api/{typeof(T).Name}", dto);
        if (!request.IsSuccessStatusCode)
            throw new Exception($"Creating {typeof(T).Name} returned {request.StatusCode}");
        var response = await request.Content.ReadFromJsonAsync<T>();
        Object = response ?? throw new Exception($"Creating {typeof(T).Name} returned is null");
        Objects.Add(Object);
        return response;
    }

    public virtual async Task<T> Delete(int id)
    {
        var request = await _httpClient.DeleteAsync($"api/{typeof(T).Name}/{id}");
        if (!request.IsSuccessStatusCode) throw new Exception(request.ReasonPhrase);
        var response = await request.Content.ReadFromJsonAsync<T>();
        if (response == null) throw new Exception($"No {typeof(T).Name} was deleted");
        Objects.Remove(Objects.First(o => o.Id == id));
        return response;
    }

    public virtual async Task<T> Update(T t)
    {
        var request = await _httpClient.PutAsJsonAsync($"api/{typeof(T).Name}", t);
        if (!request.IsSuccessStatusCode) throw new Exception(request.ReasonPhrase);
        var response = await request.Content.ReadFromJsonAsync<T>();
        if (response is null) throw new Exception("No object was updated");
        //Update the local data
        var obj = Objects.FirstOrDefault(o => o.Id == response.Id);
        if (obj != null) Objects.Remove(obj);
        Objects.Add(response);
        //return response
        return response;
    }
}

public class UserService : BaseService<User>, IUserService
{
    public UserService(HttpClient httpClient) : base(httpClient) { }
}

public class OrderService : BaseService<Order>, IOrderService
{
    public OrderService(HttpClient httpClient) : base(httpClient) { }
}

public class ProductService : BaseService<Product>, IProductService
{
    public ProductService(HttpClient httpClient) : base(httpClient) { }
}

public class OrderItemService : BaseService<OrderItem>, IOrderItemService
{
    public OrderItemService(HttpClient httpClient) : base(httpClient) { }
}

public class ShipmentService : BaseService<Shipment>, IShipmentService
{
    public ShipmentService(HttpClient httpClient) : base(httpClient) { }
}

public class ShipmentItemService : BaseService<ShipmentItem>, IShipmentItemService
{
    public ShipmentItemService(HttpClient httpClient) : base(httpClient) { }
}
//
// public class ShipperService : BaseService<Shipper>, IShipperService
// {
//     public ShipperService(HttpClient httpClient) : base(httpClient) { }
// }
//
