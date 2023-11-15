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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolClubs.Pages.Teacher
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        Group _group;
        public StudentsPage(Group group)
        {
            InitializeComponent();
            _group = group;
            List<StudentInfo> studentsInfos = new List<StudentInfo>();
            List<Group_Student> studentsInGroup = RemoveSearchDuplicates(App.connection.Group_Student.Where(x => x.idGroup == group.idGroup).ToList());
            List<Student> students = new List<Student>();
            int number = 1;
            foreach(Group_Student grSt in studentsInGroup)
            {
                Student student  = App.connection.Student.FirstOrDefault(x => x.idStudent == grSt.idStudent);
                
                StudentInfo studentInfo = new StudentInfo(student, number);
                studentsInfos.Add(studentInfo);
                number++;
            }
            StudentsLV.ItemsSource = studentsInfos;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.currentUser;
        }
        private List<Group_Student> RemoveSearchDuplicates(List<Group_Student> grStList)
        {
            List<Group_Student> TempList = new List<Group_Student>();

            foreach (Group_Student u1 in grStList)
            {
                bool duplicatefound = false;
                foreach (Group_Student u2 in TempList)
                    if (u1.idStudent == u2.idStudent)
                        duplicatefound = true;

                if (!duplicatefound)
                    TempList.Add(u1);
            }
            return TempList;
        }

        private void EnrollStudentToClubPage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnrollStudentToClubPage());
        }

        private void SaveChangesBtnClick(object sender, RoutedEventArgs e)
        {
            foreach (StudentInfo stInfo in StudentsLV.ItemsSource)
            {
                Group_Student grStud = App.connection.Group_Student.Where(x => x.idStudent == stInfo.student.idStudent && x.idGroup == _group.idGroup).ToList().LastOrDefault();
                bool isInGroup = false;
                if (grStud.idStudentStatus == 1)
                    isInGroup = true;

                if (stInfo.isInGroup != isInGroup)
                {
                    Group_Student grStudent = new Group_Student();
                    grStudent.idGroup = _group.idGroup;
                    grStudent.idStudentStatus = stInfo.isInGroup ? 1 : 2;
                    grStudent.idStudent = grStud.idStudent;
                    grStudent.Date = DateTime.Now.Date;
                    App.connection.Group_Student.Add(grStudent);
                    App.connection.SaveChanges();
                    MessageBox.Show("Вы успешно сохранили данные", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void HyperlinkClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupsPage(_group.Section));
        }
    }
}
