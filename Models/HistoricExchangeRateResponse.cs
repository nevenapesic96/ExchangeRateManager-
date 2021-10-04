using Newtonsoft.Json;
using System;

namespace ExchangeRateCalculator.Models
{
    public class HistoricExchangeRateResponse
    {
        public ExchangeRate MinRate { get; set; }
        public ExchangeRate MaxRate { get; set; }
        public double AvarageRate { get; set; }
    }

    public class ExchangeRate
    {
        [JsonProperty("result")]
        public double Rate { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}