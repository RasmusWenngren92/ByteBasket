namespace ByteBasket;


public abstract class Delivery 
{
    public virtual Task HandleDelivery()
    {
        return Task.CompletedTask;   
    }
}

public class StandardDelivery : Delivery
{
    public override async Task HandleDelivery()
    {
        await Task.Delay(3000);
        Console.WriteLine("Standard delivery completed");
    }
}
public class ExpressDelivery : Delivery
{
    public override async Task HandleDelivery()
    {
        await Task.Delay(1000);
        Console.WriteLine("Express delivery completed");
    }
}
