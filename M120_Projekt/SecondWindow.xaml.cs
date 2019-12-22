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

namespace M120_Projekt
{
    /// <summary>
    /// Interaktionslogik für SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        Overview overview = new Overview();
        Movies movies = new Movies();
        Cinemas cinemas = new Cinemas();
        Profile profile = new Profile();
        //Login login = new Login();

        public bool isOverviewShown = false;
        public bool isMoviesShown = false;
        public bool isCinemasShown = false;
        public bool isProfileShown = false;

        public SecondWindow()
        {
            InitializeComponent();
        }

        private void SetButtonActive(Button toActiveColor, Button toDefaultColor, Button toDefaultColor2, Button toDefaultColor3)
        {
            if (toDefaultColor2 == null & toDefaultColor3 == null)
            {
                toDefaultColor.Background = new SolidColorBrush(Color.FromArgb(255, 106, 106, 106));
                toActiveColor.Background = new SolidColorBrush(Color.FromArgb(255, 151, 151, 151));
            }
            else
            {
                toDefaultColor.Background = new SolidColorBrush(Color.FromArgb(255, 106, 106, 106));
                toDefaultColor2.Background = new SolidColorBrush(Color.FromArgb(255, 106, 106, 106));
                toDefaultColor3.Background = new SolidColorBrush(Color.FromArgb(255, 106, 106, 106));
                toActiveColor.Background = new SolidColorBrush(Color.FromArgb(255, 151, 151, 151));
            }
        }

        private void SetBroderActive(Button toActiveBorder, Button toDefaultBorder, Button toDefaultBorder2, Button toDefaultBorder3)
        {
            LinearGradientBrush toActiveB = new LinearGradientBrush();

            toActiveB.StartPoint = new Point(1, 0.5);
            toActiveB.EndPoint = new Point(0, 0.5);
            toActiveB.GradientStops.Add(new GradientStop(Colors.Black, 1));
            toActiveB.GradientStops.Add(new GradientStop(Color.FromArgb(255, 151, 151, 151), 0.388));
            
            if (toDefaultBorder2 == null & toDefaultBorder3 == null)
            {
                toActiveBorder.BorderBrush = toActiveB;
                toDefaultBorder.BorderBrush = Brushes.Black;
            }
            else
            {
                toActiveBorder.BorderBrush = toActiveB;
                toDefaultBorder.BorderBrush = Brushes.Black;
                toDefaultBorder2.BorderBrush = Brushes.Black;
                toDefaultBorder3.BorderBrush = Brushes.Black;
            }
        }

        private void SetButtonActive(Button toActiveColor, Button toDefaultColor)
        {
            SetButtonActive(toActiveColor, toDefaultColor, null, null);
        }

        private void SetBroderActive(Button toActiveBorder, Button toDefaultBorder)
        {
            SetBroderActive(toActiveBorder, toDefaultBorder, null, null);
        }

        private void ShowOverview(object sender, RoutedEventArgs e)
        {
            Overview form = new Overview();
            

            SetBroderActive((sender as Button), MoviesB, CinemasB, ProfileB);
            SetButtonActive((sender as Button), MoviesB, CinemasB, ProfileB);


            if (isOverviewShown == true & isMoviesShown == false & isCinemasShown == false & isProfileShown == false)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isOverviewShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else if (isOverviewShown == false & isMoviesShown == true || isCinemasShown == true || isProfileShown == true)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isOverviewShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else
            {
                isOverviewShown = true;
                this.ViewContainer.Children.Add(form);
            }

        }

        private void ShowMovies(object sender, RoutedEventArgs e)
        {
            Movies form = new Movies();


            SetBroderActive((sender as Button), OverviewB, CinemasB, ProfileB);
            SetButtonActive((sender as Button), OverviewB, CinemasB, ProfileB);


            if (isMoviesShown == true & isOverviewShown == false & isCinemasShown == false & isProfileShown == false)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isMoviesShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else if (isMoviesShown == false & isOverviewShown == true || isCinemasShown == true || isProfileShown == true)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isMoviesShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else
            {
                isMoviesShown = true;
                this.ViewContainer.Children.Add(form);
            }

        }

        private void ShowCinemas(object sender, RoutedEventArgs e)
        {
            Cinemas form = new Cinemas();


            SetBroderActive((sender as Button), OverviewB, MoviesB, ProfileB);
            SetButtonActive((sender as Button), OverviewB, MoviesB, ProfileB);


            if (isCinemasShown == true & isMoviesShown == false & isOverviewShown == false & isProfileShown == false)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isCinemasShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else if (isCinemasShown == false & isMoviesShown == true || isOverviewShown == true || isProfileShown == true)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isCinemasShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else
            {
                isCinemasShown = true;
                this.ViewContainer.Children.Add(form);
            }

        }

        private void ShowProfile(object sender, RoutedEventArgs e)
        {
            Profile form = new Profile();


            SetBroderActive((sender as Button), OverviewB, MoviesB, CinemasB);
            SetButtonActive((sender as Button), OverviewB, MoviesB, CinemasB);


            if (isProfileShown == true & isMoviesShown == false & isCinemasShown == false & isOverviewShown == false)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isProfileShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else if (isProfileShown == false & isMoviesShown == true || isCinemasShown == true || isOverviewShown == true)
            {
                isOverviewShown = false;
                isMoviesShown = false;
                isCinemasShown = false;
                isProfileShown = false;
                this.ViewContainer.Children.RemoveAt(0);
                isProfileShown = true;
                this.ViewContainer.Children.Add(form);
            }
            else
            {
                isProfileShown = true;
                this.ViewContainer.Children.Add(form);
            }

        }

        private void LogoutClicked(object sender, RoutedEventArgs e)
        {

            MainWindow mainWin = new MainWindow();

            
            isOverviewShown = false;
            isMoviesShown = false;
            isCinemasShown = false;
            isProfileShown = false;


            mainWin.Show();
            this.Close();

        }

    }
}
