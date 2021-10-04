using ExchangeRateCalculator.BusinessLogic;
using ExchangeRateCalculator.Models;
using System.Web.Http;

namespace ExchangeRateCalculator.Controllers
{
    public class ExchangeRateController : ApiController
    {
        private readonly IExchangeRateManager _exchangeRateManager;

        public ExchangeRateController(IExchangeRateManager exchangeRateManager)
        {
            _exchangeRateManager = exchangeRateManager;
        }

        [HttpGet]
        [ActionName("historical")]
        public HistoricExchangeRateResponse HistoricalExchangeRateAsync(HistoricExchangeRateRequest request)
        {
            return _exchangeRateManager.CalculateHistoricRate(request);
        }
    }
}
