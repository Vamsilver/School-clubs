using SchoolClubs.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class TimetableEntity
    {
        public int Number { get; set; }
        public User User { get; set; }
        public Section Section { get; set; }
        public Group Group { get; set; }
        public Timetable Timetable { get; set; }
        public string DayOfWeek { get; set; }

        public TimetableEntity(Timetable timetable, int number)
        {
            Timetable = timetable;
            Group = App.Connection.Group.FirstOrDefault(x => x.idGroup ==
                    App.Connection.Group_Student.FirstOrDefault(z => z.idGroup_Student ==
                    App.Connection.Raport_GroupStudent.FirstOrDefault(c => c.idRaport == timetable.idRaport).idGroup_Student).idGroup);
            Section = App.Connection.Section.FirstOrDefault(x => x.idSection == App.Connection.Group.FirstOrDefault(z => z.idGroup == Group.idGroup).idSection);

            User = Section.User;
            User.Name = User.Name[0].ToString() + ".";
            User.Patronymic = User.Patronymic[0].ToString() + ".";
            Number = number;
            DayOfWeek = Converter(timetable.Date);
        }

        public string Converter(DateTime date)
        {
            switch ((int)date.Date.DayOfWeek)
            {
                case 0: return "Воскресенье";
                case 1: return "Понедельник";
                case 2: return "Вторник";
                case 3: return "Среда";
                case 4: return "Четверг";
                case 5: return "Пятница";
                case 6: return "Суббота";
            }
            return null;
        }

    }
}
