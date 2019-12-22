using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaktionslogik für Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {

        public Profile()
        {
            InitializeComponent();
        }

        private void ChangePasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Password.IsEnabled = true;
            PasswordText.IsEnabled = true;
            NewPassword.IsEnabled = true;
            NewPasswordText.IsEnabled = true;
            ConfirmNewPassword.IsEnabled = true;
            ConfirmNewPasswordText.IsEnabled = true;
        }

        private void ChangePasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Password.IsEnabled = false;
            PasswordText.IsEnabled = false;
            NewPassword.IsEnabled = false;
            NewPasswordText.IsEnabled = false;
            ConfirmNewPassword.IsEnabled = false;
            ConfirmNewPasswordText.IsEnabled = false;
        }

        private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Password.Visibility = System.Windows.Visibility.Collapsed;
            PasswordText.Visibility = System.Windows.Visibility.Visible;
            PasswordText.Text = Password.Password;

            NewPassword.Visibility = System.Windows.Visibility.Collapsed;
            NewPasswordText.Visibility = System.Windows.Visibility.Visible;
            NewPasswordText.Text = NewPassword.Password;

            ConfirmNewPassword.Visibility = System.Windows.Visibility.Collapsed;
            ConfirmNewPasswordText.Visibility = System.Windows.Visibility.Visible;
            ConfirmNewPasswordText.Text = ConfirmNewPassword.Password;
        }

        private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = System.Windows.Visibility.Collapsed;
            Password.Visibility = System.Windows.Visibility.Visible;
            Password.Password = PasswordText.Text;

            NewPasswordText.Visibility = System.Windows.Visibility.Collapsed;
            NewPassword.Visibility = System.Windows.Visibility.Visible;
            NewPassword.Password = NewPasswordText.Text;

            ConfirmNewPasswordText.Visibility = System.Windows.Visibility.Collapsed;
            ConfirmNewPassword.Visibility = System.Windows.Visibility.Visible;
            ConfirmNewPassword.Password = ConfirmNewPasswordText.Text;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordCharsCheckBox.IsChecked == true)
            {
                PasswordText.Text = Password.Password;
                NewPasswordText.Text = NewPassword.Password;
                ConfirmNewPasswordText.Text = ConfirmNewPassword.Password;
            }

            string username = Username.Text;
            string email = Email.Text;
            string password = Password.Password;
            string newpassword = NewPassword.Password;
            string confirmnewpassword = ConfirmNewPassword.Password;
            string dateofbirth = DateOfBirth.Text;
            string preferredlocation = PreferredLocation.Text;
            string preferredlanguage = PreferredLanguage.Text;

            if (ChangePasswordCharsCheckBox.IsChecked == false)
            {
                //ErrorMessage.Visibility = Visibility.Visible;
                //ErrorMessage.Background = Brushes.Green;
                //ErrorMessage.Text = "Updating your Profile...";
                SqlConnection con = new SqlConnection("Data Source = BMWP2; Initial Catalog = M120_Database; Integrated Security = True");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users (Username,Email,DateOfBirth,PreferredLocation,PreferredLanguage) SET Username='" + username + "',Email='" + email + "',DateOfBirth='" + dateofbirth + "',PreferredLocation='" + preferredlocation + "',PreferredLanguage='" + preferredlanguage + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                //ErrorMessage.Text = "Profile Update successful.";
            }
            else
            {

                if (NewPassword.Password.Length == 0)
                {
                    //ErrorMessage.Visibility = Visibility.Visible;
                    //ErrorMessage.Background = Brushes.Yellow;
                    //ErrorMessage.Text = "Enter password!";
                    NewPassword.Focus();
                }
                else if (ConfirmNewPassword.Password.Length == 0)
                {
                    //ErrorMessage.Visibility = Visibility.Visible;
                    //ErrorMessage.Background = Brushes.Yellow;
                    //ErrorMessage.Text = "Enter Confirm password!";
                    ConfirmNewPassword.Focus();
                }
                else if (NewPassword.Password != ConfirmNewPassword.Password)
                {
                    //ErrorMessage.Visibility = Visibility.Visible;
                    //ErrorMessage.Background = Brushes.Yellow;
                    //ErrorMessage.Text = "Confirm password must be same as password!";
                    ConfirmNewPassword.Focus();
                }
                else
                {
                    //ErrorMessage.Visibility = Visibility.Visible;
                    //ErrorMessage.Background = Brushes.Green;
                    //ErrorMessage.Text = "Updating your Profile...";
                    SqlConnection con = new SqlConnection("Data Source = BMWP2; Initial Catalog = M120_Database; Integrated Security = True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Users (Username,Email,Password,DateOfBirth,PreferredLocation,PreferredLanguage) SET Username='" + username + "',Email='" + email + "',Password='" + newpassword + "',DateOfBirth='" + dateofbirth + "',PreferredLocation='" + preferredlocation + "',PreferredLanguage='" + preferredlanguage + "'", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //ErrorMessage.Text = "Profile Update successful.";
                }
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            //Noch ein if machen der ein verlinkt ist zu ein anderes Fenster der "Are you sure?" fragt und ein Ja oder Nein-Knopf hat.

            //ErrorMessage.Visibility = Visibility.Visible;
            //ErrorMessage.Background = Brushes.Green;
            //ErrorMessage.Text = "Deleting your Profile...";
            SqlConnection con = new SqlConnection("Data Source = BMWP2; Initial Catalog = M120_Database; Integrated Security = True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Users", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            //ErrorMessage.Text = "Profile successfully deleted.";
        }

        private void Reset(object sender, RoutedEventArgs e)
        {

        }
    }
}
