namespace ByteBasket;

public static class Orders
{
    private static readonly Dictionary<string, Dictionary<string, int>> Items = new();

    public static void DisplayItems()
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

    public static void AddItem(string itemName, int itemPrice)
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

    public static void RemoveItem(string itemName)
    {
        Items.Remove(itemName);
    }
}

