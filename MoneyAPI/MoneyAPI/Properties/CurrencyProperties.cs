
namespace MoneyAPI.Properties
{
    public class CurrencyProperties
    {
        public string CurrencyName { get; }
        public string Id { get; }
        public string CurrencySymbol { get; }

        public CurrencyProperties(string currencyName = null, 
                                  string id = null, 
                                  string currencySymbol = null)
        {
            this.Id = id;
            this.CurrencyName = currencyName;
            this.CurrencySymbol = currencySymbol;
        }
    }
}
