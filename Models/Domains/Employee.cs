using CompanyEmployeesWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;

namespace CompanyEmployeesWPF.Models.Domains
{
    public class Employee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Earnings { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfRelease { get; set; }

        public string Comments { get; set; }

        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
    }
        
}
