using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject2Prism.Core.Helper;
using TestProject2Prism.Core.Interfaces;
using TestProject2Prism.Core.Models;

namespace TestProject2Prism.Core.Services
{
    public class RatesService : IRatesService
    {
        public async Task<RootObject> GetMoneyValueRates(string selectedMoney, string date)
        {
            Uri uri = null;
            if (selectedMoney == null & date == null)
            {
                uri = new Uri(String.Format("{0}latest", Constants.BaseRateMoneyUri));
            }
            if (selectedMoney != null & date == null)
            {
                uri = new Uri(String.Format("{0}latest?base={1}", Constants.BaseRateMoneyUri, selectedMoney));
            }
            if (date != null)
            {
                uri = new Uri(String.Format("{0}{1}?base={2}", Constants.BaseRateMoneyUri, date, selectedMoney));
            }
            RootObject RatesMoney = await HttpHelper.GetRatesMoney(uri);
            return RatesMoney;
        }

        public async Task<ObservableCollection<ChartDataModel>> GetTwoMoneyValueRates(string startDate, string endDate, string firstMoney, string secondMoney)
        {
            ObservableCollection<ChartDataModel> ListValueMoney = new ObservableCollection<ChartDataModel>();
            Uri uri = new Uri(String.Format("{0}history?start_at={1}&end_at={2}&base={3}&symbols={4}", Constants.BaseRateMoneyUri, startDate, endDate, firstMoney, secondMoney));
            var twoMoneyRates = await HttpHelper.GetTwoMoneyRates(uri);
            var keyMoneys = twoMoneyRates.rates.Keys.ToList();
            var valueMoneys = twoMoneyRates.rates.Values.ToList();
            int i = 0;
            foreach (var items in valueMoneys)
            {
                foreach (var item in items)
                {
                    ListValueMoney.Add(new ChartDataModel(keyMoneys[i], item.Value));
                }
                i++;
            }
            return ListValueMoney;
        }
    }
}

