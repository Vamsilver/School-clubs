using SchoolClubs.AdoApp;
using SchoolClubs.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddLessonPage.xaml
    /// </summary>
    public partial class AddLessonPage : Page
    {
        public AddLessonPage()
        {
            var teachers = App.Connection.User.Where(x => x.idRole == 2).ToList();
            var sections = App.Connection.Section.ToList();
            var groups = App.Connection.Group.ToList();

            InitializeComponent();
            SelectTeacher.ItemsSource = teachers;
            

        }

        private void AddLessonBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int minutes = Convert.ToInt32(CbHours.Text) * 60 + Convert.ToInt32(CbMinutes.Text);

                var currTeacher = (User)SelectTeacher.SelectedItem;
                Raport raport = new Raport();
                App.Connection.Raport.Add(raport);
                App.Connection.SaveChanges();
                Group gr = SelectGroup.SelectedItem as Group;
                var listGroupStud = App.Connection.Group_Student.Where(x => x.idGroup == gr.idGroup).ToList();
                List<Group_Student> listGroupStudFinal = new List<Group_Student>();
                foreach(var grStud in listGroupStud)
                {
                    var grStudent = App.Connection.Group_Student.Where(x => x.idStudent == grStud.idStudent).ToList().LastOrDefault();
                    if (grStudent.idStudentStatus == 1)
                    {
                        listGroupStudFinal.Add(grStud);
                    }
                }

                foreach (var lol in listGroupStudFinal)
                {
                    Raport_GroupStudent rGrStud = new Raport_GroupStudent();
                    rGrStud.idRaport = raport.idRaport;
                    rGrStud.idGroup_Student = lol.idGroup_Student;
                    rGrStud.idRaportStatus = 2;
                    App.Connection.Raport_GroupStudent.Add(rGrStud);
                    App.Connection.SaveChanges();
                }

                App.Connection.Timetable.Add(new AdoApp.Timetable
                {
                    Date = (DateTime)DpDate.SelectedDate,
                    Duration = TimeSpan.FromMinutes(90),
                    Time = TimeSpan.FromMinutes(minutes),
                    idRaport = raport.idRaport,
                    isRaportCreated = false,
                });
                App.Connection.SaveChanges();
                MessageBox.Show("Урок успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new Pages.Director.Timetable());
            }
            catch
            {
                MessageBox.Show("Пожалуйста, проверьте корректонсть введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void SelectTeacherSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currTeacher = (User)SelectTeacher.SelectedItem;
            var sections = App.Connection.Section.Where(x => x.idUser == currTeacher.idUser).ToList();
            SelectClub.ItemsSource = sections;
        }

        private void SelectClubSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AdoApp.Section section = SelectClub.SelectedItem as AdoApp.Section;
            if (section != null)
            {
                SelectGroup.ItemsSource = App.Connection.Group.Where(x => x.idSection == section.idSection).ToList();
            }
        }
    }
}
