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
                _auth = new Authorization(txtLogin.Text, txtPass.Text);
                App.Connection.Authorization.Add(_auth);
                _teacher = new User(txtName.Text, txtSurname.Text, txtPatronymic.Text, Convert.ToDateTime(date.Text), decimal.Parse(txtExperience.Text), _auth.idAuthorization);


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
    }
}
