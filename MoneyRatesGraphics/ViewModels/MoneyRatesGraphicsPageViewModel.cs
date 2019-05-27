using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TestProject2Prism.Core.Interfaces;
using TestProject2Prism.Core.Models;

namespace MoneyRatesGraphics.ViewModels
{
	public class MoneyRatesGraphicsPageViewModel : BindableBase
	{
        private IRatesService _ratesService;
        private List<string> _nameMoney;
        private List<double> _valueMoney;
        private RootObject _historicalMoneyValueRates;

        public MoneyRatesGraphicsPageViewModel(IRatesService ratesService)
        {
            Rates = new ObservableCollection<MoneyRates>();
            _ratesService = ratesService;
            GetMoneyNames();
            Title = "H.MoneyRates";
            SelectedDate = DateTime.Now;
        }
     
        private async void GetMoneyNames()
        {
            var test = await _ratesService.GetMoneyValueRates();
            MoneyNames = test.rates.Keys.ToList();
            SelectedItemPicker = "USD";
        }

        private async Task ChangeHistoricalDate()
        {
            _historicalMoneyValueRates = await _ratesService.GetMoneyValueRates(_selectItemPicker, _selectedDate.ToString("yyyy-MM-dd"));
            _nameMoney = _historicalMoneyValueRates.rates.Keys.ToList();
            _valueMoney = _historicalMoneyValueRates.rates.Values.ToList();
            for (int j = 0; j < Rates.Count; j++)
            {
                Rates.RemoveAt(j);
            }
            for (int i = 0; i < _nameMoney.Count; i++)
            {
                Rates.Add(new MoneyRates { Name = _nameMoney[i], Value = _valueMoney[i] });
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                SetProperty(ref _selectedDate, value);
                ChangeHistoricalDate();
            }
        }

        private string _selectItemPicker;
        public string SelectedItemPicker
        {
            get { return _selectItemPicker; }
            set
            {
                SetProperty(ref _selectItemPicker, value);
                ChangeHistoricalDate();
            }
        }

        private List<string> _moneyNames;
        public List<string> MoneyNames
        {
            get { return _moneyNames; }
            set { SetProperty(ref _moneyNames, value); }
        }

        private ObservableCollection<MoneyRates> _rates;
        public ObservableCollection<MoneyRates> Rates
        {
            get { return _rates; }
            set { SetProperty(ref _rates, value); }
        }
    }
}
