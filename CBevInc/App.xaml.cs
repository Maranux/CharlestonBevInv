using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CBevInc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainWindow window = new MainWindow();
        void App_Startup(object sender, StartupEventArgs e)
        {
            window.Show();
        }
    }
}
