using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using SchoolClubs.ADOApp;

namespace SchoolClubs.Pages.Director
{
    /// <summary>
    /// Логика взаимодействия для AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        User director;
        User _teacher;
        Authorization _auth;
        public AddTeacherPage(User _director)
        {
            director = _director;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = director;
        }

        private void SaveTeacher(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtName.Text == "" || txtSurname.Text == "" || txtPatronymic.Text == "" || txtExperience.Text == "" ||
                txtLogin.Text == "" || txtPass.Text == "" || date == null)
                {
                    MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var log = App.Connection.Authorization.Where(x => x.Login == txtLogin.Text).FirstOrDefault();
                if (log != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _auth = new Authorization();
                _auth.Login = txtLogin.Text;
                _auth.Password = txtPass.Text;
                App.Connection.Authorization.Add(_auth);

                _teacher = new User();
                _teacher.Name = txtName.Text;
                _teacher.Surname = txtSurname.Text;
                _teacher.Patronymic = txtPatronymic.Text;
                _teacher.Birthdate = Convert.ToDateTime(date.Text);
                _teacher.Experience = decimal.Parse(txtExperience.Text);
                _teacher.idAuthorization = _auth.idAuthorization;
                _teacher.idRole = 2;
                App.Connection.User.Add(_teacher);

                App.Connection.SaveChanges();
                MessageBox.Show("Добавление прошло успешно!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new ListTeacherPage(director));
            }
            catch {
                MessageBox.Show("ОШИБКА", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DirectorHomePage(director));
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListTeacherPage(director));
        }
    }
}
