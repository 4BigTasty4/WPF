using GalaSoft.MvvmLight.Command;
using MonefyProjects.Views;
using System;

namespace MonefyProjects.Models
{
    internal class DataModel : IData
    {
        private DataModel item;

        public DataModel()
        {
        }



        public string Cotegorie { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime TimeCreate { get; set; }
        public bool Income { get; set; }
        public string IncomeColor
        {
            get
            {
                if (Income)
                {
                    return "Green";
                }
                return "Red";
            }
            set { }
        }
        public double Money { get; set; }

        public override string ToString()
        {
            return $"{Name} {Money}";
        }

        public DataModel(DataModel item)
        {
            Cotegorie = item.Cotegorie;
            Name = item.Name;
            Color = item.Color;
            TimeCreate = item.TimeCreate;
            Income = item.Income;
            IncomeColor = item.IncomeColor;
            Money = item.Money;

        }
    }
}
