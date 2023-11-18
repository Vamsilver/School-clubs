using SchoolClubs.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Collections.Specialized.BitVector32;

namespace SchoolClubs.Pages
{
    /// <summary>
    /// Interaction logic for TeacherStatisticsPage.xaml
    /// </summary>
    public partial class TeacherStatisticsPage : Page
    {
        public List<Timetable> timeTables = new List<Timetable>();
        public TeacherStatisticsPage()
        {
            InitializeComponent();

            DateStartDataPicker.SelectedDate = new DateTime(DateTime.Now.Year, 9,1);
            DateEndDataPicker.SelectedDate = DateTime.Now;

            //var list = App.Connection.Section.Where(z => z.idUser.Equals(App.currentUser.idUser)).ToList();
            List<ADOApp.Section> list2 = App.Connection.Section.Where(z => z.idUser == 2).ToList();

            ClubsComboBox.ItemsSource = list2;
            ClubsComboBox.SelectedItem = list2.ElementAt(0);

            LoadStudentAttendance();
            LoadClassAttendance();
            LoadLessonsTaught();
        }

        private void LoadStudentAttendance()
        {
            var list = new List<StudentAttendanceView>();

            list.Add(new StudentAttendanceView("Шайхутдинов Б. А.", 100));
            list.Add(new StudentAttendanceView("Шайхутдинов Б. А.", 55));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Габдрахманов Б. А.", 30));
            list.Add(new StudentAttendanceView("Привет Я. П.", 30));

            StudentAttendanceListView.ItemsSource = list;
        }

        private void LoadClassAttendance()
        {
            ((PieSeries)ClassAttendanceChart.Series[0]).ItemsSource =
            new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string,int>("Отсутсвовали", 25),
                new KeyValuePair<string,int>("Присутсвовали", 75),
            };
        }

        private void LoadLessonsTaught()
        {
            if(DateStartDataPicker.SelectedDate == null && DateEndDataPicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату");
                return;
            }

            if(ClubsComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберете кружок");
                return; 
            }

            ADOApp.Section selectedSection = ClubsComboBox.SelectedItem as ADOApp.Section;

            List<Group> groups = App.Connection.Group.Where(z => z.idSection.Equals(selectedSection.idSection)).ToList();

            List<Group_Student> groupStudents = new List<Group_Student>();

            foreach (var group in groups)
            {
                groupStudents.Add(App.Connection.Group_Student.FirstOrDefault(z => z.idGroup.Equals(group.idGroup) && z.idStudentStatus.Equals(1)));
            }

            List<Raport_GroupStudent> raportGroupStudents = new List<Raport_GroupStudent>();

            foreach (var groupStudent in groupStudents)
            {
                raportGroupStudents.Add(App.Connection.Raport_GroupStudent.FirstOrDefault(z => z.idGroup_Student.Equals(groupStudent.idGroup_Student)));
            }

            List<Raport> raports = new List<Raport>();

            foreach (var raportGroupStudent in raportGroupStudents)
            {
                raports.Add(App.Connection.Raport.FirstOrDefault(z => z.idRaport_GroupStudent.Equals(raportGroupStudent.idRaport_GroupStudent)));
            }

            foreach(var raport in raports)
            {
                timeTables.Add(App.Connection.Timetable.FirstOrDefault(z => z.idRaport.Equals(raport.idRaport) && z.Date < DateEndDataPicker.SelectedDate && z.Date > DateStartDataPicker.SelectedDate));
            }

            var lessonsAmount = timeTables.Count;
            var conductedLessonsAmount = timeTables.Where(z => (bool)z.isRaportCreated).ToList().Count;

            var lessonsAmountProcent = conductedLessonsAmount / ( lessonsAmount / 100 );

            ((PieSeries)LessonsTaughtChart.Series[0]).ItemsSource =
            new KeyValuePair<string, double>[]
            {
                new KeyValuePair<string,double>("Проведено", lessonsAmountProcent),
                new KeyValuePair<string,double>("Не проведено",100 -  lessonsAmountProcent),
            };
        }
    }
}
