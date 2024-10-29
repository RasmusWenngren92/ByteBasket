namespace ByteBasket;

public class Order
{

    Guid OrderId = Guid.NewGuid();
    DateTime OrderDate = DateTime.Now;
    Delivery _delivery;
    
    Dictionary<string, Amount> Products = new Dictionary<string, Amount>();
    private Customer _customer;
    public Order(Customer customer, Dictionary<string, int> products, Delivery delivery)   
    {
        _delivery = delivery;
        _customer = customer;
        foreach (var product in products)
        {
            Amount amount = new Amount(product.Value, Prices.priceList[product.Key] * product.Value);
            Products.Add(product.Key, amount);
        }
        Console.WriteLine($"OrderId: {OrderId}");
    }

    public void DisplayOrder()
    {
        foreach (var product in Products)
        {
            Console.WriteLine($"{product.Key} {product.Value.Quantity} {product.Value.TotalPrice}");
        }
    } 
    public async Task ProcessDeliveryAsync()
    {
        await _delivery.HandleDelivery();
        DisplayOrder();
    }
}