using CompanyEmployeesWPF.Commands;
using CompanyEmployeesWPF.Models.Domains;
using CompanyEmployeesWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompanyEmployeesWPF.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {

            var loginWindow = new LoginWindow();
            //loginWindow.Closed += LoginWindow_Closed;
            loginWindow.ShowDialog();
            
            OpenDbSettings = new RelayCommand(OpenSettings);
            RefreshCommand = new RelayCommand(Refresh);
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            EditEmployeeCommand = new RelayCommand(EditEmployee);
            InitJobPositions();
            RefreshList();

        }

        private Repository _repository = new Repository();
        public ICommand OpenDbSettings { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }

        /*private bool _isSelectedEmployee;
        public bool IsSelectedEmployee
        {
            get { return _isSelectedEmployee; }
            set
            {
                
                OnPropertyChanged();
            }
        }*/

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get {  return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                _canEdit = true;
                OnPropertyChanged();
                OnPropertyChanged("CanEdit");
            }

        }

        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            { 
                _employees = value; 
                OnPropertyChanged();
            }
        }

        private ObservableCollection<JobPosition> _jobPositions;

        public ObservableCollection<JobPosition> JobPositions
        { 
            get { return _jobPositions; } 
            set
            {
                _jobPositions= value;
                OnPropertyChanged();
            }
        }

        private int _selectedJobPositionId;
        public int SelectedJobPositionId
        {
            get { return _selectedJobPositionId; }
            set
            {
                _selectedJobPositionId= value;
                OnPropertyChanged();
            }
        }

        private bool[] _employmentArray = new bool[] { true, false, false };
        public bool[] EmploymentArray
        {
            get { return _employmentArray; }
            set
            {
                _employmentArray = value;
                OnPropertyChanged();
            }
        }
        private bool _canEdit;
        public bool CanEdit
        {
            get { return _canEdit; }
            set 
            {
                _canEdit = value;
            }
        }
        private void OpenSettings(object obj)
        {
            var dbSettingsWindow = new DbSettings();
            dbSettingsWindow.ShowDialog();
        }
        private void EditEmployee(object obj)
        {
            var addEditEmployee = new AddEditEmployee(obj as Employee);
            addEditEmployee.Closed += AddEditEmployee_Closed;
            addEditEmployee.ShowDialog();
        }

        private void AddEmployee(object obj)
        {
            var addEditEmployee = new AddEditEmployee(obj as Employee);
            addEditEmployee.Closed += AddEditEmployee_Closed;
            addEditEmployee.ShowDialog();
        }

        private void AddEditEmployee_Closed(object sender, EventArgs e)
        {
            RefreshList();
            CanEdit = false;
            OnPropertyChanged("CanEdit");            
        }

        private void RefreshList()
        {
            int employmentStatus;
            if (EmploymentArray[0])
            {
                employmentStatus = 0;
            }
            else if (EmploymentArray[1])
            {
                employmentStatus = 1;
            }
            else
            {
                employmentStatus = 2;
            }

            Employees = new ObservableCollection<Employee>(_repository.GetEmployees(SelectedJobPositionId, employmentStatus));
            OnPropertyChanged("SelectedEmployee");
        }
        private void Refresh(object obj)
        {
            RefreshList();
            CanEdit = false;
            OnPropertyChanged("CanEdit");
        }

        private void InitJobPositions()
        {
            var jobPositions = _repository.GetJobPositions();
            jobPositions.Insert(0, new JobPosition { Id = 0, Name = "Wszystkie"});
            JobPositions = new ObservableCollection<JobPosition>(jobPositions);
            SelectedJobPositionId = 0;
        }
    }
}
