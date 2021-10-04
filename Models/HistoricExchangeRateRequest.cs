using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExchangeRateCalculator.Models
{
    public class HistoricExchangeRateRequest
    {
        public DateTime[] Dates { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}