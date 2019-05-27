using Prism.Ioc;
using Prism.Modularity;
using RatesMoneyGraphicsModul.Views;
using RatesMoneyGraphicsModul.ViewModels;

namespace RatesMoneyGraphicsModul
{
    public class RatesMoneyGraphicsModulModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
