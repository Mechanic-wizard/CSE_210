using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Address address2 = new Address("456 Elm St", "Toronto", "Ontario", "Canada");

            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            Product product1 = new Product("Laptop", "LP100", 1200m, 1);
            Product product2 = new Product("Mouse", "MS200", 25m, 2);
            Product product3 = new Product("Keyboard", "KB300", 75m, 1);
            Product product4 = new Product("Monitor", "MN400", 300m, 1);
            Product product5 = new Product("USB Cable", "UC500", 10m, 3);

            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);
            order1.AddProduct(product3);

            Order order2 = new Order(customer2);
            order2.AddProduct(product4);
            order2.AddProduct(product5);

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():0.00}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():0.00}");
        }
    }
}