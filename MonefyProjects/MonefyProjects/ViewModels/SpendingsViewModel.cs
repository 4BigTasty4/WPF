using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MonefyProjects.Messages;
using MonefyProjects.Models;
using MonefyProjects.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonefyProjects.ViewModels
{
    class SpendingsViewModel : ViewModelBase
    {
        private IProjectNavigationService _navigationService;
        private readonly IMessenger _messenger;
        private readonly IDataService _dataService;
        //public List<DataModel> Spendings { get; set; } = new();
        public List<DataModel> _spendings;

        public List<DataModel> Spendings
        {
            get => _spendings;
            set
            {
                Set(ref _spendings, value);
            }
        }

        public SpendingsViewModel(IProjectNavigationService navigationService, IMessenger messenger, IDataService dataService)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _dataService = dataService;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message.Data as List<DataModel> != null)
                {
                    Spendings = message.Data as List<DataModel>;
                }
            });
        }

        public RelayCommand Back
        {
            get => new(
            () =>
            {
                _navigationService.NavigateTo<HomeScreenViewModel>();
            });
        }

    }
}
