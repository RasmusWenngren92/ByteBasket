namespace ByteBasket;

public class Orders
{
    public string Name { get; set; }
    public Guid Id = Guid.NewGuid();
    private static readonly Dictionary<string, Dictionary<string, int>> Items = new();
    
    public Orders(string name)
    {
        Name = name;
    }

    public void DisplayItems()
    {
        if (Items.Count == 0) Console.WriteLine("No items");
        
        foreach (var item in Items)
        {
            Console.WriteLine(item.Key);
            foreach (var info in item.Value)
            {
                Console.Write($"{info.Key}: ");
                Console.WriteLine($"{info.Value}");
            }
            Console.WriteLine();
        }
    }

    public void AddItem(string itemName, int itemPrice)
    {
        if (Items.TryGetValue(itemName, out var item)) item["Amount"] += 1;

        else
        {
            Items.Add(itemName, new Dictionary<string, int>
            {
                { "Amount", 1 },
                { "Price", itemPrice }
            });
        }
    }

    public void RemoveItem(string itemName)
    {
        Items.Remove(itemName);
    }
}

