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

namespace ToursCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainMainPage());
        }

        private void ToursBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ToursPage());
        }

        private void AccBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AccountPage());
        }

        private void HotelsBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HotelsPage());
        }

        private void MainBt_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainMainPage());
        }
    }
}
