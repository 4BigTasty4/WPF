using GalaSoft.MvvmLight.Views;
using MonefyProjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonefyProjects.Views
{
    /// <summary>
    /// Interaction logic for SpendingsView.xaml
    /// </summary>
    public partial class SpendingsView : UserControl
    {
        private object _navigationService;

        public SpendingsView()
        {
            InitializeComponent();
        }

    }
}
