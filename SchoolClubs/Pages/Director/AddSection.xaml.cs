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
    /// Логика взаимодействия для AddSection.xaml
    /// </summary>
    public partial class AddSection : Page
    {
        public AddSection()
        {
            InitializeComponent();
            CbSelectTeacher.ItemsSource = Calculate();
        }

        public List<TeacherInfo> Calculate()
        {
            var listTeachers = App.Connection.User.Where(x => x.idRole == 2).ToList();
            List<TeacherInfo> teacherInfos = new List<TeacherInfo>();

            foreach (var teacher in listTeachers)
            {
                teacherInfos.Add(new TeacherInfo(teacher));
            }
            return teacherInfos;

        }

        private void BtnAddClub_Click(object sender, RoutedEventArgs e)
        {
            if (TbClubName.Text != "" && CbSelectTeacher != null && TbDescription.Text != "" && int.TryParse(TbMinAge.Text, out int res))
            {
                AdoApp.Section section = new AdoApp.Section
                {
                    Title = TbClubName.Text,
                    minAge = Convert.ToInt32(TbMinAge.Text),
                    Description = TbDescription.Text,
                    LessonsAmount = 0,
                    idUser = (CbSelectTeacher.SelectedItem as TeacherInfo).User.idUser,
                };
                App.Connection.Section.Add(section);
                App.Connection.SaveChanges();
                MessageBox.Show("Кружок успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Проверьте корректность введенных данных", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
