using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject2Prism.Core.Models
{
    public class TwoMoney
    {
        public string @base { get; set; }
        public SortedDictionary<string, Dictionary<string, double>> rates { get; set; }
        public string end_at { get; set; }
        public string start_at { get; set; }
    }
}
