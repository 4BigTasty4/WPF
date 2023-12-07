using BoardApp.Messages;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonefyProjects.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private IProjectNavigationService _navigationService;
        private IMessenger _messenger;

        private ViewModelBase _currentView;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => Set(ref _currentView, value);
        }


        public MainViewModel(IProjectNavigationService navigationService, IMessenger messenger)
        {
            CurrentView = App.Container.GetInstance<HomeScreenViewModel>();

            _messenger = messenger;
            _navigationService = navigationService;

            _messenger.Register<NavigationMessage>(this, message =>
            {
                CurrentView = message.ViewModelType;
            });
        }
    }
}
