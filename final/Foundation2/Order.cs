using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> PB_products;
        private Customer PB_customer;

        public Order(Customer customer)
        {
            PB_customer = customer;
            PB_products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            PB_products.Add(product);
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (Product p in PB_products)
            {
                total += p.GetTotalCost();
            }

            decimal shipping = PB_customer.IsInUSA() ? 5m : 35m;
            return total + shipping;
        }

        public string GetPackingLabel()
        {
            string label = "PACKING LABEL:\n";
            foreach (Product p in PB_products)
            {
                label += $"{p.Name} (ID: {p.ProductId})\n";
            }
            return label.TrimEnd();
        }

        public string GetShippingLabel()
        {
            return $"SHIPPING LABEL:\n{PB_customer.Name}\n{PB_customer.Address.GetFullAddress()}";
        }
    }
}