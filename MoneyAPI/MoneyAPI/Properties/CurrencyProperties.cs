
namespace MoneyAPI.Properties
{
    public class CurrencyProperties
    {
        public string currencyName { get; private set; }
        public string id { get; private set; }
        public string currencySymbol { get; private set; }

        public CurrencyProperties(string currencyName = null, 
                                  string id = null, 
                                  string currencySymbol = null)
        {
            this.id = id;
            this.currencyName = currencyName;
            this.currencySymbol = currencySymbol;
        }
    }
}
