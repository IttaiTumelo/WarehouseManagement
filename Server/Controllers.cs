namespace WarehouseManagement.Server.Pages;

[ApiController]
[Route("api/[controller]")]
public class Controllers<T> : ControllerBase where T : BaseEntity, new()
{
    protected readonly DataContext _context;
    private readonly T _entity;
    public Controllers(DataContext context)
    {
        _context = context;
        _entity = new BaseEntity() as T;
    }
    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<T>>> Get() => await _context.Set<T>().ToListAsync()?? throw new Exception($"No {typeof(T).Name} were found");
    [HttpPost("byValue")]


    [HttpPost]
    public virtual async Task<ActionResult<T>> Post(T entity) //Post(TDto entity)
    {   
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        var newEntity = new T();
        newEntity = entity as T;
        if (newEntity is null) throw new Exception($"Could not cast {entity.GetType().Name} to {typeof(T).Name}");
        await _context.Set<T>().AddAsync(newEntity);
        await _context.SaveChangesAsync();
        // return CreatedAtAction(nameof(Get), new { id = newEntity.Id }, newEntity);
        throw new NotImplementedException();
    }

    [HttpPut]
    public virtual async Task<ActionResult<T>> Put(T entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok(entity);
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<T>> Delete(int id)
    {   
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity is null)
        {
            return NotFound();
        }
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return Ok(entity);
    }

    [HttpDelete]
    public virtual async Task<ActionResult<T>> Delete()
    {   
        var entities = await _context.Set<T>().ToListAsync();
        if (entities is null)
        {
            return NotFound();
        }
        _context.Set<T>().RemoveRange(entities);
        await _context.SaveChangesAsync();
        return Ok(entities);
    }
}

public class ProductController : Controllers<Product>
{
    public ProductController(DataContext context) : base(context)
    {
    }
}

public class OrderItemController : Controllers<OrderItem>
{
    public OrderItemController(DataContext context) : base(context)
    {
    }
}


public class OrderController : Controllers<OrderItem>
{
    public OrderController(DataContext context) : base(context)
    {
    }
}

public class ShipmentController : Controllers<OrderItem>
{
    public ShipmentController(DataContext context) : base(context)
    {
    }
}

public class ShipperController : Controllers<OrderItem>
{
    public ShipperController(DataContext context) : base(context)
    {
    }
}

public class ShipmentItemController : Controllers<OrderItem>
{
    public ShipmentItemController(DataContext context) : base(context)
    {
    }
}

public class UserController : Controllers<User>
{
    public UserController(DataContext context) : base(context)
    {
    }
}