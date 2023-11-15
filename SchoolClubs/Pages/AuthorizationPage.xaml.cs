using SchoolClubs.BD;
using SchoolClubs.Pages.Teacher;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Authorization temp = App.connection.Authorization.First(x => x.Login == LoginTextBox.Text && x.Password == PasswordTextBox.Text);
            if (temp != null)
            {
                User user = App.connection.User.First(x => x.idAuthorization == temp.idAuthorization);
                App.currentUser = user;
                NavigationService.Navigate(new TeacherHomePage());
            }
        }
    }
}
