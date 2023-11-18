using SchoolClubs.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class TimetableInfo
    {
        public Timetable timetable { get; set; }
        public string number { get; set; }
        public string dayOfWeek { get; set; }

        public Section section { get; set; }

        public TimetableInfo(Timetable _timetable, int _number)
        {
            this.timetable = _timetable;
            var raport = App.Connection.Raport.FirstOrDefault(b => b.idRaport == timetable.idRaport);
            var raport_GroupStudent = App.Connection.Raport_GroupStudent.FirstOrDefault(v => v.idRaport == raport.idRaport);
            var grStudent = App.Connection.Group_Student.FirstOrDefault(c => c.idGroup_Student == raport_GroupStudent.idGroup_Student);
            var group = App.Connection.Group.FirstOrDefault(z => z.idGroup == grStudent.idGroup);
            section = App.Connection.Section.FirstOrDefault(x => x.idSection == group.idSection);

            number = $"{_number}.";
            switch ((int)_timetable.Date.DayOfWeek)
            {
                case 1: dayOfWeek = "Понедельник"; break;
                case 2: dayOfWeek = "Вторник"; break;
                case 3: dayOfWeek = "Среда"; break;
                case 4: dayOfWeek = "Четверг"; break;
                case 5: dayOfWeek = "Пятница"; break;
                case 6: dayOfWeek = "Суббота"; break;
                case 0: dayOfWeek = "Воскресенье"; break;
            }
        }
    }
}
