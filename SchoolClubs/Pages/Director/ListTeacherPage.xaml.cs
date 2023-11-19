using SchoolClubs.ADOApp;
using SchoolClubs.Classes;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolClubs.Pages.Director
{
    /// <summary>
    /// Логика взаимодействия для ListTeacherPage.xaml
    /// </summary>
    public partial class ListTeacherPage : Page
    {
        User director;
        List<User> teacherList = new List<User>();
        TeachersClubs selectedTeacher;
        List<TeachersClubs> teacherClubsList = new List<TeachersClubs>();

        public ListTeacherPage(User _director)
        {
            director = _director;
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = director;
            CalcInfo();
        }

        private void CalcInfo()
        {
            teacherClubsList.Clear();
            teacherList = App.Connection.User.Where(x => x.idRole == 2).ToList();
            foreach (User user in teacherList)
            {
                teacherClubsList.Add(new TeachersClubs(user));
            }
            GridListTeacher.ItemsSource = teacherClubsList;
            GridListTeacher.Items.Refresh();
        }

        private void AddTeacher(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeacherPage(director));
        }

        private void DeleteTeacher(object sender, RoutedEventArgs e)
        {
            selectedTeacher = GridListTeacher.SelectedItem as TeachersClubs;
            try
            {
                if (selectedTeacher != null)
                {
                    var deleteUser = App.Connection.User.FirstOrDefault(x => x.idUser == selectedTeacher.idUser);
                    var deleteAuth = App.Connection.Authorization.FirstOrDefault(x => x.idAuthorization == selectedTeacher.idAuth);
                    App.Connection.User.Remove(deleteUser);
                    App.Connection.Authorization.Remove(deleteAuth);
                    App.Connection.SaveChanges();
                    MessageBox.Show("Учитель уволен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Выберите учителя для увольнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            CalcInfo();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DirectorHomePage(director));
        }
    }
}
