namespace OnlineOrdering
{
    public class Customer
    {
        private string PB_name;
        private Address PB_address;

        public Customer(string name, Address address)
        {
            PB_name = name;
            PB_address = address;
        }

        public string Name => PB_name;
        public Address Address => PB_address;

        public bool IsInUSA()
        {
            return PB_address.IsInUSA();
        }
    }
}