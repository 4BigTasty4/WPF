using MonefyProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyProjects.Messages
{
    internal class ValueMessage : IData
    {
        public double Value { get; set; }
        public string Operation { get; set; }
        public ValueMessage(double value, string operation)
        {
            Value = value;
            Operation = operation;
        }
    }
}
