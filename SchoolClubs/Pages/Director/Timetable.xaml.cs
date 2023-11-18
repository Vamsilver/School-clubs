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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolClubs.Pages.Director
{
    /// <summary>
    /// Interaction logic for Timetable.xaml
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
            List<ADOApp.Section> sections = new List<ADOApp.Section>();
            List<TimetableEntity> timetableEntities = new List<TimetableEntity>();
            int number = 1;
            foreach (var teacher in teachers)
            {
                List<ADOApp.Section> sectionsListTemp = App.Connection.Section.Where(x => x.idUser == teacher.idUser).ToList();
                foreach (var section in sectionsListTemp)
                {
                    sections.Add(section);
                }
            }
            List<ADOApp.Group> groups = new List<ADOApp.Group>();
            foreach (var section in sections)
            {
                List<ADOApp.Group> groupsTemp = App.Connection.Group.Where(x => x.idSection == section.idSection).ToList();
                foreach (var group in groupsTemp)
                {
                    groups.Add(group);
                }
            }
            List<Group_Student> group_Student = new List<Group_Student>();
            foreach (ADOApp.Group group in groups)
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
            List<ADOApp.Timetable> list = new List<ADOApp.Timetable>();
            foreach (Raport raport in raports)
            {
                List<ADOApp.Timetable> raportsList = App.Connection.Timetable.Where(x => x.idRaport == raport.idRaport).ToList();
                foreach (var timtable in raportsList)
                {
                    list.Add(timtable);
                }
            }
            List<ADOApp.Timetable> list2 = RemoveSearchDuplicates(list);
            foreach (ADOApp.Timetable timetable in list2)
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
        private List<ADOApp.Timetable> RemoveSearchDuplicates(List<ADOApp.Timetable> grStList)
        {
            List<ADOApp.Timetable> TempList = new List<ADOApp.Timetable>();

            foreach (ADOApp.Timetable u1 in grStList)
            {
                bool duplicatefound = false;
                foreach (ADOApp.Timetable u2 in TempList)
                    if (u1.idTimetable == u2.idTimetable)
                        duplicatefound = true;

                if (!duplicatefound)
                    TempList.Add(u1);
            }
            return TempList;
        }
    }
}

