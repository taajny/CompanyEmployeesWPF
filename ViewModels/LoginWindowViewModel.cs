using CompanyEmployeesWPF.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompanyEmployeesWPF.ViewModels
{
    class LoginWindowViewModel : ViewModelBase
    {
        public LoginWindowViewModel()
        {
            CancelCommand = new RelayCommand(cancelWindow);
            ConfirmCommand = new RelayCommand(loginProcess);
        }

        public ICommand CancelCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }



        private void cancelWindow(object obj)
        {
            CloseWindow(obj as Window); 
        }
        private void loginProcess(object obj)
        {
            CloseWindow(obj as Window);
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
