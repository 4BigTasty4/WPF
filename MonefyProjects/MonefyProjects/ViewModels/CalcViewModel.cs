using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf.Internal;
using Microsoft.VisualBasic;
using MonefyProjects.Messages;
using MonefyProjects.Models;
using MonefyProjects.Service.Command;
using MonefyProjects.Services.Classes;
using MonefyProjects.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace MonefyProjects.ViewModels
{
    class CalcViewModel : ViewModelBase
    {
        private IProjectNavigationService _navigationService;
        private IMessenger _messenger;
        private Button myButton = new();
        private readonly IDataService _dataService;

        public DataModel Data { get; set; } = new();

        public CalcViewModel(IProjectNavigationService navigationService, IMessenger messenger, IDataService dataService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _dataService = dataService;
        }

        private string _labelText;
        public string LabelText
        {
            get { return _labelText; }
            set { Set(ref _labelText, value); }
        }

        private RelayCommand<string> _changeLabelTextCommand;
        public ICommand ChangeLabelTextCommand
        {
            get
            {
                return _changeLabelTextCommand ?? (_changeLabelTextCommand = new RelayCommand<string>((param) =>
                {
                    var tmp = new StringBuilder(LabelText);
                    tmp.Append(param);
                    LabelText = tmp.ToString();
                }));
            }
        }

        public RelayCommand RemoveDigit
        {
            get => new(
            () =>
            {
                LabelText = LabelText.Remove(LabelText.Length - 1, 1);
            });
        }


        public RelayCommand Open
        {
            get => new(
            () =>
            {
                Data.Money = Convert.ToDouble($"-{LabelText}");
                _dataService.SendData(Data);
                _navigationService.NavigateTo<HomeScreenViewModel>();
                LabelText = string.Empty;
            });

        }

    }
}

