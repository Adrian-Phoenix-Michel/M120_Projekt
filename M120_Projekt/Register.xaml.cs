using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data;

namespace M120_Projekt
{
    /// <summary>
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        private User myUser = new User();

        internal new User DataContext { get; private set; }
        public object Mail { get; set; }
       

        public Register()
        {
            InitializeComponent();
            this.DataContext = this.myUser;
        }

        public void Reset()
        {
            Username.Text = "";
            Email.Text = "";
            PasswordBox2.Password = "";
            TextBox2.Text = "";
            ConfirmPasswordBox.Password = "";
            ConfirmTextBox.Text = "";
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordCharsCheckBox2.IsChecked == true)
            {
                TextBox2.Text = PasswordBox2.Password;
                ConfirmTextBox.Text = ConfirmPasswordBox.Password;
            }

            if (Email.Text.Length == 0)
            {
                ErrorMessage.Visibility = Visibility.Visible;
                ErrorMessage.Background = Brushes.Yellow;
                ErrorMessage.Text = "Enter an email!";
                Email.Focus();
            }
            else if (!Regex.IsMatch(Email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                ErrorMessage.Visibility = Visibility.Visible;
                ErrorMessage.Background = Brushes.Yellow;
                ErrorMessage.Text = "Enter a valid email!";
                Email.Select(0, Email.Text.Length);
                Email.Focus();
            }
            else
            {
                string username = Username.Text;
                string email = Email.Text;
                string password = PasswordBox2.Password;
                if (PasswordBox2.Password.Length == 0)
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    ErrorMessage.Background = Brushes.Yellow;
                    ErrorMessage.Text = "Enter password!";
                    PasswordBox2.Focus();
                }
                else if (ConfirmPasswordBox.Password.Length == 0)
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    ErrorMessage.Background = Brushes.Yellow;
                    ErrorMessage.Text = "Enter Confirm password!";
                    ConfirmPasswordBox.Focus();
                }
                else if (PasswordBox2.Password != ConfirmPasswordBox.Password)
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    ErrorMessage.Background = Brushes.Yellow;
                    ErrorMessage.Text = "Confirm password must be same as password!";
                    ConfirmPasswordBox.Focus();
                }
                else
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    ErrorMessage.Background = Brushes.Green;
                    ErrorMessage.Text = "Adding your Profile...";
                    SqlConnection con = new SqlConnection("Data Source = BMWP2; Initial Catalog = M120_Database; Integrated Security = True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Users (Username,Email,Password) values('" + username + "','" + email + "','" + password + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ErrorMessage.Text = "You have Registered successfully.";
                    Reset();
                }
            }
        }

        private void ShowPasswordCharsCheckBox_Checked2(object sender, RoutedEventArgs e)
        {
            PasswordBox2.Visibility = System.Windows.Visibility.Collapsed;
            TextBox2.Visibility = System.Windows.Visibility.Visible;
            TextBox2.Text = PasswordBox2.Password;

            ConfirmPasswordBox.Visibility = System.Windows.Visibility.Collapsed;
            ConfirmTextBox.Visibility = System.Windows.Visibility.Visible;
            ConfirmTextBox.Text = ConfirmPasswordBox.Password;

            TextBox2.Focus();
            ConfirmTextBox.Focus();
        }

        private void ShowPasswordCharsCheckBox_Unchecked2(object sender, RoutedEventArgs e)
        {
            PasswordBox2.Visibility = System.Windows.Visibility.Visible;
            TextBox2.Visibility = System.Windows.Visibility.Collapsed;
            PasswordBox2.Password = TextBox2.Text;

            ConfirmPasswordBox.Visibility = System.Windows.Visibility.Visible;
            ConfirmTextBox.Visibility = System.Windows.Visibility.Collapsed;
            ConfirmPasswordBox.Password = ConfirmTextBox.Text;

            ConfirmPasswordBox.Focus();
            PasswordBox2.Focus();
        }
    }
}
