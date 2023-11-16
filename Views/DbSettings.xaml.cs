using System;
using CompanyEmployeesWPF.ViewModels;
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
using MahApps.Metro.Controls;

namespace CompanyEmployeesWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DbSettings.xaml
    /// </summary>
    public partial class DbSettings : MetroWindow
    {
        public DbSettings()
        {
            InitializeComponent();
            DataContext = new DbSettingsViewModel();
        }
    }
}
