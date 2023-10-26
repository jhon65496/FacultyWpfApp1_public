using FacultyWpfApp1.Data;
using FacultyWpfApp1.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FacultyWpfApp1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            DataContextApp dc = new DataContextApp();
            
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(dc);
            MainWindow mwindow = new MainWindow();
            mwindow.DataContext = mainWindowViewModel;
            mwindow.Show();
        }
    }
}
