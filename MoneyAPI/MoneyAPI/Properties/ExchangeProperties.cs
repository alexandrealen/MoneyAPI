
namespace MoneyAPI.Properties
{
    public class ExchangeProperties
    {
        public string FromTo { get; }
        public string Value { get; }

        public ExchangeProperties(string fromTo = null, string value = null)
        {
            this.FromTo = fromTo;
            this.Value = value;
        }
    }
}
