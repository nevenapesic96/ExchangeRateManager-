using ExchangeRateCalculator.BusinessLogic;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ExchangeRateCalculator
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IExchangeRateManager, ExchangeRateManager>();
            container.RegisterType<IDataSource, ExchangeRateHostAPI>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}