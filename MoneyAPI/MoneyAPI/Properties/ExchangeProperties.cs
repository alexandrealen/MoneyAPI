
namespace MoneyAPI.Properties
{
    public class ExchangeProperties
    {
        public string fromTo { get; private set; }
        public string value { get; private set; }

        public ExchangeProperties(string fromTo = null, string value = null)
        {
            this.fromTo = fromTo;
            this.value = value;
        }
    }
}
