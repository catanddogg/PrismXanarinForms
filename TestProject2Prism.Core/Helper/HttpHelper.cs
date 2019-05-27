using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject2Prism.Core.Models;

namespace TestProject2Prism.Core.Helper
{
    public static class HttpHelper
    {
        public async static Task<RootObject> GetRatesMoney(Uri uri)
        {
            HttpClient _client = new HttpClient();
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                RootObject items = JsonConvert.DeserializeObject<RootObject>(content);
                return items;
            }
            return null;
        }

        public async static Task<TwoMoney> GetTwoMoneyRates(Uri uri)
        {
            HttpClient _client = new HttpClient();
            ObservableCollection<ChartDataModel> ListValueMoney = new ObservableCollection<ChartDataModel>();
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                TwoMoney Moneyitems = JsonConvert.DeserializeObject<TwoMoney>(content);
                return Moneyitems;
            }
            return null;
        }
    }
}
