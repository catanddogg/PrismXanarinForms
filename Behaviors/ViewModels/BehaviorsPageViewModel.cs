using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Behaviors.ViewModels
{
	public class BehaviorsPageViewModel : BindableBase
	{
        public BehaviorsPageViewModel()
        {
            Title = "BH";
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
    }
}
