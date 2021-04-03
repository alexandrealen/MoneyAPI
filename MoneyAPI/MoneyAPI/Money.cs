using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MoneyAPI.Properties;

namespace MoneyAPI
{
    public class Money
    {
        private string apiKey { get; set; } 
        public Money(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<string> exchangeCurrencies(string from, string to)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://free.currconv.com");

            var response = await client.GetAsync($"/api/v7/convert?q={from.ToUpper()}_{to.ToUpper()}&compact=ultra&apiKey={apiKey}");
            var stringResult = await response.Content.ReadAsStringAsync();
            var dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringResult);

            return dictResult[$"{from.ToUpper()}_{to.ToUpper()}"];
        }

        public async Task<IEnumerable<ExchangeProperties>> exchangeCurrencies(Dictionary<string, string> from_to)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://free.currconv.com");

            string q = "";

            foreach(var fromTo in from_to)
            {
                if(q != "")
                {
                    q += ",";
                }
                q += $"{fromTo.Key}_{fromTo.Value}";
            }

            var response = await client.GetAsync($"/api/v7/convert?q={q}&compact=ultra&apiKey={apiKey}");
            var stringResult = await response.Content.ReadAsStringAsync();
            var dictResult = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringResult);

            var result = new List<ExchangeProperties>();

            foreach(var exchange in dictResult)
            {
                result.Add(new ExchangeProperties(exchange.Key, exchange.Value));
            }

            return result;
        }

        public async Task<IEnumerable<CurrencyProperties>> getAllCurrencies()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://free.currconv.com");

            var response = await client.GetAsync($"/api/v7/currencies?apiKey={apiKey}");
            var stringResult = await response.Content.ReadAsStringAsync();
            var dictResult = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, CurrencyProperties>>>(stringResult);

            var resultList = new List<CurrencyProperties>();

            foreach (var currency in dictResult["results"])
            {
                resultList.Add(new CurrencyProperties(currency.Value.currencyName,
                                                      currency.Value.id,
                                                      currency.Value.currencySymbol));
            }
            return resultList;
        }

        public async Task<IEnumerable<CountryProperties>> getAllCountries()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://free.currconv.com");

            var response = await client.GetAsync($"/api/v7/countries?apiKey={apiKey}");
            var stringResult = await response.Content.ReadAsStringAsync();
            var dictResult = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, CountryProperties>>>(stringResult);

            var resultList = new List<CountryProperties>();

            foreach(var country in dictResult["results"])
            {
                resultList.Add(new CountryProperties(country.Value.alpha3, 
                                                     country.Value.currencyId,
                                                     country.Value.currencyName,
                                                     country.Value.currencySymbol,
                                                     country.Value.id,
                                                     country.Value.name));
            }

            return resultList;
        }
    }
}
