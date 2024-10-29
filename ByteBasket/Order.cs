namespace ByteBasket;

public class Order
{

    Guid OrderId = Guid.NewGuid();
    DateTime OrderDate = DateTime.Now;
    
    Dictionary<string, Amount> Products = new Dictionary<string, Amount>();
    private Customer _customer;
    public Order(Customer customer, Dictionary<string, int> products)
    {
        foreach (var product in products)
        {
            Amount amount = new Amount(product.Value, Prices.priceList[product.Key] * product.Value);
            Products.Add(product.Key, amount);
        }
        _customer = customer;
        Console.WriteLine($"OrderId: {OrderId}");
    }

    public void DisplayOrder()
    {
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Key} {product.Value.Quantity} {product.Value.TotalPrice}");
        }
    }
    

}