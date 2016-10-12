namespace LongParameterLists
{
    public class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public Address Address { get; set; }

        public string Summary
        {
            get
            {
                return buildCustomerSummary();
            }
        }

        private string buildCustomerSummary()
        {
            return Title + " " + FirstName + " " + LastName + ", " + Address.City + ", "
                   + Address.Postcode + ", " + Address.Country;
        }
    }
}