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
using System.Windows.Controls;
using System.Windows.Input;

namespace MonefyProjects.ViewModels
{
    class CalcPlussViewModel : ViewModelBase
    {
        private IProjectNavigationService _navigationService;
        private IMessenger _messenger;
        private Button myButton = new();
        private readonly IDataService _dataService;

        public DataModel Data { get; set; } = new();

        public CalcPlussViewModel(IProjectNavigationService navigationService, IMessenger messenger, IDataService dataService)
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

        public RelayCommand Enter
        {
            get => new(
                () =>
                {
                    int amount = Convert.ToInt32(LabelText);
                });
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
                LabelText = LabelText.Remove(LabelText.Length - 1,1);

            });
        }


        public RelayCommand OpenCategoriesCommand
        {
            get => new(
            () =>
            {
                Data.Money = Convert.ToDouble(LabelText);
                _dataService.SendData(Data);
                _navigationService.NavigateTo<PlussCategoriesViewModel>();
                LabelText = string.Empty;

            });
        }

        

    }

}
