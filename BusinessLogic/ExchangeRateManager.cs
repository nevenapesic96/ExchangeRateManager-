using ExchangeRateCalculator.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeRateCalculator.BusinessLogic
{
    public class ExchangeRateManager : IExchangeRateManager
    {
        private readonly IDataSource _dataSource;

        public ExchangeRateManager(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public HistoricExchangeRateResponse CalculateHistoricRate(HistoricExchangeRateRequest request)
        {
            var tasks = new List<Task>();
            var rates = new ConcurrentBag<ExchangeRate>();

            foreach (var date in request.Dates)
                tasks.Add(InsertExchangeRateInBag(request.BaseCurrency, request.TargetCurrency, date, rates));

            Task.WaitAll(tasks.ToArray());

            return new HistoricExchangeRateResponse
            {
                MaxRate = rates.MaxRate(),
                MinRate = rates.MinRate(),
                AvarageRate = rates.AvarageRate()
            };
        }

        private Task InsertExchangeRateInBag(string baseCurrency, string targetCurrency, DateTime date, ConcurrentBag<ExchangeRate> listOfRates)
        {
            return Task.Run(async () =>
            {
                var exchangeRate = await _dataSource.GetExchangeRateByDate(baseCurrency, targetCurrency, date);
                listOfRates.Add(exchangeRate);
            });
        }
    }
}