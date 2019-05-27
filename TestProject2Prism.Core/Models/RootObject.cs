using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestProject2Prism.Core.Models
{
    public class RootObject
    {
        public string @base { get; set; }
        public Dictionary<string, double>  rates { get; set; }
        public string date { get; set; }
    }
}
