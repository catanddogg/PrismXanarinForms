using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject2Prism.ViewModels
{
	public class ButtonsPageViewModel : ViewModelBase
	{
        public ButtonsPageViewModel(INavigationService navigationService) 
            : base(navigationService)
        {
            Title = "BH";
        }
	}
}
