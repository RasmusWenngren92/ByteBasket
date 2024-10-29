namespace ByteBasket;

class Program
{
    static void Main(string[] args)
    {
        Customer customer1 = new Customer("Adam", "Stockholm", "0736-759-759");
        Order newOrder = new Order(customer1, new Dictionary<string, int>{{"Laptop", 3}});
        newOrder.DisplayOrder();  
        
     }
}