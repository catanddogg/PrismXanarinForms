using Prism.Ioc;
using Prism.Modularity;
using MoneyRatesGraphics.Views;
using MoneyRatesGraphics.ViewModels;

namespace MoneyRatesGraphics
{
    public class MoneyRatesGraphicsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MoneyRatesGraphicsPage, MoneyRatesGraphicsPageViewModel>();
        }
    }
}
