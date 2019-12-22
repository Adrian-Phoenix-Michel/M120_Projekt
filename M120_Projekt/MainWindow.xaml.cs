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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120_Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Register register = new Register();

        public bool isLoginShown = false;
        public bool isRegisterShown = false;

            public MainWindow()
        {
            InitializeComponent();
        }

        public void Exit()
        {
            this.Close();
        }

        public void StartingChild()
        {
            Login login = new Login();

            isLoginShown = true;
            this.ViewContainer.Children.Add(login);
        }

        public void CloseChild()
        {
            isLoginShown = false;
            this.ViewContainer.Children.RemoveAt(0);
        }

        private void SetButtonActive(Button toDefaultColor, Button toActiveColor)
        {
            toDefaultColor.Background = new SolidColorBrush(Color.FromArgb(255, 106, 106, 106));
            toActiveColor.Background = new SolidColorBrush(Color.FromArgb(255, 151, 151, 151));
        }

        private void SetBroderActive(Button toDefaultBorder, Button toActiveBorder)
        {
            LinearGradientBrush toActiveB = new LinearGradientBrush();

            toActiveB.StartPoint = new Point(1, 0.5);
            toActiveB.EndPoint = new Point(0, 0.5);
            toActiveB.GradientStops.Add(new GradientStop(Colors.Black, 1));
            toActiveB.GradientStops.Add(new GradientStop(Color.FromArgb(255, 151, 151, 151), 0.388));


            toActiveBorder.BorderBrush = toActiveB;


            toDefaultBorder.BorderBrush = Brushes.Black;
        }

        private void ShowLogin(object sender, RoutedEventArgs e)
        {
            Login form = new Login();
            Register rForm = new Register();

            SetBroderActive(RegisterB, (sender as Button));
            SetButtonActive(RegisterB, (sender as Button));

            rForm.Email.Text = form.Email.Text;


            if (isRegisterShown == true & isLoginShown == false)
            {
                isRegisterShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isLoginShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else if (isRegisterShown == false & isLoginShown == true)
            {
                isRegisterShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isLoginShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else
            {
                isLoginShown = true;
                this.ViewContainer.Children.Add(form);
            }

        }

        private void ShowRegister(object sender, RoutedEventArgs e)
        {
            Register form = new Register();
            Login lForm = new Login();

            SetBroderActive(LoginB, (sender as Button));
            SetButtonActive(LoginB, (sender as Button));

            lForm.Email.Text = form.Email.Text;


            if (isLoginShown == true & isRegisterShown == false)
            {
                isLoginShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isRegisterShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else if (isLoginShown == false & isRegisterShown == true)
            {
                isLoginShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isRegisterShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else
            {
                isRegisterShown = true;
                this.ViewContainer.Children.Add(form);
            }

        }
    }
}
