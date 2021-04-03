
namespace MoneyAPI.Properties
{
    public class CountryProperties
    {
        public string alpha3 { get; private set; }
        public string currencyId { get; private set; }
        public string currencyName { get; private set; }
        public string currencySymbol { get; private set; }
        public string id { get; private set; }
        public string name { get; private set; }

        public CountryProperties(string alpha3 = null,
                                 string currencyId = null, 
                                 string currencyName = null, 
                                 string currencySymbol = null,
                                 string id = null,
                                 string name = null)
        {
            this.alpha3 = alpha3;
            this.currencyId = currencyId;
            this.currencyName = currencyName;
            this.currencySymbol = currencySymbol;
            this.id = id;
            this.name = name;
        }
    }
}
