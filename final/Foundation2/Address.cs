namespace OnlineOrdering
{
    public class Address
    {
        private string PB_street;
        private string PB_city;
        private string PB_stateProvince;
        private string PB_country;

        public Address(string street, string city, string stateProvince, string country)
        {
            PB_street = street;
            PB_city = city;
            PB_stateProvince = stateProvince;
            PB_country = country;
        }

        public bool IsInUSA()
        {
            return PB_country.ToLower() == "usa" || PB_country.ToLower() == "united states";
        }

        public string GetFullAddress()
        {
            return $"{PB_street}\n{PB_city}, {PB_stateProvince}\n{PB_country}";
        }
    }
}