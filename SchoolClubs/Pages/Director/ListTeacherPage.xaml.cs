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

namespace SchoolClubs.Pages.Director
{
    /// <summary>
    /// Interaction logic for ListTeacherPage.xaml
    /// </summary>
    public partial class ListTeacherPage : Page
    {
        User director;
        List<User> teacherList = new List<User>();
        List<ADOApp.Section> sectionList = new List<ADOApp.Section>();
        User selectedTeacher;
        String _sections = "";
        int _count = 0;


        public ListTeacherPage(User _director)
        {
            director = _director;

            //GridListTeacher.ItemsSource = teacherList;

            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = director;
            CalcInfo();
        }

        private void CalcInfo()
        {
            _sections = "";
            _count = 0;
            teacherList = App.Connection.User.Where(x => x.idRole == 2).ToList();
            foreach (User user in teacherList)
            {
                sectionList = App.Connection.Section.Where(x => x.idUser == user.idUser).ToList();
                foreach (ADOApp.Section section in sectionList)
                {
                    _sections += section.Title + Environment.NewLine;
                    _count += App.Connection.Group_Student.Where(x => x.Group.idSection == section.idSection).Count();

                }
                //user.sections = _sections;
                //user.CountStudents = _count;
                _sections = "";
                _count = 0;
            }

            GridListTeacher.ItemsSource = teacherList;
        }

        private void AddTeacher(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeacherPage(director));
        }



        private void DeleteTeacher(object sender, RoutedEventArgs e)
        {
            selectedTeacher = GridListTeacher.SelectedItem as User;
            try
            {
                selectedTeacher = GridListTeacher.SelectedItem as User;
                if (selectedTeacher != null)
                {
                    var deleteService = App.Connection.User.FirstOrDefault(x => x.idUser == selectedTeacher.idUser);

                    App.Connection.User.Remove(deleteService);
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
    }
}
