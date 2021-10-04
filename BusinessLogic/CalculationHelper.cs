using ExchangeRateCalculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRateCalculator.BusinessLogic
{
    public static class CalculationHelper
    {
        public static ExchangeRate MinRate(this IEnumerable<ExchangeRate> rates)
        {
            var minRate = rates.FirstOrDefault();

            foreach (var rate in rates)
                if (rate.Rate < minRate.Rate) minRate = rate;

            return minRate;
        }

        public static ExchangeRate MaxRate(this IEnumerable<ExchangeRate> rates)
        {
            var maxRate = rates.FirstOrDefault();

            foreach (var rate in rates)
                if (rate.Rate > maxRate.Rate) maxRate = rate;

            return maxRate;
        }

        public static double AvarageRate(this IEnumerable<ExchangeRate> rates)
        {
            return rates.Average(x => x.Rate);
        }
    }
}