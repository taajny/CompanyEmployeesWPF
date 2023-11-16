using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CompanyEmployeesWPF.Models;
using CompanyEmployeesWPF.Models.Domains;
using System.Xml.Linq;
using CompanyEmployeesWPF.ViewModels;

namespace CompanyEmployeesWPF
{
    public class Repository : ViewModelBase
    {
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
        public List<Employee> GetEmployees(int jobPositionId, int employmentStatus)
        {

            DbSettings = new DbSettings();
            using (var context = new ApplicationDbContext(DbSettings.CreateConnectionString()))
            {
                var employees = context.Employees.Include(x => x.JobPosition).AsQueryable();

                if (jobPositionId != 0)
                {
                    employees = employees.Where(x => x.JobPositionId == jobPositionId);
                }

                if( employmentStatus != 0) 
                {
                    if (employmentStatus == 1)
                    {
                        employees = employees.Where(x => x.DateOfRelease == null);
                    }
                    else
                    {
                        employees = employees.Where(x => x.DateOfRelease != null);
                    }

                }
                
                return employees.ToList();
            }
        }

        public List<JobPosition> GetJobPositions()
        {
            DbSettings = new DbSettings();
            using ( var contex = new ApplicationDbContext(DbSettings.CreateConnectionString()))
            {
                return contex.JobPositions.ToList();
            }
        }

        public void AddEmployee(Employee employee)
        {
            DbSettings = new DbSettings();
            using( var context = new ApplicationDbContext(DbSettings.CreateConnectionString())) 
            { 
                context.Employees.Add(employee);
                context.SaveChanges();
            }
        }

        public void EditEmployee(Employee employee)
        {
            DbSettings = new DbSettings();
            using( var context = new ApplicationDbContext(DbSettings.CreateConnectionString()))
            {
                var employeeToUpdate = context.Employees.Find(employee.Id);

                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.Earnings = employee.Earnings;
                employeeToUpdate.DateOfEmployment = employee.DateOfEmployment;
                //employeeToUpdate.DateOfRelease = employee.DateOfRelease;
                employeeToUpdate.Comments = employee.Comments;
                employeeToUpdate.JobPositionId = employee.JobPositionId;
                //employeeToUpdate.JobPosition = employee.JobPosition;

                context.SaveChanges();
            }

        }

        public void ReleaseEmployee(Employee employee)
        {
            DbSettings = new DbSettings();
            using (var context = new ApplicationDbContext(DbSettings.CreateConnectionString()))
            {
                var employeeToRelease = context.Employees.Find(employee.Id);

                employeeToRelease.DateOfRelease = employee.DateOfRelease;

                context.SaveChanges();
            }

        }

    }
}
