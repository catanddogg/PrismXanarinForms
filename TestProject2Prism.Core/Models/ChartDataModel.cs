using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2Prism.Core.Models
{
    public class ChartDataModel
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public ChartDataModel(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
