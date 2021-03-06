namespace MessageChains
{
    public class Address
    {
        public Address(Country country)
        {
            this.Country = country;
        }

        public Country Country { get; private set; }

        public bool IsInEurope()
        {
            return Country.IsInEurope;
        }
    }
}