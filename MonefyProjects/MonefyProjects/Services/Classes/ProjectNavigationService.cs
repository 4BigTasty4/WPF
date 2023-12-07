using BoardApp.Messages;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using MonefyProjects;

namespace BoardApp.Services.Classes
{
    public class ProjectNavigationService : IProjectNavigationService
    {
        private readonly IMessenger _messenger;

        public ProjectNavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = App.Container.GetInstance<T>()
            });
        }
    }
}
