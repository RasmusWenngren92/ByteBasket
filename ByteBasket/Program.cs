﻿namespace ByteBasket;

class Program
{
    static async Task Main(string[] args)
    {
        Customer customer1 = new Customer("Adam", "Stockholm", "0736-532-759");
        Customer customer2 = new Customer("Steve", "London", "0736-759-759");
        Customer customer3 = new Customer("Carlos", "London", "0736-123-759");
        Customer customer4 = new Customer("Arnold", "Stockholm", "0736-124-759");
        Customer customer5 = new Customer("Frank", "Copenhagen", "0736-567-759");
        Delivery delivery1 = new StandardDelivery();
        Delivery delivery2 = new StandardDelivery();
        Delivery delivery3 = new ExpressDelivery();
        Delivery delivery4 = new ExpressDelivery();
        Delivery delivery5 = new StandardDelivery();

        List<Order> orders = [
        new Order(customer1, delivery1, new Dictionary<string, int>{{"Laptop", 1}}),
        new Order(customer1, delivery2, new Dictionary<string, int>{{"Laptop", 3}}),
        new Order(customer1, delivery3, new Dictionary<string, int>{{"Mus", 2}}),
        new Order(customer1, delivery4, new Dictionary<string, int>{{"Tangentbord", 4}}),
        new Order(customer1, delivery5, new Dictionary<string, int>{{"Laptop", 5}})
        ];

        IEnumerable<Order> expressOrders = orders.Where(o => o.Delivery.GetType() == typeof(ExpressDelivery));
        foreach (Order expressOrder in expressOrders)
        {
            expressOrder.DisplayOrder();
        }

        decimal Price = orders.Sum(o => o.TotalPrice);
        Console.WriteLine($"The total value of all orders is: {Price}");

        decimal HighestPrice = orders.Max(o => o.TotalPrice);
        Console.WriteLine($"The most expensive order is: {HighestPrice}");


        IEnumerable<List<Order>> customersGroup = orders.GroupBy(o => o.Customer.FirstName).Select(group => group.ToList());
        foreach (List<Order> customerOrders in customersGroup)
        {
            Console.WriteLine($"{customerOrders[0].Customer.FirstName} {customerOrders.Count}");
        }
        IEnumerable<Order> orderByDates = orders.OrderByDescending(o => o.OrderDate);
        foreach (Order order in orderByDates)
        {
            Console.WriteLine(order.OrderDate);
        }

        Task.WaitAll(orders.Select(o => o.ProcessDeliveryAsync()).ToArray());
    }
}