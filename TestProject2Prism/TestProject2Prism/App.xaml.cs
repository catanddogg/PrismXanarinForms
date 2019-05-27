using Behaviors;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using TestProject2Prism.Core.Interfaces;
using TestProject2Prism.Core.Services;
using TestProject2Prism.ViewModels;
using TestProject2Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestProject2Prism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA0NDEzQDMxMzcyZTMxMmUzMGVrRTFPa2JpZXhjQUxqUE12Y0FaeFp3NkhZcWV6dmNjb0hySzl5SjhOM3M9");
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        } 

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            //interface
            containerRegistry.RegisterInstance<IRatesService>(new RatesService());
            containerRegistry.RegisterForNavigation<ButtonsPage, ButtonsPageViewModel>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ListRatesMoney.ListRatesMoneyModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<MoneyRatesGraphics.MoneyRatesGraphicsModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<MoneyCharts.MoneyChartsModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<BehaviorsModule>(InitializationMode.WhenAvailable);
        }
    }
}
