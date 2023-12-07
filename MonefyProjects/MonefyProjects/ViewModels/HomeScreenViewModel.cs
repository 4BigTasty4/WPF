using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LiveCharts;
using MonefyProjects.Messages;
using MonefyProjects.Models;
using MonefyProjects.Services.Classes;
using MonefyProjects.Services.Interfaces;
using MonefyProjects.Views;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;

namespace MonefyProjects.ViewModels
{
    internal class HomeScreenViewModel : ViewModelBase
    {
        private string _sum = "0";

        private SeriesCollection _expenseDataSeries ;

        public string Sum
        {
            get => _sum;
            set => Set(ref _sum, value);
        }
        public string Operation { get; set; }

        private readonly IProjectNavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;

        public List<DataModel> Spendings { get; set; }

        public HomeScreenViewModel(IProjectNavigationService navigationService, IDataService dataService, IMessenger messenger)
        {

            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;

            Spendings = new();

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data as DataModel != null)
                {
                    var tmp = message.Data as DataModel;
                    Spendings.Add(new DataModel(tmp));
                    if (Operation == "+") Sum = (tmp.Money + Convert.ToDouble(Sum)).ToString();
                    if (Operation == "-") Sum = (tmp.Money + Convert.ToDouble(Sum)).ToString();
                    if (Operation == ".") Sum = (tmp.Money + Convert.ToDouble(Sum)).ToString();
                }
            });
        }

        
        public RelayCommand<string> OpenCalcCommand
        {
            get => new((param) =>
            {
                Operation = param;
                if (param == "+")
                {
                    _navigationService.NavigateTo<CalcPlussViewModel>();
                }
                else if (param == "-")
                {
                    _navigationService.NavigateTo<CalcMinusViewModel>();
                }
                else
                {
                    _navigationService.NavigateTo<CalcViewModel>();
                }
            });
        }

       

        public RelayCommand<string> ShowBalace
        {
            get => new((Messages) =>
            {
                MessageBox.Show(Messages);
            });
        }


        public RelayCommand ShowSpendings
        {
            get => new(() =>
            {
                _dataService.SendData(Spendings);
                _navigationService.NavigateTo<SpendingsViewModel>();
            });
        }
    }
}
