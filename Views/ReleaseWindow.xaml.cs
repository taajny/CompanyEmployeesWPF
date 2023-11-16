using MahApps.Metro.Controls;
using CompanyEmployeesWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Web.UI.WebControls;
using CompanyEmployeesWPF.Models.Domains;

namespace CompanyEmployeesWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ReleaseWindow.xaml
    /// </summary>
    public partial class ReleaseWindow : MetroWindow
    {
        public ReleaseWindow(Employee employee = null)
        {
            InitializeComponent();
            DataContext = new ReleaseWindowViewModel(employee);
        }
    }
}
