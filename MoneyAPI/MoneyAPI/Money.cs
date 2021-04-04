using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MoneyAPI.Properties;
using System.Linq;

namespace MoneyAPI
{
    public class Money
    {
        //https://free.currencyconverterapi.com/  free api key

        private readonly string apiKey;

        //https://api.currconv.com
        //https://prepaid.currconv.com
        //https://free.currconv.com     free one
        //https://your-custom-subdomain.currconv.com
        private Uri uri { get; set; }
        public Money(string uri, string apiKey)
        {
            this.apiKey = apiKey;
            this.uri = new Uri(uri);
        }

        public async Task<string> exchangeCurrencies(string from, string to)
        {
            var client = new HttpClient();

            client.BaseAddress = uri;

            try
            {
                var response = await client.GetAsync($"/api/v7/convert?q={from.ToUpper()}_{to.ToUpper()}&compact=ultra&apiKey={apiKey}");
                var stringResult = await response.Content.ReadAsStringAsync();
                var dictResult = JsonConvert.DeserializeObject<KeyValuePair<string, string>>(stringResult);
                return $"{dictResult.Key.ToUpper()}_{dictResult.Value.ToUpper()}";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<IEnumerable<ExchangeProperties>> exchangeCurrencies(Dictionary<string, string> from_to)
        {
            var client = new HttpClient();
            client.BaseAddress = uri;

            var q = string.Join(",", from_to.Select(x => $"{x.Key}_{x.Value}"));

            try
            {

                var response = await client.GetAsync($"/api/v7/convert?q={q}&compact=ultra&apiKey={apiKey}");
                var stringResult = await response.Content.ReadAsStringAsync();
                var dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringResult);

                var result = new List<ExchangeProperties>();

                foreach (var exchange in dictResult)
                {
                    result.Add(new ExchangeProperties(exchange.Key, exchange.Value));
                }

                return result;
            }
            catch (Exception e)
            {
                var x = new List<ExchangeProperties>();
                x.Add(new ExchangeProperties(e.Message, e.HelpLink));
                return x;
            }
        }

        public async Task<IEnumerable<CurrencyProperties>> getAllCurrencies()
        {
            var client = new HttpClient();

            client.BaseAddress = uri;

            try
            {
                var response = await client.GetAsync($"/api/v7/currencies?apiKey={apiKey}");
                var stringResult = await response.Content.ReadAsStringAsync();
                var dictResult = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, CurrencyProperties>>>(stringResult);

                var resultList = new List<CurrencyProperties>();

                foreach (var currency in dictResult["results"])
                {
                    resultList.Add(new CurrencyProperties(currency.Value.CurrencyName,
                                                          currency.Value.Id,
                                                          currency.Value.CurrencySymbol));
                }
                return resultList;
            }
            catch (Exception e)
            {
                var x = new List<CurrencyProperties>();
                x.Add(new CurrencyProperties(e.Message, e.HelpLink));
                return x;
            }

        }

        public async Task<IEnumerable<CountryProperties>> getAllCountries()
        {
            var client = new HttpClient();

            client.BaseAddress = uri;

            try
            {
                var response = await client.GetAsync($"/api/v7/countries?apiKey={apiKey}");
                var stringResult = await response.Content.ReadAsStringAsync();
                var dictResult = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, CountryProperties>>>(stringResult);

                var resultList = new List<CountryProperties>();

                foreach (var country in dictResult["results"])
                {
                    resultList.Add(new CountryProperties(country.Value.Alpha3,
                                                         country.Value.CurrencyId,
                                                         country.Value.CurrencyName,
                                                         country.Value.CurrencySymbol,
                                                         country.Value.Id,
                                                         country.Value.Name));
                }

                return resultList;
            }
            catch (Exception e)
            {
                var x = new List<CountryProperties>();
                x.Add(new CountryProperties(e.Message, e.HelpLink));
                return x;
            }
        }
    }
}
