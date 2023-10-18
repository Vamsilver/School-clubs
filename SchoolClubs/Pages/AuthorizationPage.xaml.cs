using System;
using System.Collections.Generic;
using System.Data;
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
using SchoolClubs.Pages.Teacher;

namespace SchoolClubs.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            var data = App.Connection.Authorization.Where(z => z.Login == LoginTextBox.Text && z.Password == PasswordTextBox.Password).FirstOrDefault();
            
            if (data != null)
            {
                var user = App.Connection.User.Where(z => z.idAuthorization == data.idAuthorization).FirstOrDefault();
                MessageBox.Show("Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                
                if (user.idRole == 1)
                {
                    NavigationService.Navigate(new DirectorHomePage(user));
                }
                else 
                {
                    NavigationService.Navigate(new TeacherHomePage());
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
