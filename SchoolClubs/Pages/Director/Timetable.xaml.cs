using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using SchoolClubs.AdoApp;
using SchoolClubs.Classes;
using static System.Collections.Specialized.BitVector32;

namespace SchoolClubs.Pages.Director
{
    /// <summary>
    /// Логика взаимодействия для Timetable.xaml
    /// </summary>
    public partial class Timetable : Page
    {
        public Timetable()
        {
            InitializeComponent();
            TimetableLV.ItemsSource = Calculate();
        }

        private void BtnAddLesson_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddLessonPage());
        }

        public List<TimetableEntity> Calculate()
        {
            var teachers = App.Connection.User.Where(x => x.idRole == 2).ToList();
            List<AdoApp.Section> sections = new List<AdoApp.Section>();
            List<TimetableEntity> timetableEntities = new List<TimetableEntity>();
            int number = 1;
            foreach (var teacher in teachers)
            {
                List<AdoApp.Section> sectionsListTemp = App.Connection.Section.Where(x => x.idUser == teacher.idUser).ToList();
                foreach (var section in sectionsListTemp)
                {
                    sections.Add(section);
                }
            }
            List<AdoApp.Group> groups = new List<AdoApp.Group>();
            foreach (var section in sections)
            {
                List<AdoApp.Group> groupsTemp = App.Connection.Group.Where(x => x.idSection == section.idSection).ToList();
                foreach (var group in groupsTemp)
                {
                    groups.Add(group);
                }
            }
            List<Group_Student> group_Student = new List<Group_Student>();
            foreach (AdoApp.Group group in groups)
            {
                List<Group_Student> groupsStudTemp = App.Connection.Group_Student.Where(x => x.idGroup == group.idGroup).ToList();
                foreach (var groupTemp in groupsStudTemp)
                {
                    group_Student.Add(groupTemp);
                }
            }
            List<Raport_GroupStudent> raportGrStudents = new List<Raport_GroupStudent>();
            foreach (Group_Student group in group_Student)
            {
                List<Raport_GroupStudent> groupsStudTemp = App.Connection.Raport_GroupStudent.Where(x => x.idGroup_Student == group.idGroup_Student).ToList();
                foreach (var groupTemp in groupsStudTemp)
                {
                    raportGrStudents.Add(groupTemp);
                }
            }
            List<Raport> raports = new List<Raport>();
            foreach (Raport_GroupStudent groupt in raportGrStudents)
            {
                List<Raport> groupsStudTemp = App.Connection.Raport.Where(x => x.idRaport == groupt.idRaport).ToList();
                foreach (var groupTemp in groupsStudTemp)
                {
                    raports.Add(groupTemp);
                }
            }
            List<AdoApp.Timetable> list = new List<AdoApp.Timetable>();
            foreach (Raport raport in raports)
            {
                List<AdoApp.Timetable> raportsList = App.Connection.Timetable.Where(x => x.idRaport == raport.idRaport).ToList();
                foreach (var timtable in raportsList)
                {
                    list.Add(timtable);
                }
            }
            List<AdoApp.Timetable> list2 = RemoveSearchDuplicates(list);
            foreach (AdoApp.Timetable timetable in list2)
            {
                TimetableEntity info = new TimetableEntity(timetable, number);
                timetableEntities.Add(info);
                number++;

            }

            if (timetableEntities.Count > 0)
            {
                return timetableEntities;
            }
            else
            {
                return null;
            }
        }
        private List<AdoApp.Timetable> RemoveSearchDuplicates(List<AdoApp.Timetable> grStList)
        {
            List<AdoApp.Timetable> TempList = new List<AdoApp.Timetable>();

            foreach (AdoApp.Timetable u1 in grStList)
            {
                bool duplicatefound = false;
                foreach (AdoApp.Timetable u2 in TempList)
                    if (u1.idTimetable == u2.idTimetable)
                        duplicatefound = true;

                if (!duplicatefound)
                    TempList.Add(u1);
            }
            return TempList;
        }
    }
}
