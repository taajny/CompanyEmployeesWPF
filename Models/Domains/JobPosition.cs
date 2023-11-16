using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployeesWPF.Models.Domains
{
    public class JobPosition
    {
        public JobPosition()
        {
            Employees = new Collection<Employee>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set;}
    }
}
