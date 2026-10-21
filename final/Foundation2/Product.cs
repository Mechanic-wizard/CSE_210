namespace OnlineOrdering
{
    public class Product
    {
        private string PB_name;
        private string PB_productId;
        private decimal PB_pricePerUnit;
        private int PB_quantity;

        public Product(string name, string productId, decimal pricePerUnit, int quantity)
        {
            PB_name = name;
            PB_productId = productId;
            PB_pricePerUnit = pricePerUnit;
            PB_quantity = quantity;
        }

        public string Name => PB_name;
        public string ProductId => PB_productId;

        public decimal GetTotalCost()
        {
            return PB_pricePerUnit * PB_quantity;
        }
    }
}