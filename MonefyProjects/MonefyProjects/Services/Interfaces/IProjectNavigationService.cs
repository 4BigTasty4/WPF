using GalaSoft.MvvmLight;

namespace BoardApp.Services.Interfaces
{
    public interface IProjectNavigationService
    {
        public void NavigateTo<T>() where T : ViewModelBase;
    }

    public interface IBorderNavigationService
    {
        public void NavigateTo<T>() where T: ViewModelBase;
    }
}
