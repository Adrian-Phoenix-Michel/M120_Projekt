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
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace M120_Projekt
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        internal new User DataContext { get; private set; }
        
        public Login()
        {
            InitializeComponent();
            this.DataContext = this.myUser;
        }

        MainWindow mainWin1 = (MainWindow)Application.Current.MainWindow;
        SecondWindow secWin = new SecondWindow();
        Overview overview = new Overview();
        Profile profile = new Profile();
        private User myUser = new User();
        public string username;
        //Register register = new Register();


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordCharsCheckBox1.IsChecked == true)
            {
                TextBox1.Text = PasswordBox1.Password;
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
                string email = Email.Text;
                string password = PasswordBox1.Password;
                SqlConnection con = new SqlConnection("Data Source = BMWP2; Initial Catalog = M120_Database; Integrated Security = True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Users where Email='" + email + "'  and Password='" + password + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    username = dataSet.Tables[0].Rows[0]["Username"].ToString();

                    profile.Username.Text = username;

                    overview.UserName.Text = username;
                    
                    secWin.Show();

                    mainWin1.Close();
                }
                else
                {
                    ErrorMessage.Visibility = Visibility.Visible;
                    ErrorMessage.Background = Brushes.Red;
                    ErrorMessage.Text = "Sorry! Please enter existing email and/or password!";
                }
                con.Close();
            }
            
        /*MainWindow mainWin2 = (MainWindow)Application.Current.MainWindow;
        SecondWindow secWin = new SecondWindow();

        mainWin2.Close();
        secWin.Show();*/
        
        }

        private void ShowPasswordCharsCheckBox_Checked1(object sender, RoutedEventArgs e)
        {
            PasswordBox1.Visibility = System.Windows.Visibility.Collapsed;
            TextBox1.Visibility = System.Windows.Visibility.Visible;
            TextBox1.Text = PasswordBox1.Password;

            TextBox1.Focus();
        }

        private void ShowPasswordCharsCheckBox_Unchecked1(object sender, RoutedEventArgs e)
        {
            PasswordBox1.Visibility = System.Windows.Visibility.Visible;
            TextBox1.Visibility = System.Windows.Visibility.Collapsed;
            PasswordBox1.Password = TextBox1.Text;

            PasswordBox1.Focus();
        }
    }
}
