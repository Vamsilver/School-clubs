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

namespace SchoolClubs.Pages.Director
{
    /// <summary>
    /// Interaction logic for DirectorStatisticsPage.xaml
    /// </summary>
    public partial class DirectorStatisticsPage : Page
    {
        public DirectorStatisticsPage()
        {
            InitializeComponent();
            LoadLessonsTaught();
            LoadTeacherRating();
            LoadNumberOfStudents();
        }

        private void LoadLessonsTaught()
        {
            ((PieSeries)LessonsTaughtChart.Series[0]).ItemsSource =
            new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string,int>("Проведено", 80),
                new KeyValuePair<string,int>("Не проведено", 20),
            };
        }

        private void LoadTeacherRating()
        {
            var list = new List<TeacherRatingView>();

            list.Add(new TeacherRatingView("Габдрахманов Р. А.", 56.7));
            list.Add(new TeacherRatingView("Габдрах Б. П.", 56.8));
            list.Add(new TeacherRatingView("Габдрахма Н. К.", 76.7));
            list.Add(new TeacherRatingView("Габдрахман Р. В.", 26.7));

            var orderedList = list.OrderByDescending(z => z.Points);

            for(int i = 0; i < orderedList.Count(); i++)
            {
                orderedList.ElementAt(i).Number = i + 1;
            }

            TeacherRatingListView.ItemsSource = orderedList;
        }

        private void LoadNumberOfStudents()
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

            NumberOfStudentsListView.ItemsSource = list;
        }
    }
}
