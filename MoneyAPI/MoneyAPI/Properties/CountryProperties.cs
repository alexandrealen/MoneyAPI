
namespace MoneyAPI.Properties
{
    public class CountryProperties
    {
        public string Alpha3 { get; }
        public string CurrencyId { get; }
        public string CurrencyName { get; }
        public string CurrencySymbol { get; }
        public string Id { get; }
        public string Name { get; }

        public CountryProperties(string alpha3 = null,
                                 string currencyId = null, 
                                 string currencyName = null, 
                                 string currencySymbol = null,
                                 string id = null,
                                 string name = null)
        {
            this.Alpha3 = alpha3;
            this.CurrencyId = currencyId;
            this.CurrencyName = currencyName;
            this.CurrencySymbol = currencySymbol;
            this.Id = id;
            this.Name = name;
        }
    }
}
