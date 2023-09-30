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
using ToursCompany.Components.Partials;

namespace ToursCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegBt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var check = App.db.User.FirstOrDefault(x => x.Login == LogiTb.Text);
                if (string.IsNullOrEmpty(LogiTb.Text))
                {
                    MessageBox.Show("Заполните поле логина", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(PasTb.Text))
                {
                    MessageBox.Show("Заполните поле пароля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(FnameTb.Text))
                {
                    MessageBox.Show("Заполните поле фамилии", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (string.IsNullOrEmpty(NameTb.Text))
                {
                    MessageBox.Show("Заполните поле имени", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (check == null)
                {
                    User user = new User
                    {
                        Login = LogiTb.Text,
                        Password = PasTb.Text,
                        FName = FnameTb.Text,
                        Name= NameTb.Text,
                        RoleId = 2

                    };
                    App.db.User.Add(user);
                    App.db.SaveChanges();
                    MessageBox.Show("Регистрация выполнена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    LogiTb.Text = " ";
                    PasTb.Text = " ";
                    FnameTb.Text = " ";
                    NameTb.Text = " ";


                }
                else
                {
                    MessageBox.Show("Пользователь уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AuthBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void FnameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if(!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void NameTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetter(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
