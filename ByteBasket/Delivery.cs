namespace ByteBasket;


public abstract class Delivery 
{
    protected Order _order;

    public Delivery(Order order) {
        _order = order;
    }   
    public virtual Task HandleDelivery()
    {
        return Task.CompletedTask;   
    }
}

public class StandardDelivery : Delivery
{
    public StandardDelivery (Order order): base(order)
    {
        
    }
    public override async Task HandleDelivery()
    {
        await Task.Delay(3000);
        Console.WriteLine("Standard delivery completed");
        Console.WriteLine("RECEIPT:");
        _order.DisplayOrder();
    }
}
public class ExpressDelivery : Delivery
{
    public ExpressDelivery (Order order): base(order)
    {
        
    }
    public override async Task HandleDelivery()
    {
        await Task.Delay(1000);
        Console.WriteLine("Express delivery completed");
        Console.WriteLine("RECEIPT:");
        _order.DisplayOrder();
    }
}
