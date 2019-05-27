using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestProject2Prism.Core.Models;
using TestProject2Prism.Core.Services;

namespace TestProject2Prism.Core.Interfaces
{
    public interface IRatesService
    {
        Task<RootObject> GetMoneyValueRates(string selectedMoney =  null, string date = null);
        Task<ObservableCollection<ChartDataModel>> GetTwoMoneyValueRates(string startDate, string endDate, string firstMoney, string secondMoney);
    }
}
