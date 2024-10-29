namespace ByteBasket;

public static class Orders
{
    private static readonly Dictionary<string, List<Dictionary<string, int>>> Items = new();

    public static void DisplayItems()
    {
        if (Items.Count == 0) Console.WriteLine("No items");
        
        foreach (var item in Items)
        {
            Console.WriteLine(item.Key);
            foreach (var t in item.Value)
            {
                foreach (var key in t.Keys) Console.Write($"{key}: ");
                foreach (var value in t.Values) Console.WriteLine(value);
            }
        }
    }

    public static void AddItem(string itemName, int itemPrice)
    {
        if (Items.TryGetValue(itemName, out var item)) item[0]["Amount"] += 1;
        
        else
        {
            Items.Add(itemName, [
                new Dictionary<string, int> { { "Amount", 1 } },
                new Dictionary<string, int> { { "Price", itemPrice } }
            ]);
        }
    }

    public static void RemoveItem(string itemName)
    {
        Items.Remove(itemName);
    }
}

