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
using ToursCompany.Components;

namespace ToursCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        public ToursPage()
        {
            InitializeComponent();
            SortCb.Items.Add("все");
            SortCb.Items.Add("По цене мин.");
            SortCb.Items.Add("По цене макс.");
        }
        private void Refresh()
        {
            var tour = App.db.Tour.ToList();
          
            if (SortCb.SelectedIndex == 1)
            {
                tour = tour.OrderBy(x => x.Price).ToList();
            }
            if (SortCb.SelectedIndex == 2)
            {
                tour = tour.OrderByDescending(x => x.Price).ToList();
            }
            ToursList.ItemsSource = tour;
        }

       

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var selTour = (sender as Button).DataContext as Tour;
            App.db.Tour.Remove(selTour);
            App.db.SaveChanges();
            Refresh();

        }

        private void LookBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
