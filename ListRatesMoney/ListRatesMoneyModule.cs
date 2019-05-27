using Prism.Ioc;
using Prism.Modularity;
using ListRatesMoney.Views;
using ListRatesMoney.ViewModels;

namespace ListRatesMoney
{
    public class ListRatesMoneyModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ListRatesMoneyPage, ListRatesMoneyPageViewModel>();
        }
    }
}
