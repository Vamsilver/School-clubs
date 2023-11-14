using SchoolClubs.BD;
using SchoolClubs.Classes;
using System;
using System.Collections;
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
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        public GroupsPage(BD.Section section)
        {
            InitializeComponent();
            List<Group> groups = App.connection.Group.Where(x => x.idSection == section.idSection).ToList();
            List<GroupClass> groupsClasses = new List<GroupClass>();
            int number = 1;
            foreach (Group group in groups) 
            {
                List<Group_Student> grStudentsList = App.connection.Group_Student.Where(x => x.idGroup == group.idGroup).ToList();
                List<Group_Student> grStudentsListModified = RemoveSearchDuplicates(grStudentsList);
                GroupClass grClass = new GroupClass(group, grStudentsListModified.Count, number);
                groupsClasses.Add(grClass);
                number++;
            }

            if (groupsClasses.Count > 0)
            {
                GroupsLV.ItemsSource = groupsClasses;
            }
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.currentUser;
        }

        private void GroupsLVElementMouseDown(object sender, MouseButtonEventArgs e)
        {
            int id = (int)((TextBlock)sender).Tag;
            Group group = App.connection.Group.FirstOrDefault(x => x.idGroup == id);
            NavigationService.Navigate(new StudentsPage(group));
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
    }
}
