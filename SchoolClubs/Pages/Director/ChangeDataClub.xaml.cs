using SchoolClubs.AdoApp;
using SchoolClubs.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для ChangeDataClub.xaml
    /// </summary>
    public partial class ChangeDataClub : Page
    {
        private TeacherSectionInfo _teacherSectionInfo;
        public ChangeDataClub(TeacherSectionInfo teacherSectionInfo)
        {
            
            InitializeComponent();
            _teacherSectionInfo = teacherSectionInfo;
            TbClubName.Text = teacherSectionInfo.Section.Title;
            TbDescription.Text = teacherSectionInfo.Section.Description;
            TbMinAge.Text = teacherSectionInfo.Section.minAge.ToString();
            TbClubName.IsEnabled = false;
            TbDescription.IsEnabled = false;
            TbMinAge.IsEnabled = false;
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CbSelectTeacher.SelectedItem != null)
            {
                var currSection = _teacherSectionInfo.Section;
                var currTeacherId = currSection.idUser;

                var changeData = App.Connection.Section.Where(x => x.idUser == currTeacherId).FirstOrDefault();
                var selItem = CbSelectTeacher.SelectedItem as TeacherInfo;
                var selTeacher = selItem.User;

                changeData.idUser = selTeacher.idUser;
                App.Connection.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите учителя", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
