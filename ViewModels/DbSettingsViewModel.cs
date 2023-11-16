using System;
using CompanyEmployeesWPF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System.Windows.Input;
using CompanyEmployeesWPF.Commands;
using System.Windows;

namespace CompanyEmployeesWPF.ViewModels
{
    class DbSettingsViewModel : ViewModelBase
    {
        //DbSettings DbSettings = new DbSettings();
        public DbSettingsViewModel()
        {
            SaveCommand = new RelayCommand(SaveSettings);
            CloseCommand = new RelayCommand(CloseSettngs);

            DbSettings= new DbSettings();
        }
        public ICommand SaveCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private DbSettings _dbSettings;

        public DbSettings DbSettings
        {
            get { return _dbSettings; }
            set
            {
                _dbSettings = value;
                OnPropertyChanged();
            }
        }

        private void CloseSettngs(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void SaveSettings(object obj)
        {
            DbSettings.Save();
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window) 
        {
            window.Close();
        }
    }
}
