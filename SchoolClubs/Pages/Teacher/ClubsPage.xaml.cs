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

namespace SchoolClubs.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for ClubsPage.xaml
    /// </summary>
    public partial class ClubsPage : Page
    {
        public ClubsPage()
        {
            InitializeComponent();
            ClubsLV.ItemsSource = App.Connection.Section.Where(x => x.idUser == App.CurrentUser.idUser).ToList();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.CurrentUser;
        }

        private void ClubsLVElementMouseDown(object sender, MouseButtonEventArgs e)
        {
            var id = (int)((TextBlock)sender).Tag;
            ADOApp.Section section = App.Connection.Section.FirstOrDefault(x => x.idSection == id);
            NavigationService.Navigate(new GroupsPage(section));
        }

        private void StudentsListButtonClick(object sender, RoutedEventArgs e)
        {
            if (ClubsLV.SelectedItem != null)
            {
                ADOApp.Section section = ClubsLV.SelectedItem as ADOApp.Section;
                NavigationService.Navigate(new GroupsPage(section));
            }
            else
            {
                MessageBox.Show("Выберите кружок из списка.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}