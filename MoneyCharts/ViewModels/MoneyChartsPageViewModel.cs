using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TestProject2Prism.Core.Interfaces;
using TestProject2Prism.Core.Models;

namespace MoneyCharts.ViewModels
{
	public class MoneyChartsPageViewModel : BindableBase
	{

        private IRatesService _ratesService;
        private IPageDialogService _pageDialogService;

        public MoneyChartsPageViewModel(IRatesService ratesService, IPageDialogService pageDialogService)
        {
            MoneyNames = new List<string>();
            _pageDialogService = pageDialogService;
            _ratesService = ratesService;
            Title = "Chart";
            SelectedFirstDate = DateTime.Now;
            SelectedSecondDate = DateTime.Now;
            GetMoneyNames();
        }
     
        private async void GetMoneyNames()
        {
            var test = await _ratesService.GetMoneyValueRates();
            MoneyNames = test.rates.Keys.ToList();
            SelectedFirstMoney = "USD";
            SelectedSecondMoney = "RUB";
        }

        private async void GetValuesForTwoMoney()
        {
            ListValueMoney = new ObservableCollection<ChartDataModel>();
            if (_selectedFirstDate > _selectedSecondDate)
            {
                await _pageDialogService.DisplayAlertAsync("", "Dates are not set correctly!", "OK");
                return;
            }
            ListValueMoney = await _ratesService.GetTwoMoneyValueRates(_selectedFirstDate.ToString("yyyy-MM-dd"), _selectedSecondDate.ToString("yyyy-MM-dd"), _selectedFirstMoney, _selectedSecondMoney);
            RaisePropertyChanged();
        }

        private DelegateCommand _getInfoCommand;
        public DelegateCommand GetInfoCommand => _getInfoCommand ?? (_getInfoCommand = new DelegateCommand(GetInfo));

        private void GetInfo()
        {
            GetValuesForTwoMoney();
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<ChartDataModel> _listValueMoney;
        public ObservableCollection<ChartDataModel> ListValueMoney
        {
            get { return _listValueMoney; }
            set { SetProperty(ref _listValueMoney, value); }
        }

        private DateTime _selectedFirstDate;
        public DateTime SelectedFirstDate
        {
            get { return _selectedFirstDate; }
            set { SetProperty(ref _selectedFirstDate, value); }
        }

        private DateTime _selectedSecondDate;
        public DateTime SelectedSecondDate
        {
            get { return _selectedSecondDate; }
            set { SetProperty(ref _selectedSecondDate, value); }
        }

        private string _selectedFirstMoney;
        public string SelectedFirstMoney
        {
            get { return _selectedFirstMoney; }
            set
            {
                SetProperty(ref _selectedFirstMoney, value);
                SelectedMoneys = String.Format("{0} - {1}", SelectedFirstMoney, SelectedSecondMoney);
            }
        }

        private string _selectedSecondMoney;
        public string SelectedSecondMoney
        {
            get { return _selectedSecondMoney; }
            set
            {
                SetProperty(ref _selectedSecondMoney, value);
                SelectedMoneys = String.Format("{0} - {1}", SelectedFirstMoney, SelectedSecondMoney);
            }
        }

        private string _selectedMoneys;
        public string SelectedMoneys
        {
            get { return _selectedMoneys; }
            set { SetProperty(ref _selectedMoneys, value); }
        }

        private List<string> _moneyNames;
        public List<string> MoneyNames
        {
            get { return _moneyNames; }
            set { SetProperty(ref _moneyNames, value); }
        }
    }
}
