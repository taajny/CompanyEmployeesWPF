using CompanyEmployeesWPF.Commands;
using CompanyEmployeesWPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompanyEmployeesWPF.ViewModels
{
    public class ReleaseWindowViewModel : ViewModelBase
    {
        public ReleaseWindowViewModel(Employee employee)
        {
            CancelCommand = new RelayCommand(Cancel);
            RelaseCommand = new RelayCommand(RelaseEmployee);

            Employee = new Employee();
            Employee = employee;
            Employee.DateOfRelease = DateTime.Now;
            _strLabel = $"Zwalnianie pracownika {Employee.FirstName} {Employee.LastName}";
        }
        public ICommand CancelCommand { get; set; }
        public ICommand RelaseCommand { get; set; }

        private Repository _repository = new Repository();

        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }
        private string _strLabel;
        public string StrLabel
        {
            get { return _strLabel; }
            set
            {
                _strLabel = value;
                OnPropertyChanged();
            }
        }
    
        private void RelaseEmployee(object obj)
        {
            _repository.ReleaseEmployee(Employee);
            CloseWindow(obj as Window);
        }

        private void Cancel(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
