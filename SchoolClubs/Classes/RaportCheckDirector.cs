using SchoolClubs.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class RaportCheckDirector
    {
        public TimeSpan time { get; set; }
        public string sectionTitle { get; set; }
        public string groupTitle { get; set; }
        public string teacherName { get; set; }
        public string students { get; set; }
        public List<Raport_GroupStudent> raportGroupStudentsList { get; set; }
        public Group_Student groupStudents { get; set; }
        public Group group { get; set; }

        public RaportCheckDirector(List<Raport_GroupStudent> _raportGroupSt, TimeSpan _time)
        {
            time = _time;
            raportGroupStudentsList = _raportGroupSt;
            foreach (Raport_GroupStudent raportGroupSt in raportGroupStudentsList)
            {
                groupStudents = App.Connection.Group_Student.Where(x => x.idGroup_Student == raportGroupSt.idGroup_Student).FirstOrDefault();
                group = App.Connection.Group.Where(x => x.idGroup == groupStudents.idGroup).FirstOrDefault();
                groupTitle = group.Name;
                sectionTitle = App.Connection.Section.FirstOrDefault(x => x.idSection == group.idSection).Title;
                teacherName = App.Connection.User.FirstOrDefault(z => z.idUser == App.Connection.Section.FirstOrDefault(x => x.idSection == group.idSection).idUser).Surname;

                var st = App.Connection.Student.Where(x => x.idStudent == groupStudents.idStudent).FirstOrDefault();
                ADOApp.Class classNC = App.Connection.Class.Where(x => x.idClass == st.idClass).FirstOrDefault();
                students += st.Surname + "  " + st.Name + "  " + classNC.Number + " " + classNC.Char + Environment.NewLine; 
            }
        }
    }
}
