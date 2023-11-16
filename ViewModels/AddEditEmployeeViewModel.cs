using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CompanyEmployeesWPF.Commands;
using CompanyEmployeesWPF.Models.Domains;
using CompanyEmployeesWPF.Views;

namespace CompanyEmployeesWPF.ViewModels
{
    public class AddEditEmployeeViewModel : ViewModelBase
    {
        public AddEditEmployeeViewModel(Employee employee = null)
        {
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
            RealaseCommand = new RelayCommand(RealaseEmployee);

            if(employee == null ) 
            {
                Employee = new Employee();
                Employee.DateOfEmployment = DateTime.Now;
            }
            else
            {
                Employee = employee;
                Employee.JobPositionId  = employee.JobPosition.Id;
                if (employee.DateOfRelease == null)
                {
                    CanRelease = true;
                }
                IsUpdate = true;
            }



            InitJobPositions();
        }
        private Repository _repository = new Repository();
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand RealaseCommand { get; set; }

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
        
        private ObservableCollection<JobPosition> _jobPositions;

        public ObservableCollection<JobPosition> JobPositions
        {
            get { return _jobPositions; }
            set
            {
                _jobPositions = value;
                OnPropertyChanged();
            }
        }

        private int _selectedJobPositionId;
        public int SelectedJobPositionId
        {
            get { return _selectedJobPositionId; }
            set
            {
                _selectedJobPositionId = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;
        public bool IsUpdate 
        { 
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

        private bool _canRelease;
        public bool CanRelease
        {
            get { return _canRelease; }
            set
            {
                _canRelease = value;
                OnPropertyChanged();
            }
        }
        private void Cancel(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void Save(object obj)
        {
            if (!IsUpdate)
            {
                _repository.AddEmployee(Employee);
            }
            else
            {
                _repository.EditEmployee(Employee);
            }

            CloseWindow(obj as Window);            
        }
        private void RealaseEmployee(object obj)
        {
            var releaseEmployee = new ReleaseWindow(Employee);
            releaseEmployee.ShowDialog();
        }
        private void CloseWindow(Window window)
        {
            window.Close();
        }
        private void InitJobPositions()
        {
            var jobPositions = _repository.GetJobPositions();
            jobPositions.Insert(0, new JobPosition { Id = 0, Name = "" });
            JobPositions = new ObservableCollection<JobPosition>(jobPositions);
            SelectedJobPositionId = 0;
        }
    }
}
