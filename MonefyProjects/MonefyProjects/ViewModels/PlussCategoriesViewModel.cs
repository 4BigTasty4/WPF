using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MonefyProjects.Messages;
using MonefyProjects.Service.Command;
using MonefyProjects.Services.Interfaces;
using MonefyProjects.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MonefyProjects.ViewModels
{
    class PlussCategoriesViewModel : ViewModelBase
    {
        private string _operation;
        private double _value;
        public string Categorie { get; set; }

        private IProjectNavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IDataService _dataService;

        public PlussCategoriesViewModel(IProjectNavigationService navigationService, IMessenger messenger, IDataService dataService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _dataService = dataService;

            //_messenger.Register<ValueMessage>(this, message =>
            //{
            //    if (message != null)
            //    {
            //        _operation = message.Operation;
            //        _value = message.Value;
            //    }
            //});

        }



        public RelayCommand SavePlussMoney
        {
            get => new(
            () =>
            {
                //_dataService.SendData(new SpendingMessage(_value, _operation, string.Empty));
                _navigationService.NavigateTo<HomeScreenViewModel>();

            });
        }


    }
}

