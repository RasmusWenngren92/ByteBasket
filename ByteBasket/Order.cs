namespace ByteBasket;

public class Order
{

    Guid OrderId = Guid.NewGuid();
    DateTime OrderDate = DateTime.Now;
    Delivery _delivery;
    
    public Dictionary<string, Amount> Products = new Dictionary<string, Amount>();
    private Customer _customer;
    public Order(Customer customer, Delivery delivery, Dictionary<string, int>? products = null)   
    {
        _delivery = delivery;
        _customer = customer;
        if (products != null)
        {
            foreach (var product in products)
            {
                Amount amount = new Amount(product.Value, Prices.priceList[product.Key] * product.Value);
                Products.Add(product.Key, amount);
            }
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
    public void AddItem(string itemName, int count)
    {
        decimal priceIncrease = Prices.priceList[itemName] * count;
        if (Products.TryGetValue(itemName, out var item))
        {
            item.Quantity += count;
            item.TotalPrice += priceIncrease;
            Products[itemName] = item;
        }

        else
        {
            Products.Add(itemName, new Amount(count, priceIncrease));
        }
    }

    public void RemoveItem(string itemName)
    {
        Products.Remove(itemName);
    }
}