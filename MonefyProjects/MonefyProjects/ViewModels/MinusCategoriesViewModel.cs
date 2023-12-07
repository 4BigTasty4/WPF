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
    class MinusCategoriesViewModel : ViewModelBase
    {
        public string Operation { get; set; }

        private IProjectNavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IDataService _dataService;

        public MinusCategoriesViewModel(IProjectNavigationService navigationService, IMessenger messenger, IDataService dataService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _dataService = dataService;

            //_messenger.Register<DataMessage>(this, message =>
            //{
            //    if (message.Data != null)
            //    {
            //        Operation = message.Data as string;
            //    }
            //});

        }

        private string _labelText;
        public string LabelText
        {
            get { return _labelText; }
            set { Set(ref _labelText, value); }
        }

        public RelayCommand<string> ChangeLabelTextCommand
        {
            get => new(
                (param) =>
                {
                    var tmp = new StringBuilder(LabelText);
                    tmp.Append(param);
                    LabelText = tmp.ToString();
                });

        }

       
        public RelayCommand SaveMinusMoney
        {
            get => new(
            () =>
            {
                    _navigationService.NavigateTo<HomeScreenViewModel>();
            });
        }


    }

}
