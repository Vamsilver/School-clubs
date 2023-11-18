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

namespace SchoolClubs.Pages.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherHomePage.xaml
    /// </summary>
    public partial class TeacherHomePage : Page
    {
        public TeacherHomePage()
        {
            InitializeComponent();
            var sections = App.Connection.Section.Where(x => x.idUser == App.CurrentUser.idUser).ToList();
            List<Group> groups = new List<Group>();
            foreach (var section in sections)
            {
                groups.Add(App.Connection.Group.FirstOrDefault(x => x.idSection == section.idSection));
            }
            List<Group_Student> group_Student = new List<Group_Student>();
            foreach (Group group in groups)
            {
                group_Student.Add(App.Connection.Group_Student.FirstOrDefault(x => x.idGroup == group.idGroup));
            }
            List<Raport_GroupStudent> raportGrStudents = new List<Raport_GroupStudent>();
            foreach (Group_Student group in group_Student)
            {
                raportGrStudents.Add(App.Connection.Raport_GroupStudent.FirstOrDefault(x => x.idGroup_Student == group.idGroup));
            }
            List<Raport> raports = new List<Raport>();
            foreach (Raport_GroupStudent groupt in raportGrStudents)
            {
                raports.Add(App.Connection.Raport.FirstOrDefault(x => x.idRaport == groupt.idRaport));
            }
            List<Timetable> list = new List<Timetable>();
            foreach (Raport raport in raports)
            {
                list.Add(App.Connection.Timetable.FirstOrDefault(x => x.idRaport == raport.idRaport));
            }

            if (list.Count > 0)
            {
                TimeTableLV.ItemsSource = list;
                NoRaportLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                TimeTableLV.Visibility = Visibility.Hidden;
                NoRaportLabel.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TeacherHomePageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.CurrentUser;
        }

        private void ButtonClubsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClubsPage());
        }

        private void EnrollStudentToClubBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnrollStudentToClubPage());
        }
    }
}
