using Prism.Ioc;
using Prism.Modularity;
using MoneyCharts.Views;
using MoneyCharts.ViewModels;

namespace MoneyCharts
{
    public class MoneyChartsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MoneyChartsPage, MoneyChartsPageViewModel>();
        }
    }
}
