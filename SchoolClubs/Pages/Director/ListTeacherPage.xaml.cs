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
    /// Логика взаимодействия для ListTeacherPage.xaml
    /// </summary>
    public partial class ListTeacherPage : Page
    {
        User director;
        List<User> teacherList = new List<User>();


        public ListTeacherPage(User _director)
        {
            director = _director;
            
            //GridListTeacher.ItemsSource = teacherList;

            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            teacherList = App.Connection.User.Where(x => x.idRole == 2).ToList();
            this.DataContext = director;
            GridListTeacher.ItemsSource = teacherList;

        }

    }
}
