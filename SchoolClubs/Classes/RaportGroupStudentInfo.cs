using SchoolClubs.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class RaportGroupStudentInfo
    {
        public Student student { get; set; }
        public Raport_GroupStudent raportGroupStudent { get; set; }

        public string NSP { get; set; }
        public string number { get; set; }
        public bool wasInClass { get; set; }

        public RaportGroupStudentInfo(Raport_GroupStudent raportGrStudent, int _number)
        {
            student = App.connection.Student.FirstOrDefault(x => x.idStudent == App.connection.Group_Student.FirstOrDefault(z => z.idGroup_Student == raportGrStudent.idGroup_Student).idStudent);
            NSP = $"{student.Surname} {student.Name[0]}. {student.Patronymic[0]}.";
            number = $"{_number}.";
            wasInClass = false;
            raportGroupStudent = raportGrStudent;
        }
    }
}
