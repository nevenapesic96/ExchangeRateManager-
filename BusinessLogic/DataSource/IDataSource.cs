using ExchangeRateCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateCalculator.BusinessLogic
{
    public interface IDataSource
    {
        Task<ExchangeRate> GetExchangeRateByDate(string baseCurrency, string targetCurrency, DateTime date);
    }
}
