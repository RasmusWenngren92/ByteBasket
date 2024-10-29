namespace ByteBasket;

class Program
{
    static async Task Main(string[] args)
    {
        Customer customer1 = new Customer("Adam", "Stockholm", "0736-759-759");
        Delivery delivery = new StandardDelivery();
        Order newOrder = new Order(customer1, new Dictionary<string, int>{{"Laptop", 3}}, delivery);
        newOrder.DisplayOrder();
        newOrder.AddItem("Laptop", 5);
        newOrder.DisplayOrder();
        await newOrder.ProcessDeliveryAsync();
     }
}