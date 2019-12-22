using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace M120_Projekt
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow mainWin1 = new MainWindow();
            Login login = new Login();

            //(MainWindow)Application.Current.MainWindow

            base.OnStartup(e);

            mainWin1.LoginB.IsEnabled = true;
            mainWin1.isLoginShown = true;
            mainWin1.ViewContainer.Children.Add(login);

        }
    }
}
