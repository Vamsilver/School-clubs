using SchoolClubs.BD;
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

namespace SchoolClubs.Pages
{
    /// <summary>
    /// Логика взаимодействия для EnrollStudentToClubPage.xaml
    /// </summary>
    public partial class EnrollStudentToClubPage : Page
    {
        public EnrollStudentToClubPage()
        {
            InitializeComponent();
            ClassCB.ItemsSource = App.connection.Class.ToList();
            PupilCB.ItemsSource = App.connection.Student.ToList();
            ClubCB.ItemsSource = App.connection.Section.Where(x => x.idUser == App.currentUser.idUser).ToList();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.currentUser;
        }

        private void ClassCBSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClassCB.Text != null)
            {
                try
                {
                    var id = (ClassCB.SelectedItem as Class).idClass;
                    PupilCB.ItemsSource = App.connection.Student.Where(x => x.idClass == id).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}", "Неудачно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ClubCBSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClubCB.Text != null)
            {
                try
                {
                    var id = (ClubCB.SelectedItem as BD.Section).idSection;
                    GroupCB.ItemsSource = App.connection.Group.Where(x => x.idSection == id).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}", "Неудачно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void EnrollStudentToClubBtnClick(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrEmpty(ClubCB.Text) || String.IsNullOrEmpty(PupilCB.Text) ||
               String.IsNullOrEmpty(GroupCB.Text) || String.IsNullOrEmpty(ClassCB.Text))
            {
                MessageBox.Show($"Заполните данные корректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            Student student = PupilCB.SelectedItem as Student;
            Group group = GroupCB.SelectedItem as Group;
            Group_Student grStudLast = App.connection.Group_Student.Where(x => x.idStudent == student.idStudent && x.idGroup == group.idGroup).ToList().LastOrDefault();

            if (grStudLast != null && grStudLast.idStudentStatus == 1)
            {
                MessageBox.Show($"Ученик уже есть в этой группе", "Неудачно", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Group_Student grStudent = new Group_Student();
            grStudent.idStudentStatus = 1;
            grStudent.idStudent = student.idStudent;
            grStudent.idGroup = group.idGroup;
            grStudent.Date = DateTime.Now.Date;
            App.connection.Group_Student.Add(grStudent);
            App.connection.SaveChanges();
            MessageBox.Show($"Вы успешно добавили ученика в группу", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
