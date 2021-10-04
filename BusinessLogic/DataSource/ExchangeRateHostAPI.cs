using ExchangeRateCalculator.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeRateCalculator.BusinessLogic
{
    public class ExchangeRateHostAPI : IDataSource
    {
        private const string URL = "https://api.exchangerate.host";

        public async Task<ExchangeRate> GetExchangeRateByDate(string baseCurrency, string targetCurrency, DateTime date)
        {
            string query = $"{URL}/convert?from={baseCurrency}&to={targetCurrency}&date={date.Year}-{date.Month:d2}-{date.Day:d2}";

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(query);

                if (response.IsSuccessStatusCode)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ExchangeRate>(stringContent);
                }
                else throw new Exception("Failed fetching data from data source");
            }
        }
    }
}
