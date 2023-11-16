using CompanyEmployeesWPF.Properties;
using CompanyEmployeesWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompanyEmployeesWPF.Models
{
    class LoginData : ViewModelBase, IDataErrorInfo
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public string Error { get; set; }
        
        private bool _isLoginValid;
        private bool _isPasswordValid;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Login):
                        if (string.IsNullOrWhiteSpace(Login))
                        {
                            Error = "Pole Nazwa Użytkownika nie może być puste.";
                            _isLoginValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isLoginValid = true;
                        }
                        OnPropertyChanged("IsValid");
                        break;

                    case nameof(Password):
                        if (string.IsNullOrWhiteSpace(Password))
                        {
                            Error = "Pole Hasło nie może być puste.";
                            _isPasswordValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isPasswordValid = true;
                        }
                        OnPropertyChanged("IsValid");
                        break;

                    default:
                        break;
                }

                return Error;
            }
        }
        public bool IsValid
        {
            get
            {
                return _isLoginValid && _isPasswordValid;
            }
        }


        public void GetPatternData()
        {
            Login = Settings.Default.loginPattern;
            Password = Settings.Default.passwordPattern;
        }

        public bool Compare(LoginData pattern)
        {
            if (Login == pattern.Login && Password == pattern.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            Login = "";
            Password = "";
        }
    }
}
