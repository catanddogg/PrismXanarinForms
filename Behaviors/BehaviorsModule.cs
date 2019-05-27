using Prism.Ioc;
using Prism.Modularity;
using Behaviors.Views;
using Behaviors.ViewModels;

namespace Behaviors
{
    public class BehaviorsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<BehaviorsPage, BehaviorsPageViewModel>();
        }
    }
}
