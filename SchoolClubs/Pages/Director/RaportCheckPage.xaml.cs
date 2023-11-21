using SchoolClubs.ADOApp;
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
    /// Interaction logic for RaportCheckPage.xaml
    /// </summary>
    public partial class RaportCheckPage : Page
    {
        User director;
        public List<ADOApp.Timetable> timetableList;
        public List<Group> groupList;
        public List<Raport_GroupStudent> raportGroupStudentsList;
        public List<Group_Student> groupStudentsList;
        public DateTime currDate;
        TimeSpan time;
        List<RaportCheckDirector> raportCheckDirectors = new List<RaportCheckDirector>();
        public RaportCheckPage(User _director)
        {
            director = _director;
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DirectorHomePage());
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //RaportList.ItemsSource = null;
            currDate = Convert.ToDateTime(date.Text);
            timetableList = App.Connection.Timetable.Where(x => x.Date == currDate).ToList();
            foreach (var timetable in timetableList)
            {
                time = timetable.Time;
                raportGroupStudentsList = App.Connection.Raport_GroupStudent.Where(x => x.idRaport == timetable.idRaport && x.idRaportStatus == 2).ToList();
                raportCheckDirectors.Add(new RaportCheckDirector(raportGroupStudentsList, time));
            }
            RaportList.ItemsSource = raportCheckDirectors;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = director;
        }
    }
}