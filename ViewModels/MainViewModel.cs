using CompanyEmployeesWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CompanyEmployeesWPF.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //Application.Current.MainWindow.Visibility = Visibility.Hidden;
            var loginWindow = new LoginWindow();
            loginWindow.Closed += LoginWindow_Closed;
            loginWindow.ShowDialog();
            //Application.Current.MainWindow.Visibility = Visibility.Visible;

        }

        private void LoginWindow_Closed(object sender, EventArgs e)
        {
            //Application.Current.MainWindow.Visibility = Visibility.Visible;
        }
    }
}
