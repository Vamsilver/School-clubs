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
    /// Interaction logic for AddGroupPage.xaml
    /// </summary>
    public partial class AddGroupPage : Page
    {
        ADOApp.Section section;
        public AddGroupPage(ADOApp.Section _section)
        {
            InitializeComponent();
            section = _section;
        }

        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(GroupNameTB.Text))
            {
                MessageBox.Show("Введите название группы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else
            {
                ADOApp.Group group = new ADOApp.Group();
                group.Name = GroupNameTB.Text;
                group.idSection = section.idSection;
                App.Connection.Group.Add(group);
                App.Connection.SaveChanges();
                MessageBox.Show("Вы успешно создали группу", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                BtnSave.IsEnabled = false;
            }
        }
    }
}
