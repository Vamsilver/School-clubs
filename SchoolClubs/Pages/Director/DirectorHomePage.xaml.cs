using SchoolClubs.ADOApp;
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
using SchoolClubs.Pages.Director;

namespace SchoolClubs.Pages
{
    /// <summary>
    /// Логика взаимодействия для DirectorHomePage.xaml
    /// </summary>
    public partial class DirectorHomePage : Page
    {
        User director;
        public DirectorHomePage(User _director)
        {
            director = _director;
            InitializeComponent();
        }

        private void GoListTeacher(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListTeacherPage(director));
        }

        private void GoStatisticPage(object sender, RoutedEventArgs e)
        {

        }
        private void GoRaportPage(object sender, RoutedEventArgs e)
        {

        }
        private void GoListClub(object sender, RoutedEventArgs e)
        {

        }
        private void GoTimeTable(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut(object sender, RoutedEventArgs e)
        {

        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = director;

        }
    }
}
