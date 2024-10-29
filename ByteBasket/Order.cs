namespace ByteBasket;

public class Order
{
    public decimal TotalPrice;
    Guid OrderId = Guid.NewGuid();
    DateTime OrderDate = DateTime.Now;
    public Delivery Delivery;
    
    public Dictionary<string, Amount> Products = new Dictionary<string, Amount>();
    private Customer _customer;
    public Order(Customer customer, Delivery delivery, Dictionary<string, int>? products = null)   
    {
        Delivery = delivery;
        _customer = customer;
        if (products != null)
        {
            foreach (var product in products)
            {
                decimal totalCost = Prices.priceList[product.Key] * product.Value;
                Amount amount = new Amount(product.Value, totalCost);
                Products.Add(product.Key, amount);
                TotalPrice += totalCost;
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
        await Delivery.HandleDelivery();
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
        TotalPrice += priceIncrease;
    }

    public void RemoveItem(string itemName)
    {
        if (Products.TryGetValue(itemName, out var item))
        {
            TotalPrice -= item.TotalPrice;
            Products.Remove(itemName);
        }
    }
}