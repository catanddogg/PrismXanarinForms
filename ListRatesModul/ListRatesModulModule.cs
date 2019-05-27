using Prism.Ioc;
using Prism.Modularity;
using ListRatesModul.Views;
using ListRatesModul.ViewModels;

namespace ListRatesModul
{
    public class ListRatesModulModule : IModule
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
