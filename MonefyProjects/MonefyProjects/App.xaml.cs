using BoardApp.Services.Classes;
using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using MonefyProjects.Services.Classes;
using MonefyProjects.Services.Interfaces;
using MonefyProjects.ViewModels;
using MonefyProjects.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MonefyProjects
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        public void Register()
        {
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IDataService, DataService>();
            Container.RegisterSingleton<IProjectNavigationService, ProjectNavigationService>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<HomeScreenViewModel>();
            Container.RegisterSingleton<CalcViewModel>();
            Container.RegisterSingleton<CalcMinusViewModel>();
            Container.RegisterSingleton<CalcPlussViewModel>();
            Container.RegisterSingleton<PlussCategoriesViewModel>();
            Container.RegisterSingleton<MinusCategoriesViewModel>();
            Container.RegisterSingleton<SpendingsViewModel>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            Register();

            var window = new MainView()
            {
                DataContext = Container.GetInstance<MainViewModel>()
            };

            window.ShowDialog();
        }
    }
}
