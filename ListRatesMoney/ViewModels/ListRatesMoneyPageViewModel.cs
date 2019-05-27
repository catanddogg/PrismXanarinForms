using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TestProject2Prism.Core.Interfaces;
using TestProject2Prism.Core.Models;

namespace ListRatesMoney.ViewModels
{
	public class ListRatesMoneyPageViewModel : BindableBase
	{
        private IRatesService _ratesService;
        private List<string> _nameMoney;
        private RootObject _moneyValueRates;
        private List<double> _valueMoney;

        public ListRatesMoneyPageViewModel(IRatesService ratesService)
        {
            Rates = new ObservableCollection<MoneyRates>();
            MoneyNames = new List<string>();
            _ratesService = ratesService;
            Title = "MoneyRates";
            GetMoneyNames();
        }
       

        private async void GetMoneyNames()
        {
            var test = await _ratesService.GetMoneyValueRates();
            MoneyNames = test.rates.Keys.ToList();
            SelectedItemPicker = "USD";
        }

        private async void ChangeMoneyName()
        {
            _moneyValueRates = await _ratesService.GetMoneyValueRates(_selectItemPicker);
            DataMoneyRates = _moneyValueRates.date;
            _nameMoney = _moneyValueRates.rates.Keys.ToList();
            _valueMoney = _moneyValueRates.rates.Values.ToList();
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

        private string _selectItemPicker;
        public string SelectedItemPicker
        {
            get { return _selectItemPicker; }
            set
            {
                SetProperty(ref _selectItemPicker, value);
                ChangeMoneyName();
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

        private string _dataMoneyRates;
        public string DataMoneyRates
        {
            get { return _dataMoneyRates; }
            set { SetProperty(ref _dataMoneyRates, value); }
        }
    }
}
