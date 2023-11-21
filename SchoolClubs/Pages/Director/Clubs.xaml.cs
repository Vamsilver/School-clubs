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
    /// Interaction logic for Clubs.xaml
    /// </summary>
    public partial class Clubs : Page
    {
        public Clubs()
        {
            InitializeComponent();
            LvClubs.ItemsSource = Calculate();

        }

        public List<TeacherSectionInfo> Calculate()
        {
            var teachers = App.Connection.User.Where(x => x.idRole == 2).ToList();
            var sections = App.Connection.Section.ToList();
            List<TeacherSectionInfo> teacherSectionInfos = new List<TeacherSectionInfo>();

            foreach (var section in sections)
            {
                teacherSectionInfos.Add(new TeacherSectionInfo(section));
            }
            return teacherSectionInfos;
        }

        private void BtnGroups_Click(object sender, RoutedEventArgs e)
        {
            //навигацию на список группы
        }

        private void BtnAddSection_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSection());
        }

        private void BtnChangeData_Click(object sender, RoutedEventArgs e)
        {
            if (LvClubs.SelectedItem != null)
            {
                NavigationService.Navigate(new ChangeDataClub(LvClubs.SelectedItem as TeacherSectionInfo));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите секцию", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnCreateGroup_Click(object sender, RoutedEventArgs e)
        {
            var id = (int)((Button)sender).Tag;
            ADOApp.Section section = App.Connection.Section.FirstOrDefault(x => x.idSection == id);
            NavigationService.Navigate(new AddGroupPage(section));
        }
    }
}
