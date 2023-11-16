using CompanyEmployeesWPF.Commands;
using CompanyEmployeesWPF.Models;
using CompanyEmployeesWPF.Views;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Windows.Controls;

namespace CompanyEmployeesWPF.ViewModels
{
    class LoginWindowViewModel : ViewModelBase
    {
        public LoginWindowViewModel()
        {
            CancelCommand = new RelayCommand(cancelWindow);
            ConfirmCommand = new RelayCommand(loginProcess);

            UserLoginData = new LoginData();
            IsUserLoginDataNotValid = false;
        }

        public ICommand CancelCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        

        private LoginData _loginDataPattern = new LoginData();
        private LoginData _userLoginData = new LoginData();
        private bool _isUserLoginDataNotValid;
        public bool IsUserLoginDataNotValid
        {
            get {  return _isUserLoginDataNotValid; }
            set
            {
                _isUserLoginDataNotValid = value;
                OnPropertyChanged();
            }
        }
        public LoginData UserLoginData
        {
            get { return _userLoginData; }
            set
            {
                _userLoginData = value;
                OnPropertyChanged();
            }
        }
        
        private void cancelWindow(object obj)
        {
            CloseWindow(obj as Window);
            Application.Current.Shutdown();
        }
        private void loginProcess(object obj)
        {
            _loginDataPattern.GetPatternData();
            if (UserLoginData.Compare(_loginDataPattern))
            {
                CloseWindow(obj as Window);
            }
            else
            {
                
                IsUserLoginDataNotValid = true;
                UserLoginData.Clear();
                OnPropertyChanged(nameof(UserLoginData));
            }
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }
        

        
    }
}
