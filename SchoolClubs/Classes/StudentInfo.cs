using SchoolClubs.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class StudentInfo
    {
        public Student student { get; set; }
        public string NSP { get; set; }
        public string classInfo { get; set; }

        public string number { get; set; }

        public bool isInGroup { get; set; }

        public StudentInfo(Student _student, int _number)
        {

            Group_Student grSt = App.connection.Group_Student.Where(x => x.idStudent == _student.idStudent).ToList().LastOrDefault();     
            BD.Class classFromBD = App.connection.Class.FirstOrDefault(x => x.idClass == _student.idClass);
            student = _student;
            NSP = $"{_student.Surname} {student.Name[0]}. {student.Patronymic[0]}.";
            classInfo = $"Класс {classFromBD.Number}{classFromBD.Char}";
            number = $"{_number}.";
            switch (App.connection.Group_Student.Where(x => x.idStudent == _student.idStudent).ToList().LastOrDefault().idStudentStatus)
            {
                case 1: isInGroup = true ; break;
                case 2: isInGroup = false ; break;
            }
        }
    }
}
