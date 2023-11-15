using SchoolClubs.BD;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
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
            var sections = App.connection.Section.Where(x => x.idUser == App.currentUser.idUser).ToList();
            List<Group> groups = new List<Group>();
            List<TimetableInfo> listInfos = new List<TimetableInfo>();
            int number = 1;
            foreach (var section in sections)
            {
                groups.Add(App.connection.Group.FirstOrDefault(x => x.idSection == section.idSection));
            }
            List<Group_Student> group_Student = new List<Group_Student>();
            foreach (Group group in groups)
            {
                group_Student.Add(App.connection.Group_Student.FirstOrDefault(x => x.idGroup == group.idGroup));
            }
            List<Raport_GroupStudent> raportGrStudents = new List<Raport_GroupStudent>();
            foreach (Group_Student group in group_Student)
            {
                Raport_GroupStudent rGrStudTemp = App.connection.Raport_GroupStudent.FirstOrDefault(x => x.idGroup_Student == group.idGroup);
                if (rGrStudTemp != null)
                {
                    raportGrStudents.Add(rGrStudTemp);
                }
            }
            List<Raport> raports = new List<Raport>();
            foreach (Raport_GroupStudent groupt in raportGrStudents)
            {
                raports.Add(App.connection.Raport.FirstOrDefault(x => x.idRaport == groupt.idRaport));
            }
            List<Timetable> list = new List<Timetable>();
            foreach (Raport raport in raports)
            {
                list.Add(App.connection.Timetable.FirstOrDefault(x => x.idRaport == raport.idRaport));
            }
            foreach(Timetable timetable in list)
            {
                TimetableInfo info = new TimetableInfo(timetable, number);
                listInfos.Add(info);
                number++; 

            }
            if (listInfos.Count > 0)
            {
                TimeTableLV.ItemsSource = listInfos;
                NoRaportLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                TimeTableLV.Visibility = Visibility.Hidden;
                NoRaportLabel.Visibility = Visibility.Visible;
            }
        }

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void TeacherHomePageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.currentUser;
        }

        private void ButtonClubsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClubsPage());
        }

        private void EnrollStudentToClubBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnrollStudentToClubPage());
        }

        private void ChangeRaportInfoBtnClick(object sender, RoutedEventArgs e)
        {
            if(TimeTableLV.SelectedItem != null)
            {
                TimetableInfo timetableInfo = TimeTableLV.SelectedItem as TimetableInfo;
                if (timetableInfo.timetable.isRaportCreated == true)
                {
                    MessageBox.Show("На данный урок уже создана рапортичка!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    NavigationService.Navigate(new ChangeRaportInfo(timetableInfo.timetable));
                }
            }
            else
            {
                MessageBox.Show("Выберите расписание, для которого ходите создать рапортичку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LabelMouseDown(object sender, MouseButtonEventArgs e)
        {
            int id = (int)((TextBlock)sender).Tag;
            Timetable timetable = App.connection.Timetable.FirstOrDefault(x => x.idTimetable == id);
            if(timetable.isRaportCreated == true)
            {
                MessageBox.Show("На данный урок уже создана рапортичка!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                NavigationService.Navigate(new ChangeRaportInfo(timetable));

            }
        }
    }
}
