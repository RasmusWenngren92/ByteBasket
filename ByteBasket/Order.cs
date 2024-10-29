namespace ByteBasket;

public class Order
{
    Guid OrderId = Guid.NewGuid();
    DateTime OrderDate = DateTime.Now;
    
    Dictionary<string, Amount> Product = new Dictionary<string, Amount>();
    private Customer _customer;
    public Order(Customer customer, Dictionary<string, int> product)
    {
        
        _customer = customer;
        Console.WriteLine($"OrderId: {OrderId}");
    }
    

}